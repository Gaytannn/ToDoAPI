namespace ToDoAPI.Interfaces.Services;

public interface IAuthService
{
    Task<bool> ValidateCredentials(string username, string password);
}
