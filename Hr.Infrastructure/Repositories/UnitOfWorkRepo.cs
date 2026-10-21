using Hr.Application.Repositories;
using Hr.Domain.Entites;
using Hr.Domain.Entites.EmployeeAggragtte;
using Hr.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Infrastructure.Repositories
{
    public class UnitOfWorkRepo : IUnitOfWorkRepo
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepo<Employee> Employees { get; }

        public IGenericRepo<Department> Departments { get; }

        public IGenericRepo<Nationality> Nationalites { get; }

        public IGenericRepo<GeneralSettings> GeneralSettings { get; }

        public IGenericRepo<OfficialHoliday> OfficialHolidays { get; }

        public IGenericRepo<Role> Roles { get; }

        public IGenericRepo<RolePermission> RolePermissions { get; }

        public UnitOfWorkRepo(ApplicationDbContext context)
        {
            _context = context;
            Employees = new GenericRepo<Employee>(_context);
            Departments = new GenericRepo<Department>(_context);
            Nationalites = new GenericRepo<Nationality>(_context);
            GeneralSettings = new GenericRepo<GeneralSettings>(_context);
            OfficialHolidays = new GenericRepo<OfficialHoliday>(_context);
            Roles = new GenericRepo<Role>(_context);
            RolePermissions = new GenericRepo<RolePermission>(_context);

        }
            
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
