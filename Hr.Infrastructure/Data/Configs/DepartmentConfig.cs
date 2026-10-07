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
        }
    }
}