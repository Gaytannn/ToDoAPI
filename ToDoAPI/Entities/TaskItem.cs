using System.Text.Json.Serialization;

namespace ToDoAPI.Entities;

public class TaskItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Status Status { get; set; }
    public Priority Priority { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public Guid UserId { get; set; }

    [JsonIgnore]
    public virtual User? User { get; set; } 
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
