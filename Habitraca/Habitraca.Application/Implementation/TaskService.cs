using Habitraca.Application.Interface.Service;
using Habitraca.Application.Interfaces.Repositories;
using Habitraca.Domain;
using Habitraca.Domain.Entities;
using Habitraca.Domain.Enum;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace Habitraca.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private async Task<(int completed, int total)> GetTaskStats(string userId, TaskFrequency frequency)
        {
            var periodStart = GetPeriodStartDate(frequency);
            
            // Get completed tasks using TaskCompletionRepository
            var completions = await _unitOfWork.TaskCompletionRepository
                .GetByDateRangeAsync(userId, periodStart, DateTime.UtcNow);
            
            var completedCount = completions
                .Count(tc => tc.Task.Frequency == frequency);

            // Get total active tasks using TaskRepository
            var activeTasks = await _unitOfWork.TaskRepository.GetActiveTasksAsync();
            var totalCount = activeTasks
                .Count(t => t.Frequency == frequency);

            return (completedCount, totalCount);
        }

        private DateTime GetPeriodStartDate(TaskFrequency frequency)
        {
            var now = DateTime.UtcNow;
            return frequency switch
            {
                TaskFrequency.Daily => now.Date,
                TaskFrequency.Weekly => now.AddDays(-(int)now.DayOfWeek).Date,
                TaskFrequency.Monthly => new DateTime(now.Year, now.Month, 1),
                _ => throw new ArgumentException("Invalid frequency")
            };
        }

        public async Task<ApiResponse<string>> DailyTaskRecord(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return ApiResponse<string>.Failed(
                    "Invalid user ID provided.", 
                    StatusCodes.Status400BadRequest, 
                    new List<string>());
            }

            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return new ApiResponse<string>(
                    false, 
                    "User does not exist.", 
                    StatusCodes.Status404NotFound, 
                    null, 
                    new List<string>());
            }

            var (completed, total) = await GetTaskStats(id, TaskFrequency.Daily);
            var response = $"{completed}/{total}";

            return new ApiResponse<string>(
                true, 
                "Daily task record displayed successfully", 
                200, 
                response, 
                new List<string>());
        }

        public async Task<ApiResponse<string>> WeeklyTaskRecord(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return ApiResponse<string>.Failed(
                    "Invalid user ID provided.", 
                    StatusCodes.Status400BadRequest, 
                    new List<string>());
            }

            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return new ApiResponse<string>(
                    false, 
                    "User does not exist.", 
                    StatusCodes.Status404NotFound, 
                    null, 
                    new List<string>());
            }

            var (completed, total) = await GetTaskStats(id, TaskFrequency.Weekly);
            var response = $"{completed}/{total}";

            return new ApiResponse<string>(
                true, 
                "Weekly task record displayed successfully", 
                200, 
                response, 
                new List<string>());
        }

        public async Task<ApiResponse<string>> MonthlyTaskRecord(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return ApiResponse<string>.Failed(
                    "Invalid user ID provided.", 
                    StatusCodes.Status400BadRequest, 
                    new List<string>());
            }

            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return new ApiResponse<string>(
                    false, 
                    "User does not exist.", 
                    StatusCodes.Status404NotFound, 
                    null, 
                    new List<string>());
            }

            var (completed, total) = await GetTaskStats(id, TaskFrequency.Monthly);
            var response = $"{completed}/{total}";

            return new ApiResponse<string>(
                true, 
                "Monthly task record displayed successfully", 
                200, 
                response, 
                new List<string>());
        }

        public async Task<int> GetTotalActiveTasksCount(string userId)
        {
            var activeTasks = await _unitOfWork.TaskRepository.GetActiveTasksAsync();
            return activeTasks.Count();
        }

       public async Task<ApiResponse<string>> AddUserTask(string id, List<TaskDto> listOfTasks) 
        {
            if (string.IsNullOrEmpty(id))
            {
                return ApiResponse<string>.Failed(
                    "Invalid user ID provided.", 
                    StatusCodes.Status400BadRequest, 
                    new List<string>());
            }

            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return new ApiResponse<string>(
                    false, 
                    "User does not exist.", 
                    StatusCodes.Status404NotFound, 
                    null, 
                    new List<string>());
            }

            if (listOfTasks == null || !listOfTasks.Any())
            {
                return ApiResponse<string>.Failed(
                    "No tasks provided.", 
                    StatusCodes.Status400BadRequest, 
                    new List<string>());
            }
            var tasksToAdd = listOfTasks.Select(task => new HabitTask
            {
                Title = task.Task,
                Frequency = task.Frequency,
                Category = task.Category,
                Points = task.Points,
                UserId = id,  // Assigning the user ID to each task
                CreatedAt = DateTime.UtcNow
            }).ToList();

            await _unitOfWork.TaskRepository.AddRangeAsync(tasksToAdd);
            await _unitOfWork.TaskRepository.CommitAsync();

            return new ApiResponse<string>(true, "Tasks added successfully.", StatusCodes.Status201Created, null, null);
        }

        public async Task<ApiResponse<string>> AddCompletedTask(string id, List<CompletedTaskDto> listOfTasks)
        {
            // Validate the user ID
            if (string.IsNullOrEmpty(id))
            {
                return ApiResponse<string>.Failed(
                    "Invalid user ID provided.",
                    StatusCodes.Status400BadRequest,
                    new List<string>());
            }

            // Fetch the user from the repository
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return new ApiResponse<string>(
                    false,
                    "User does not exist.",
                    StatusCodes.Status404NotFound,
                    null,
                    new List<string>());
            }

            // Validate the tasks list
            if (listOfTasks == null || !listOfTasks.Any())
            {
                return ApiResponse<string>.Failed(
                    "No tasks provided.",
                    StatusCodes.Status400BadRequest,
                    new List<string>());
            }
            var taskIds = listOfTasks.Select(task => Guid.Parse(task.TaskId));
            var tasks = await _unitOfWork.TaskRepository.GetByTaskIdsAsync(taskIds); 
            if (tasks == null || !tasks.Any())
            {
                return ApiResponse<string>.Failed(
                    "Some tasks not found.",
                    StatusCodes.Status404NotFound,
                    new List<string>());
            }

            // Prepare TaskCompletion entries
            var tasksToAdd = listOfTasks.Select(taskDto =>
            {
                var task = tasks.FirstOrDefault(t => t.Id == Guid.Parse(taskDto.TaskId)); 
                if (task == null) return null; 

                return new TaskCompletion
                {
                    TaskId = Guid.Parse(taskDto.TaskId),  
                    Task = task,            
                    UserId = id,            
                    CompletedAt = DateTime.UtcNow 
                };
            }).Where(t => t != null).ToList(); // Remove any null TaskCompletion entries

            await _unitOfWork.TaskCompletionRepository.AddRangeAsync(tasksToAdd);
            await _unitOfWork.TaskRepository.CommitAsync(); 

            return new ApiResponse<string>(
                true,
                "Tasks added successfully.",
                StatusCodes.Status201Created,
                null,
                null);
        }


        public async Task<ApiResponse<List<TaskPool>>> GetAllTaskPoolByCategory(TaskCategory category)
        {
            var tasks = await _unitOfWork.TaskPoolRepository.GetAllAsync();

            var filteredTasks = tasks?.Where(t => t.Category == category && t.IsActive == true).ToList();

            if (filteredTasks == null || !filteredTasks.Any())
            {
                return new ApiResponse<List<TaskPool>>(
                    false,
                    $"No tasks found for category {category}.",
                    StatusCodes.Status404NotFound,
                    null,
                    new List<string>());
            }

            return new ApiResponse<List<TaskPool>>(
                true,
                "Tasks for the specified category displayed successfully",
                200,
                filteredTasks,
                new List<string>()); 
        }
        public async Task<ApiResponse<List<HabitTask>>> GetAllSelectedTask(string id)
        {
            var tasks = await _unitOfWork.TaskRepository.GetByUserIdAsync(id);

            if (tasks == null || !tasks.Any())
            {
                return new ApiResponse<List<HabitTask>>(
                    false,
                    $"No tasks found for category.", 
                    StatusCodes.Status404NotFound,
                    null,
                    new List<string>());
            }
            var taskList = tasks.ToList();
            return new ApiResponse<List<HabitTask>>(
                true,
                "Tasks for the specified category displayed successfully",
                200,
                taskList,
                new List<string>());
        }
        public async Task<ApiResponse<List<TaskCompletion>>> GetAllCompletedTask(string id)
        {
            var tasks = await _unitOfWork.TaskCompletionRepository.GetByUserIdAsync(id);

            if (tasks == null || !tasks.Any())
            {
                return new ApiResponse<List<TaskCompletion>>(
                    false,
                    $"No tasks has been done.",
                    StatusCodes.Status404NotFound,
                    null,
                    new List<string>());
            }
            var taskList = tasks.ToList();
            return new ApiResponse<List<TaskCompletion>>(
                true,
                "Completed Tasks displayed successfully",
                200,
                taskList,
                new List<string>());
        }
        


    }
} 