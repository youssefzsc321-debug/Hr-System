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

            builder.HasData(
                new Nationality { Id = 1, Name = "Egyptian" },
                new Nationality { Id = 2, Name = "Saudi" },
                new Nationality { Id = 3, Name = "Emirati" },
                new Nationality { Id = 4, Name = "Jordanian" },
                new Nationality { Id = 5, Name = "Kuwaiti" },
                new Nationality { Id = 6, Name = "Qatari" },
                new Nationality { Id = 7, Name = "Bahraini" },
                new Nationality { Id = 8, Name = "Omani" },
                new Nationality { Id = 9, Name = "Tunisian" },
                new Nationality { Id = 10, Name = "Moroccan" },
                new Nationality { Id = 11, Name = "Algerian" },
                new Nationality { Id = 12, Name = "American" },
                new Nationality { Id = 13, Name = "British" }
            );
        }
    }
}