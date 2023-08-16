using TaskManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TaskManagementSystem.Persistence.Configurations.Entities;

public class TaskConfiguration : IEntityTypeConfiguration<Domain.Task>
{
    public void Configure(EntityTypeBuilder<Domain.Task> builder)
    {
        builder.HasData(
                new Domain.Task
                {
                    Id = 1,
                    UserId = 1,
                    ProjectId = 1,
                    Title = "Do something",
                    DueDate = DateTime.Now,
                    Description = "this is the first Task",

                }

            );
    }

}

