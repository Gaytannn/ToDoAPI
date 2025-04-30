using ToDoAPI.Data;
using ToDoAPI.Interfaces.Repository;
using ToDoAPI.Interfaces.Services;

namespace ToDoAPI.Sevices.Auth;

public class AuthService : IAuthService
{


    private readonly IAuthRepository _repository;
    private readonly IPasswordHasherService _passwordHasher;
    public AuthService( IPasswordHasherService passwordHasher ,IAuthRepository repository)
    {
        _repository = repository;
        _passwordHasher = passwordHasher;
    }
    public async Task<bool> ValidateCredentials(string username, string password)
    {

        var user = await _repository.GetLogin(username);

        if (user is null)
        {
            return false;
        }


        return _passwordHasher.Verify(user.PasswordHash, password);

    }
}
