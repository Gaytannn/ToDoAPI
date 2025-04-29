using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Interfaces;
using ToDoAPI.Models.Mapper;
using ToDoAPI.Models.Request;
using ToDoAPI.Sevices;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHasherService _passwordHasher;

        public UserController(IUserRepository repository, IPasswordHasherService passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRequest user)
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


                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _repository.GetAllAsync();

                return Ok(users);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
