using ToDoAPI.Interfaces.Abstractions;
using ToDoAPI.Models;

namespace ToDoAPI.Interfaces;

public interface IUserRepository:IRepository<User,Guid>
{
    Task<User?> GetByUsernameAsync(string username);
}
