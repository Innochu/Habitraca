using Habitraca.Application.Interface.Service;
using Habitraca.Domain.Entities;
using Habitraca.Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Habitraca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
         private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("DailyTaskRecord/{id}")]
         public async Task<IActionResult> DailyTaskRecord(string id)
        {
            var result = await _taskService.DailyTaskRecord(id);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
        }

        [HttpGet("WeeklyTaskRecord/{id}")]
         public async Task<IActionResult> WeeklyTaskRecord(string id)
        {
            var result = await _taskService.WeeklyTaskRecord(id);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
        }
        
        [HttpGet("MonthlyTaskRecord/{id}")]
         public async Task<IActionResult> MonthlyTaskRecord(string id)
        {
            var result = await _taskService.MonthlyTaskRecord(id);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
        }
        [HttpPost("AddTask(s)/{id}")]
        public async Task<IActionResult> AddTask(string id, [FromBody] List<TaskDto> listOfTasks)
        {
            var result = await _taskService.AddUserTask(id, listOfTasks);
            if (result.Succeeded)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
        }
        [HttpPost("AddCompletedTasks")]
        public async Task<IActionResult> AddcompletedTask(string id, [FromBody] List<CompletedTaskDto> listOfTasks)
        {
            var result = await _taskService.AddCompletedTask(id, listOfTasks);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("Get-All-TaskPool-By-Category")]
        public async Task<IActionResult> TaskPool(TaskCategory category)
        {
            var result = await _taskService.GetAllTaskPoolByCategory(category);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            { 
                return BadRequest(result);
            }
        }
        [HttpGet("{id:Guid}Get-All-SelectedTask-By-UserId")]
        public async Task<IActionResult> SelectedTask(string id)
        {
            var result = await _taskService.GetAllSelectedTask(id);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("Get-CompletedTask-By-UserId")]
        public async Task<IActionResult> CompletedTask(string id, TaskFrequency taskFrequency)
        {
            var result = await _taskService.GetAllCompletedTask(id, taskFrequency);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}