namespace ToDoAPI.Interfaces;

public interface IAuthService
{
    Task<bool> ValidateCredentials(string username, string password);
}
