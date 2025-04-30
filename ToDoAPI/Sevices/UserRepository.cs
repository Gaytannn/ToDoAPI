using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using ToDoAPI.Data;
using ToDoAPI.Entities;
using ToDoAPI.Interfaces.Repository;

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

    public async Task<IReadOnlyList<User>> GetAllAsync(int? offset = null, int? skip = null)
    {
       return await _context.Users.ToListAsync();
    }

    public Task<User?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
       return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public Task<Guid> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}
