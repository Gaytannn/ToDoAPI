using ToDoAPI.Interfaces;

namespace ToDoAPI.Sevices;

public class PasswordHasherService : IPasswordHasherService
{
    public string HashPassword(string password)
    {
        throw new NotImplementedException();
    }

    public bool VerifyPassword(string password, string storedHash)
    {
        throw new NotImplementedException();
    }
}
