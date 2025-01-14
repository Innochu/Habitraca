using Habitraca.Application.Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Habitraca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphController : ControllerBase
    {
        private readonly IGraphService graphService;

        public GraphController(IGraphService graphService)
        {
            this.graphService = graphService;
        }
        [HttpGet("get-task-data")]
        public IActionResult GetTaskData(DateTime startDate, DateTime endDate, string id)
        {
            try
            {
                var taskDataList = graphService.GetTaskDataForRange(startDate, endDate, id);
                return Ok(taskDataList);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
