using Hr.Domain.Entites;
using Hr.Domain.Entites.EmployeeAggragtte;
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

        public DbSet<GeneralSettings> GeneralSettings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<OfficialHoliday> officialHolidays { get; set; }
        public DbSet<Attendance> Attendances { get; set; }


    }
}