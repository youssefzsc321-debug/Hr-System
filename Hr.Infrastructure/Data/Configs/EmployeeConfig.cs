using Hr.Domain.Entites.EmployeeAggragtte;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hr.Infrastructure.Data.Configs
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.NationalId)
                .IsRequired()
                .HasMaxLength(14); 

            builder.HasIndex(e => e.NationalId)
                .IsUnique();

            builder.Property(e => e.Salary)
                .HasColumnType("decimal(18,2)");

            builder.OwnsOne(e => e.Address, address =>
            {
                address.WithOwner();
                address.Property(a => a.City).HasMaxLength(50);
                address.Property(a => a.Street).HasMaxLength(100);
            });


        }
    }
}