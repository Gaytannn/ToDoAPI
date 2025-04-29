using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoAPI.Models.Request;
using ToDoAPI.Sevices;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TasksCaseUse _tasksCaseUse;

        public TaskController(TasksCaseUse tasksCaseUse)
        {
            _tasksCaseUse = tasksCaseUse;
        }

        [HttpPost]
        public async Task<ActionResult> Create(TaskItemRequest request)
        {
            try
            {

                await _tasksCaseUse.AddAsync(request);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }

    }
}
