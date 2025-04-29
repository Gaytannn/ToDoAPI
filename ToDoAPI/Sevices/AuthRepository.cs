using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Interfaces;
using ToDoAPI.Models;

namespace ToDoAPI.Sevices;

public class AuthRepository : IAuthRepository
{
    private readonly ToDoContext _context;
    public AuthRepository(ToDoContext context)
    {
        _context = context;
    }
    public async Task<User?> GetLogin(string username)
    {
       return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
      
    }
}
