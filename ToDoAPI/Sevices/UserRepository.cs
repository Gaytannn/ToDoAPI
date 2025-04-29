using ToDoAPI.Data;
using ToDoAPI.Interfaces;
using ToDoAPI.Models;

namespace ToDoAPI.Sevices;

public class UserRepository : IUserRepository
{

    private readonly ToDoContext _context;

    public UserRepository(ToDoContext context)
    {
        _context = context;
    }
    public async Task<Guid> AddAsync(User entity)
    {
        await _context.Users.AddAsync(entity);

        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public Task<Guid> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<User>> GetAllAsync(int? offset = null, int? skip = null)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}
