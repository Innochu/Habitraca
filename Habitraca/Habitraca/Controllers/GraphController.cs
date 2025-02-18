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
        public IActionResult GetTaskData(string id, int numberOfDays = 7)
        {
            try
            {
                var taskDataList = graphService.GetDailyPointsChartData( id,  numberOfDays = 7);
                return Ok(taskDataList);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
