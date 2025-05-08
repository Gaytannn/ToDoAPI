using Microsoft.AspNetCore.Mvc;
using Serilog;
using ToDoAPI.Interfaces.Repository;
using ToDoAPI.Interfaces.Services;
using ToDoAPI.Models.Mapper;
using ToDoAPI.Models.Request;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHasherService _passwordHasher;

        public UsersController(IUserRepository repository, IPasswordHasherService passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserRequest user)
        {
            try
            {
                var newUser = user.ToUser();

                newUser.PasswordHash = _passwordHasher.Hash(user.Password);


                var exits = await _repository.GetByUsernameAsync(user.User);

                if (exits is not null)
                {
                    return BadRequest("El usuario ya se encuentra registrado");
                }

                await _repository.AddAsync(newUser);


                return CreatedAtAction(nameof(Create),new {user.User},user);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ocurrio un error al crear el usuario @UserRequest",user);
                return Problem("Ocurrio un error inesperado");
            }
        }

       

    }
}
