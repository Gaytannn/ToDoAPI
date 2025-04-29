using ToDoAPI.Interfaces.Abstractions;
using ToDoAPI.Models;

namespace ToDoAPI.Interfaces;

public interface ITaskRepository: IRepository<TaskItem,Guid>
{
    Task<IReadOnlyList<TaskItem>> GetAllByUser(Guid Id);
}
