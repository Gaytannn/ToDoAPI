namespace ToDoAPI.Interfaces;

public interface IPasswordHasherService
{
    bool Verify(string passwordHash, string inputPassword);
    string Hash(string password);
}
