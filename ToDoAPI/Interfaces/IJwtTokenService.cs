namespace ToDoAPI.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(string username,Guid id);
    bool ValidateToken(string token, out string username);
}
