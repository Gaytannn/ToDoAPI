using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDoAPI.Interfaces.Repository;
using ToDoAPI.Models.Mapper;
using ToDoAPI.Models.Request;
using ToDoAPI.Sevices;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _repository;
        private readonly IUserRepository _repositoryUser;
     

        public TasksController(ITaskRepository repository, IUserRepository repositoryUser)
        {
            _repository = repository;
            _repositoryUser = repositoryUser;
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(TaskItemRequest request)
        {
            try
            {

                var userId = User.FindFirst(ClaimTypes.NameIdentifier);

                var newTask = request.ToTaskItem();

                newTask.UserId = Guid.Parse(userId!.Value);

                await _repository.AddAsync(newTask);

                return CreatedAtAction(nameof(TaskItemRequest),new {request.Title},request);
            }
            catch (Exception ex)
            {

                return Problem("Ocurrio un error inesperado");
            }

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var userId = User.FindFirst(ClaimTypes.NameIdentifier);

                var Id = Guid.Parse(userId!.Value);

                var tasks = await _repository.GetAllByUser(Id);

                return Ok(tasks);
            }
            catch (Exception ex)
            {

                return Problem();
            }
        }

    }
}
