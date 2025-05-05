using System.Text.Json.Serialization;
using ToDoAPI.Entities;

namespace ToDoAPI.Models.Reponse;

public record TaskItemReponse(Guid Id,string Title,string Description,Status Status, Priority Priority,DateTime Date);

