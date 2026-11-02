using Hr.Application.ViewModels.AttendanceVM;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.Interfaces
{
    public interface IAttendanceService
    {
        Task<AttendanceFilterVm> GetAttendanceListAsync(string? search, DateOnly? fromDate, DateOnly? toDate);
        Task<AttendanceFormVm> FillModel(AttendanceFormVm? model = null);

        Task<bool> CreateAttendanceAsync(AttendanceFormVm model);
        Task<bool> UpdateAttendanceAsync(AttendanceFormVm model);
        Task<bool> DeleteAttendanceAsync(int id);
        Task<bool> ImportAttendanceFromExcelAsync(IFormFile file);

    }
}
