using ToDoAPI.Entities;
using ToDoAPI.Models.Request;

namespace ToDoAPI.Models.Mapper;

public static class TaskMappings
{

    public static TaskItem ToTaskItem(this TaskItemRequest request)
    {
        return new()
        {
            Title = request.Title,
            Description = request.Description,
            Priority = request.Priority,
            Status=Status.Pending
            

        };
    }
}
