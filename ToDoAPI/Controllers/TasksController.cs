using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDoAPI.Entities;
using ToDoAPI.Helpers;
using ToDoAPI.Interfaces.Repository;
using ToDoAPI.Models.Mapper;
using ToDoAPI.Models.Reponse;
using ToDoAPI.Models.Request;
using ToDoAPI.Sevices;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : AuthenticatedControllerBase
    {
        private readonly ITaskRepository _repository;
    

        public TasksController(ITaskRepository repository)
        {
            _repository = repository;
            
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TaskItemRequest request)
        {
            try
            {
                var newTask = request.ToTaskItem();

                newTask.UserId = UserId;

                var response = await _repository.AddAsync(newTask);

                return CreatedAtAction(nameof(GetById), new { id = newTask.Id }, response);

            }
            catch (Exception ex)
            {

                Log.Error(ex, "Ocurrio un error al crear la tarea @TaskItemRequest", request);
                return Problem("Ocurrio un error inesperado");
            }

        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItemReponse>>> GetAll()
        {
            try
            {

                var tasks = await _repository.GetAllByUser(UserId);

                var taskMapped = tasks.ToResponse();

                return Ok(taskMapped);
            }
            catch (Exception ex)
            {

                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "Desconocido";
                Log.Error(ex, "Ocurrió un error al cargar la lista de tareas del empleado {Id}", UserId);

                return Problem();
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemReponse>> GetById([FromRoute] Guid id)
        {
            try
            {

                var task = await _repository.GetByIdAsync(id);


                if (task is null || task.UserId != UserId)
                    return NotFound("No se encontro la tarea ");
                


                var taskMapped = task.ToResponse();

                return Ok(taskMapped);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocurrió un error al cargar la lista de tareas del empleado {Id}", UserId);

                return Problem();
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]Guid id)
        {
            try
            {

                var task = await _repository.GetByIdAsync(id);

                if (task is null || task.UserId != UserId)
                    return NotFound("No se encontró la tarea o no tiene permiso para eliminarla");


                await _repository.DeleteAsync(task);


                return Ok(task.Id);

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocurrio un error al eliminar la tarea {id}", id);
                return Problem("Ocurrio un error inesperado");
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute]Guid id, [FromBody] TaskItemRequest request)
        {
            try
            {
                var task = await _repository.GetByIdAsync(id);


                if (task is null || task.UserId != UserId)
                    return NotFound("No se encontró la tarea o no tiene permiso para actualizarla");


                request.MapTo(task);
              
                await _repository.UpdateAsync(task);


                return Ok(request);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocurrio un error al actualizar la tarea {id} {@TaskItemRequest}",id,request);
                return Problem("Ocurrio un error inesperado");
            }

        }

    }
}
