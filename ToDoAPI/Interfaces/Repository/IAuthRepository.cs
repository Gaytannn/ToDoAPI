using ToDoAPI.Entities;

namespace ToDoAPI.Interfaces.Repository;

public interface IAuthRepository
{
    Task<User?> GetLogin(string username);
}
