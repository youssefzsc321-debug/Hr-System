using Hr.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Infrastructure.Data.Configs
{
    public class GeneralSettingsConfg : IEntityTypeConfiguration<GeneralSettings>
    {
        public void Configure(EntityTypeBuilder<GeneralSettings> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DeducationVal)
                  .HasPrecision(18, 2);

            builder.Property(x => x.OverTimeVal)
                  .HasPrecision(18, 2);
        }
    }
}
