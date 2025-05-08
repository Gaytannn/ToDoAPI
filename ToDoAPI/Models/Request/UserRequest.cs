namespace ToDoAPI.Models.Request;

public class UserRequest
{
    public string User { get; set; } = string.Empty;
    public string Password { get; set; }= string.Empty;
}
