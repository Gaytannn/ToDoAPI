using ToDoAPI.Entities;
using ToDoAPI.Interfaces.Abstractions;

namespace ToDoAPI.Interfaces.Repository;

public interface IUserRepository:IRepository<User,Guid>
{
    Task<User?> GetByUsernameAsync(string username);
}
