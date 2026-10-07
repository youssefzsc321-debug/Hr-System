using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hr.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            var cascadeFKS = builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())
                .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade
                          && !fk.IsOwnership
                          && !fk.DeclaringEntityType.ClrType.Namespace.Contains("Microsoft.AspNetCore.Identity"));

            foreach (var fk in cascadeFKS)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}