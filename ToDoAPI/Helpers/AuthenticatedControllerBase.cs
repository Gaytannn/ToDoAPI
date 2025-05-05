using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ToDoAPI.Helpers;

public abstract class AuthenticatedControllerBase: ControllerBase
{
    protected Guid UserId => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
}
