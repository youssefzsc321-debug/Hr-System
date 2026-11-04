using ClosedXML.Excel;
using Hr.Application.Interfaces;
using Hr.Application.Repositories;
using Hr.Application.ViewModels.EmployeeReports;
using Hr.Application.ViewModels.EmployeesVM;
using Hr.Infrastructure.Specifications.AttendanceSpec;
using Hr.Infrastructure.Specifications.EmployeesSpec;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Infrastructure.Services
{
    public class SalaryReportService : ISalaryReportService
    {
        private readonly IUnitOfWorkRepo _unitOfWorkRepo;

        public SalaryReportService(IUnitOfWorkRepo unitOfWorkRepo)
        {
            _unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<SalaryReportFilterVm> GetSalaryReportAsync(string? employeeName, int? year, int? month)
        {
            int targetMonth = month ?? DateTime.Now.Month;
            int targetYear = year ?? DateTime.Now.Year;

            var generalSettings = await _unitOfWorkRepo.GeneralSettings.GetByIdAsync(1);
            decimal overtimeRate = generalSettings?.OverTimeVal ?? 0;
            decimal deductionRate = generalSettings?.DeducationVal ?? 0;

            var employeeParams = new EmployeeSepcParams() { Search = employeeName };
            var employeeSpec = new EmployeesWithDepartmetnSpec(employeeParams);
            var employees = await _unitOfWorkRepo.Employees.GetAllAsyncWithSpec(employeeSpec);

            var reportList = new List<EmployeeSalaryReportVm>();

            foreach (var emp in employees)
            {
                var attendanceSpec = new AttendanceFilterSpec(emp.Id, targetYear, targetMonth);
                var attendances = await _unitOfWorkRepo.Attendances.GetAllAsyncWithSpec(attendanceSpec);

                int daysPresent = attendances.Count();
                int totalDaysInMonth = DateTime.DaysInMonth(targetYear, targetMonth);
                int daysAbsent = totalDaysInMonth - daysPresent;
                if (daysAbsent < 0) daysAbsent = 0;

                decimal basicSalary = emp.Salary;

                double totalDelayMinutes = 0;
                double totalOvertimeMinutes = 0;

                foreach (var att in attendances)
                {
                    if (att.CheckIn > emp.DefaultCheckIn)
                    {
                        var delay = att.CheckIn - emp.DefaultCheckIn;
                        totalDelayMinutes += delay.TotalMinutes;
                    }

                    if (att.CheckOut.HasValue && att.CheckOut > emp.DefaultCheckOut)
                    {
                        var overtime = att.CheckOut.Value - emp.DefaultCheckOut;
                        totalOvertimeMinutes += overtime.TotalMinutes;
                    }
                }

                double totalDelayHours = Math.Round(totalDelayMinutes / 60.0, 2);
                double totalOvertimeHours = Math.Round(totalOvertimeMinutes / 60.0, 2);

                decimal dayRate = basicSalary > 0 ? basicSalary / totalDaysInMonth : 0;
                decimal absenceDeduction = daysAbsent * dayRate;
                decimal delayDeduction = (decimal)totalDelayHours * deductionRate;

                decimal totalDeduction = absenceDeduction + delayDeduction;
                decimal totalOvertime = (decimal)totalOvertimeHours * overtimeRate;

                decimal netSalary = basicSalary + totalOvertime - totalDeduction;
                if (netSalary < 0) netSalary = 0;

                reportList.Add(new EmployeeSalaryReportVm
                {
                    EmployeeId = emp.Id,
                    EmployeeName = emp.FullName,
                    DepartmentName = emp.Department?.Name ?? "N/A",
                    BasicSalary = basicSalary,
                    DaysPresent = daysPresent,
                    DaysAbsent = daysAbsent,
                    OvertimeHours = totalOvertimeHours,
                    DeductionHours = totalDelayHours,
                    TotalOvertime = totalOvertime,
                    TotalDeduction = totalDeduction,
                    NetSalary = netSalary
                });
            }

            var model = new SalaryReportFilterVm
            {
                SearchTerm = employeeName,
                Month = targetMonth,
                Year = targetYear,
                ReportRecords = reportList
            };

            return model;
        }

        public async Task<byte[]> ExportSalaryToExcelAsync(string? employeeName, int? month, int? year)
        {
            var report = await GetSalaryReportAsync(employeeName, year, month);

            using var workbook = new XLWorkbook();
            var sheet = workbook.AddWorksheet("Salary Report");
            sheet.RightToLeft = false;

            sheet.Cell(1, 1).Value = "Employee Name";
            sheet.Cell(1, 2).Value = "Department";
            sheet.Cell(1, 3).Value = "Basic Salary";
            sheet.Cell(1, 4).Value = "Attendance (Days)";
            sheet.Cell(1, 5).Value = "Absence (Days)";
            sheet.Cell(1, 6).Value = "Overtime (Hrs)";
            sheet.Cell(1, 7).Value = "Deduction (Hrs)";
            sheet.Cell(1, 8).Value = "Total Overtime";
            sheet.Cell(1, 9).Value = "Total Deduction";
            sheet.Cell(1, 10).Value = "Net Salary";

            var headerRange = sheet.Range("A1:J1");
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Font.FontColor = XLColor.White;
            headerRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#1B84FF");
            headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            sheet.Row(1).Height = 25;

            int row = 2;
            foreach (var item in report.ReportRecords)
            {
                sheet.Cell(row, 1).Value = item.EmployeeName;
                sheet.Cell(row, 2).Value = item.DepartmentName;
                sheet.Cell(row, 3).Value = $"{item.BasicSalary:N2} EGP";
                sheet.Cell(row, 4).Value = item.DaysPresent;
                sheet.Cell(row, 5).Value = item.DaysAbsent;
                sheet.Cell(row, 6).Value = item.OvertimeHours;
                sheet.Cell(row, 7).Value = item.DeductionHours;
                sheet.Cell(row, 8).Value = $"+ {item.TotalOvertime:N2} EGP";
                sheet.Cell(row, 9).Value = $"- {item.TotalDeduction:N2} EGP";
                sheet.Cell(row, 10).Value = $"{item.NetSalary:N2} EGP";

                sheet.Cell(row, 8).Style.Font.FontColor = XLColor.Green;
                sheet.Cell(row, 9).Style.Font.FontColor = XLColor.Red;
                sheet.Cell(row, 10).Style.Font.Bold = true;
                sheet.Cell(row, 10).Style.Font.FontColor = XLColor.Green;

                row++;
            }

            sheet.Columns().AdjustToContents();
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        public async Task<byte[]> ExportSalaryToPDFAsync(string? employeeName, int? month, int? year)
        {
            var report = await GetSalaryReportAsync(employeeName, year, month);

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(1.2f, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(9).FontFamily("Arial"));

                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text($"HR System - Salary Report ({report.Month}/{report.Year})").FontSize(20).Bold().FontColor("#1B84FF");
                            col.Item().Text($"Generated Date: {DateTime.Now:yyyy-MM-dd HH:mm}").FontSize(9).FontColor(Colors.Grey.Medium);
                        });
                    });

                    page.Content().PaddingVertical(15).Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(2.5f);
                            columns.RelativeColumn(2f);
                            columns.RelativeColumn(1.5f);
                            columns.RelativeColumn(1.2f);
                            columns.RelativeColumn(1.2f);
                            columns.RelativeColumn(1.3f);
                            columns.RelativeColumn(1.3f);
                            columns.RelativeColumn(1.6f);
                            columns.RelativeColumn(1.6f);
                            columns.RelativeColumn(1.8f);
                        });

                        table.Header(header =>
                        {
                            string[] headers = { "Employee", "Department", "Basic Salary", "Present", "Absent", "OT (Hrs)", "Ded. (Hrs)", "Total OT", "Total Ded.", "Net Salary" };
                            foreach (var h in headers)
                            {
                                header.Cell().Background("#1B84FF").Padding(5).Text(h).FontColor(Colors.White).Bold();
                            }
                        });

                        foreach (var item in report.ReportRecords)
                        {
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(item.EmployeeName).Bold();
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(item.DepartmentName);
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5).Text($"{item.BasicSalary:N2}");
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5).Text($"{item.DaysPresent} Days");
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5).Text($"{item.DaysAbsent} Days");
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5).Text($"{item.OvertimeHours} Hrs");
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5).Text($"{item.DeductionHours} Hrs");
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5).Text($"+{item.TotalOvertime:N2}").FontColor(Colors.Green.Medium).Bold();
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5).Text($"-{item.TotalDeduction:N2}").FontColor(Colors.Red.Medium).Bold();
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5).Text($"{item.NetSalary:N2} EGP").FontColor("#1B84FF").Bold();
                        }
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Page ");
                        x.CurrentPageNumber();
                        x.Span(" of ");
                        x.TotalPages();
                    });
                });
            });

            using var stream = new MemoryStream();
            document.GeneratePdf(stream);
            return stream.ToArray();
        }

        public async Task<byte[]> ExportEmployeePayslipToExcelAsync(int employeeId, int month, int year)
        {
            var report = await GetSalaryReportAsync(null, year, month);
            var emp = report.ReportRecords.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (emp == null) throw new Exception("Employee not found");

            using var workbook = new XLWorkbook();
            var sheet = workbook.AddWorksheet("Payslip");

            sheet.Cell(1, 1).Value = "Field";
            sheet.Cell(1, 2).Value = "Details";
            sheet.Range("A1:B1").Style.Font.Bold = true;
            sheet.Range("A1:B1").Style.Fill.BackgroundColor = XLColor.FromHtml("#1B84FF");
            sheet.Range("A1:B1").Style.Font.FontColor = XLColor.White;

            var rows = new (string Field, string Value)[]
            {
                ("Employee Name", emp.EmployeeName),
                ("Department", emp.DepartmentName),
                ("Period", $"{month} / {year}"),
                ("Basic Salary", $"{emp.BasicSalary:N2} EGP"),
                ("Attendance Days", $"{emp.DaysPresent} Days"),
                ("Absence Days", $"{emp.DaysAbsent} Days"),
                ("Overtime Hours", $"{emp.OvertimeHours} Hrs"),
                ("Deduction Hours", $"{emp.DeductionHours} Hrs"),
                ("Total Overtime", $"+ {emp.TotalOvertime:N2} EGP"),
                ("Total Deduction", $"- {emp.TotalDeduction:N2} EGP"),
                ("Net Salary", $"{emp.NetSalary:N2} EGP")
            };

            int r = 2;
            foreach (var item in rows)
            {
                sheet.Cell(r, 1).Value = item.Field;
                sheet.Cell(r, 2).Value = item.Value;
                r++;
            }

            sheet.Columns().AdjustToContents();
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        public async Task<byte[]> ExportEmployeePayslipToPDFAsync(int employeeId, int month, int year)
        {
            var report = await GetSalaryReportAsync(null, year, month);
            var emp = report.ReportRecords.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (emp == null) throw new Exception("Employee not found");

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A5);
                    page.Margin(1.2f, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial"));

                    page.Header().Column(col =>
                    {
                        col.Item().Text("HR System - Salary Payslip").FontSize(18).Bold().FontColor("#1B84FF");
                        col.Item().Text($"Period: {month}/{year} | Generated: {DateTime.Now:yyyy-MM-dd HH:mm}").FontSize(8).FontColor(Colors.Grey.Medium);
                    });

                    page.Content().PaddingVertical(12).Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(1.5f);
                            columns.RelativeColumn(2f);
                        });

                        void AddRow(string label, string val, string? color = null, bool isBold = false)
                        {
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(6).Text(label).Bold();
                            var valCell = table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(6).AlignRight().Text(val);
                            if (color != null) valCell.FontColor(color);
                            if (isBold) valCell.Bold();
                        }

                        AddRow("Employee Name", emp.EmployeeName, isBold: true);
                        AddRow("Department", emp.DepartmentName);
                        AddRow("Basic Salary", $"{emp.BasicSalary:N2} EGP");
                        AddRow("Attendance Days", $"{emp.DaysPresent} Days", Colors.Green.Medium);
                        AddRow("Absence Days", $"{emp.DaysAbsent} Days", Colors.Red.Medium);
                        AddRow("Overtime Hours", $"{emp.OvertimeHours} Hrs");
                        AddRow("Deduction Hours", $"{emp.DeductionHours} Hrs");
                        AddRow("Total Overtime", $"+ {emp.TotalOvertime:N2} EGP", Colors.Green.Medium, true);
                        AddRow("Total Deduction", $"- {emp.TotalDeduction:N2} EGP", Colors.Red.Medium, true);
                        AddRow("Net Salary", $"{emp.NetSalary:N2} EGP", "#1B84FF", true);
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Page ");
                        x.CurrentPageNumber();
                    });
                });
            });

            using var stream = new MemoryStream();
            document.GeneratePdf(stream);
            return stream.ToArray();
        }
    }
}