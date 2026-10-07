using Hr.Domain.Entites;
using Hr.Domain.Entites.EmployeeAggragtte;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hr.Infrastructure.Data.Configs
{
    public class NationalityConfig : IEntityTypeConfiguration<Nationality>
    {
        public void Configure(EntityTypeBuilder<Nationality> builder)
        {
            builder.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}