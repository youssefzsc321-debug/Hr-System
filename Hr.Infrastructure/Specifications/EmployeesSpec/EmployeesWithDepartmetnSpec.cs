using Hr.Application.ViewModels.EmployeesVM;
using Hr.Domain.Entites.EmployeeAggragtte;

namespace Hr.Infrastructure.Specifications.EmployeesSpec
{
    public class EmployeesWithDepartmetnSpec : BaseSpecification<Employee>
    {
        public EmployeesWithDepartmetnSpec(EmployeeSepcParams specParams)
            : base(x =>
                (string.IsNullOrEmpty(specParams.Search) || x.FullName.ToLower().Contains(specParams.Search.ToLower())) &&
                (!specParams.DepartmentId.HasValue || x.DepartmentId == specParams.DepartmentId) &&
                (!specParams.NationalityId.HasValue || x.NationalityId == specParams.NationalityId)
            )
        {
            AddInclude(x => x.Department);
            AddInclude(x => x.Nationality);

            AddOrderByDesc(x => x.FullName);
        }

        public EmployeesWithDepartmetnSpec(int id):base(x=>x.Id==id)
        {
            AddInclude(e => e.Department);
            AddInclude(e => e.Nationality);
        }
    }
}