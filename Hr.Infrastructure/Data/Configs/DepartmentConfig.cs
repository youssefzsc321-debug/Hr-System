using Hr.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hr.Infrastructure.Data.Configs
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(d => d.Name)
                .IsUnique();

            builder.HasData(
                new Department { Id = 1, Name = "Information Technology (IT)" },
                new Department { Id = 2, Name = "Human Resources (HR)" },
                new Department { Id = 3, Name = "Sales Department" },
                new Department { Id = 4, Name = "Marketing Department" },
                new Department { Id = 5, Name = "Finance Department" }
            );
        }
    }
}