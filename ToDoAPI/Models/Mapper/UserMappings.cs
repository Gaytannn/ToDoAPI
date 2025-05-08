using ToDoAPI.Entities;
using ToDoAPI.Models.Request;

namespace ToDoAPI.Models.Mapper;

public static class UserMappings
{
    public static User ToUser(this UserRequest request)
    {
        return new()
        {
            Username = request.User,
            PasswordHash = request.Password
        };
    }
}
