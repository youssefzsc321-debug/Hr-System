using AutoMapper;
using ClosedXML.Excel;
using Hr.Application.Interfaces;
using Hr.Application.Repositories;
using Hr.Application.ViewModels.AttendanceVM;
using Hr.Domain.Entites;
using Hr.Infrastructure.Repositories;
using Hr.Infrastructure.Specifications.AttendanceSpec;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hr.Infrastructure.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWorkRepo _unitOfWork;
        private readonly IMapper _mapper;

        public AttendanceService(IUnitOfWorkRepo unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateAttendanceAsync(AttendanceFormVm model)
        {
            var attendance = _mapper.Map<Attendance>(model);

            await _unitOfWork.Attendances.AddAsync(attendance);
            attendance.CreatedOn = DateTime.Now;
            var result = await _unitOfWork.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            var attendance = await _unitOfWork.Attendances.GetByIdAsync(id);
            if (attendance == null) return false;

            _unitOfWork.Attendances.Delete(attendance);
            var result = await _unitOfWork.SaveChangesAsync();

            return result > 0;
        }

        public async Task<AttendanceFormVm> FillModel(AttendanceFormVm? model = null)
        {
            model ??= new AttendanceFormVm();

            var employees = await _unitOfWork.Employees.GetAllAsync();

            model.Employees = employees.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.FullName
            }).ToList();

            return model;
        }

        public async Task<AttendanceFilterVm> GetAttendanceListAsync(string? search, DateOnly? fromDate, DateOnly? toDate)
        {
            var spec = new AttendanceWithEmployeeSpec(search, fromDate, toDate);
            var attendaces = await _unitOfWork.Attendances.GetAllAsyncWithSpec(spec);
            var attendanceVm = _mapper.Map<IEnumerable<AttendanceVm>>(attendaces);

            var modelVm = new AttendanceFilterVm()
            {
                Attendances = attendanceVm,
                FromDate = fromDate,
                ToDate = toDate,
                SearchTerm = search
            };
            return modelVm;
        }

        public async Task<bool> ImportAttendanceFromExcelAsync(IFormFile file)
        {
            if (file == null || file.Length == 0) return false;

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var workbook = new XLWorkbook(stream))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RowsUsed().Skip(1);

                    foreach (var row in rows)
                    {
                        if (!int.TryParse(row.Cell(1).Value.ToString(), out var employeeId))
                            continue; 

                        var dateCell = row.Cell(2);
                        DateOnly date;
                        if (dateCell.DataType == XLDataType.DateTime)
                        {
                            date = DateOnly.FromDateTime(dateCell.GetDateTime());
                        }
                        else
                        {
                            if (!DateOnly.TryParse(dateCell.Value.ToString(), out date))
                                continue;
                        }

                        var checkInCell = row.Cell(3);
                        TimeOnly checkIn;
                        if (checkInCell.DataType == XLDataType.DateTime)
                        {
                            checkIn = TimeOnly.FromDateTime(checkInCell.GetDateTime());
                        }
                        else
                        {
                            if (!TimeOnly.TryParse(checkInCell.Value.ToString(), out checkIn))
                                continue;
                        }

                        TimeOnly? checkOut = null;
                        var checkOutCell = row.Cell(4);
                        if (!checkOutCell.IsEmpty())
                        {
                            if (checkOutCell.DataType == XLDataType.DateTime)
                            {
                                checkOut = TimeOnly.FromDateTime(checkOutCell.GetDateTime());
                            }
                            else if (TimeOnly.TryParse(checkOutCell.Value.ToString(), out var parsedCheckout))
                            {
                                checkOut = parsedCheckout;
                            }
                        }

                        var attendance = new Attendance
                        {
                            EmployeeId = employeeId,
                            Date = date,
                            CheckIn = checkIn,
                            CheckOut = checkOut,
                            CreatedOn = DateTime.Now
                        };

                        await _unitOfWork.Attendances.AddAsync(attendance);
                    }

                    await _unitOfWork.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<bool> UpdateAttendanceAsync(AttendanceFormVm model)
        {
            var attendance = await _unitOfWork.Attendances.GetByIdAsync(model.Id);
            if (attendance == null) return false;

            _mapper.Map(model, attendance);

            _unitOfWork.Attendances.Update(attendance);
            attendance.LastUpdatedOn= DateTime.UtcNow;  
            var result = await _unitOfWork.SaveChangesAsync();

            return result > 0;
        }
    }

}
