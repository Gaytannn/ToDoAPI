using ToDoAPI.Entities;
using ToDoAPI.Models.Reponse;
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

    public static void MapTo(this TaskItemRequest request, TaskItem task)
    {
        task.Title = request.Title;
        task.Description = request.Description;
        task.Priority = request.Priority;
    }

    public static TaskItemReponse ToResponse(this TaskItem response)
    {
        return new TaskItemReponse(
            Id:response.Id,
            Title:response.Title,
            Description:response.Description,
            Status:response.Status,
            Priority:response.Priority,
            Date:response.CreatedAt
            );
    
    }

    public static IEnumerable<TaskItemReponse> ToResponse(this IEnumerable<TaskItem> responses)
    {
        return responses.Select(r => r.ToResponse());
    }

}
