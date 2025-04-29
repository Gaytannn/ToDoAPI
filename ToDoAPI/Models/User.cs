namespace ToDoAPI.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public virtual ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
}
