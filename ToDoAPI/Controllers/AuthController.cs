using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Interfaces;
using ToDoAPI.Models.Request;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IUserRepository _repository;
        public AuthController(IAuthService authService, IJwtTokenService jwtTokenService, IUserRepository repository)
        {
            _authService = authService;
            _jwtTokenService = jwtTokenService;
            _repository = repository;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CredentialsRequest request)
        {

            if (request == null || string.IsNullOrWhiteSpace(request.User) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Invalid request.");
            }


            var user = await _authService.ValidateCredentials(request.User, request.Password);

            if (!user)
            {
                return Unauthorized("Invalid username or password.");
            }

            var userAuth = await _repository.GetByUsernameAsync(request.User);

            var token = _jwtTokenService.GenerateToken(request.User,userAuth!.Id);

            return Ok(new
            {
                Token = token
            });
        }



    }

}

