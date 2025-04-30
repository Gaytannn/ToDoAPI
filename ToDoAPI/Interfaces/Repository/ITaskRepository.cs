using ToDoAPI.Entities;
using ToDoAPI.Interfaces.Abstractions;

namespace ToDoAPI.Interfaces.Repository;

public interface ITaskRepository: IRepository<TaskItem,Guid>
{
    Task<IReadOnlyList<TaskItem>> GetAllByUser(Guid Id);
}
