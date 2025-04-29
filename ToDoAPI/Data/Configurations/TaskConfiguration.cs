using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoAPI.Models;
namespace ToDoAPI.Data.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
            .IsRequired();

        builder.Property(t => t.Description)
            .IsRequired();

        builder.Property(t => t.Status)
            .HasConversion<int>();

        builder.Property(t => t.Priority)
           .HasConversion<int>();


        builder.Property(t => t.CreatedAt)
            .IsRequired();


        builder.HasOne(t => t.User)
            .WithMany(t => t.Tasks)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
