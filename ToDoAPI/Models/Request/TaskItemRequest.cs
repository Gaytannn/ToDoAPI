namespace ToDoAPI.Models.Request;

public class TaskItemRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Priority Priority { get; set; }

   
}
