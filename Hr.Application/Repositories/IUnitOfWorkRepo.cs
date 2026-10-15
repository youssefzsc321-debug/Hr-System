using Hr.Domain.Entites;
using Hr.Domain.Entites.EmployeeAggragtte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.Repositories
{
    public interface IUnitOfWorkRepo : IDisposable
    {
        public IGenericRepo<Employee> Employees { get; }
        public IGenericRepo<Department> Departments { get; }
        public IGenericRepo<Nationality> Nationalites { get; }
        public IGenericRepo<GeneralSettings> GeneralSettings { get; }
        public IGenericRepo<OfficialHoliday> OfficialHolidays { get; }
        

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);



    }
}
