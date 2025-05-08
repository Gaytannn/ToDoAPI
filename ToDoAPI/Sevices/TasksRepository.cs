using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Entities;
using ToDoAPI.Interfaces.Repository;
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

    public async Task<Guid> DeleteAsync(TaskItem entity)
    {
        entity.IsDeleted = true;
        _context.Tasks.Update(entity);
        await _context.SaveChangesAsync();

        return entity.Id;

    }

    public Task<IReadOnlyList<TaskItem>> GetAllAsync(int? offset = null, int? skip = null)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<TaskItem>> GetAllByUser(Guid Id)
    {

       var response = await _context.Tasks.ToListAsync();

       return await _context.Tasks.Include(t=>t.User).Where(t=>t.UserId==Id && t.IsDeleted==false).ToListAsync();
    }

    public async Task<TaskItem?> GetByIdAsync(Guid id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<Guid> UpdateAsync(TaskItem entity)
    {
        _context.Tasks.Update(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }
}
