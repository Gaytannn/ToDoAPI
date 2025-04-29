namespace ToDoAPI.Models;

public class TaskItem
{
    public Guid Id { get; set; } = new Guid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Status Status { get; set; }
    public Priority Priority { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = new();
}


public enum Status
{
    Pending = 1,   
    InProgress, 
    Completed   
}

public enum Priority
{
    Low =1,
    Medium, 
    High
}
