using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Interfaces;
using ToDoAPI.Models;
using ToDoAPI.Models.Request;

namespace ToDoAPI.Sevices;

public class TasksRepository :ITaskRepository
{

    private readonly ToDoContext _context;

    public TasksRepository(ToDoContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddAsync(TaskItem entity)
    {

        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public Task<Guid> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<TaskItem>> GetAllAsync(int? offset = null, int? skip = null)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<TaskItem>> GetAllByUser(Guid Id)
    {

       var response = await _context.Tasks.ToListAsync();

       return await _context.Tasks.Include(t=>t.User).Where(t=>t.UserId==Id).ToListAsync();
    }

    public Task<TaskItem?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> UpdateAsync(TaskItem entity)
    {
        throw new NotImplementedException();
    }
}
