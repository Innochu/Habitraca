using Habitraca.Application.Interface.Service;
using Habitraca.Domain.Entities;
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
        [HttpPost("AddTask(s)/{id}")] //endpoint to allow user submit list of task chosen 
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
    }
}