using Microsoft.EntityFrameworkCore;
using ToDoAPI.Entities;

namespace ToDoAPI.Data;

public class ToDoContext:DbContext
{
    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(ToDoContext).Assembly;

        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }
}
    