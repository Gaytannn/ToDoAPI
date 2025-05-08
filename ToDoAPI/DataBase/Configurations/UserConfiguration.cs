using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoAPI.Entities;

namespace ToDoAPI.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(t => t.Username)
            .IsRequired();

        builder.Property(t => t.PasswordHash)
           .IsRequired();

        builder.HasIndex(u => u.Username)
              .IsUnique();
    }
}
