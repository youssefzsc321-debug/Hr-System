using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hr.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class putIndexOnPhoneNumberAndNationalId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 10, 11, 9, 308, DateTimeKind.Local).AddTicks(5351));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 10, 11, 9, 308, DateTimeKind.Local).AddTicks(5406));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 10, 11, 9, 308, DateTimeKind.Local).AddTicks(5408));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 10, 11, 9, 308, DateTimeKind.Local).AddTicks(5410));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 10, 11, 9, 308, DateTimeKind.Local).AddTicks(5413));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 10, 11, 9, 314, DateTimeKind.Local).AddTicks(1934));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 10, 11, 9, 314, DateTimeKind.Local).AddTicks(1995));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 10, 11, 9, 314, DateTimeKind.Local).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 10, 11, 9, 314, DateTimeKind.Local).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 10, 11, 9, 314, DateTimeKind.Local).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 10, 11, 9, 314, DateTimeKind.Local).AddTicks(2005));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 10, 11, 9, 314, DateTimeKind.Local).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 10, 11, 9, 314, DateTimeKind.Local).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 10, 11, 9, 314, DateTimeKind.Local).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 10, 11, 9, 314, DateTimeKind.Local).AddTicks(2014));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 10, 11, 9, 314, DateTimeKind.Local).AddTicks(2017));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 10, 11, 9, 314, DateTimeKind.Local).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 10, 11, 9, 314, DateTimeKind.Local).AddTicks(2021));

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PhoneNumber",
                table: "Employees",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_PhoneNumber",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 9, 38, 7, 757, DateTimeKind.Local).AddTicks(9633));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 9, 38, 7, 757, DateTimeKind.Local).AddTicks(9683));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 9, 38, 7, 757, DateTimeKind.Local).AddTicks(9685));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 9, 38, 7, 757, DateTimeKind.Local).AddTicks(9687));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 9, 38, 7, 757, DateTimeKind.Local).AddTicks(9689));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 9, 38, 7, 761, DateTimeKind.Local).AddTicks(7053));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 9, 38, 7, 761, DateTimeKind.Local).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 9, 38, 7, 761, DateTimeKind.Local).AddTicks(7095));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 9, 38, 7, 761, DateTimeKind.Local).AddTicks(7097));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 9, 38, 7, 761, DateTimeKind.Local).AddTicks(7099));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 9, 38, 7, 761, DateTimeKind.Local).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 9, 38, 7, 761, DateTimeKind.Local).AddTicks(7102));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 9, 38, 7, 761, DateTimeKind.Local).AddTicks(7104));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 9, 38, 7, 761, DateTimeKind.Local).AddTicks(7105));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 9, 38, 7, 761, DateTimeKind.Local).AddTicks(7107));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 9, 38, 7, 761, DateTimeKind.Local).AddTicks(7109));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 9, 38, 7, 761, DateTimeKind.Local).AddTicks(7111));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 2, 9, 38, 7, 761, DateTimeKind.Local).AddTicks(7112));
        }
    }
}
