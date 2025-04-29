using ToDoAPI.Models;
using ToDoAPI.Models.Request;

namespace ToDoAPI.Interfaces;

public interface IRepository
{
    Task<IEnumerable<TaskItem>> GetAllByUserIdAsync();
    Task AddAsync(TaskItemRequest newTask);
}
