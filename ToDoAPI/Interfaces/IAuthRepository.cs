using ToDoAPI.Models;

namespace ToDoAPI.Interfaces;

public interface IAuthRepository
{
    Task<User?> GetLogin(string username);
}
