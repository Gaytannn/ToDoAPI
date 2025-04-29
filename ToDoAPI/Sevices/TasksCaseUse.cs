using ToDoAPI.Data;
using ToDoAPI.Interfaces;
using ToDoAPI.Models;
using ToDoAPI.Models.Request;

namespace ToDoAPI.Sevices;

public class TasksCaseUse : IRepository
{
    private readonly ToDoContext _context;

    public TasksCaseUse(ToDoContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TaskItemRequest newTask)
    {

        var task = new TaskItem
        {
            Title = newTask.Title,
            Description = newTask.Description,
            Priority = newTask.Priority
        };


        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
    }

    public Task<IEnumerable<TaskItem>> GetAllByUserIdAsync()
    {
        throw new NotImplementedException();
    }
}
