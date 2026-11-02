using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hr.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class editOnAttendance2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Attendances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 59, 28, 17, DateTimeKind.Local).AddTicks(4792));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 59, 28, 17, DateTimeKind.Local).AddTicks(4839));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 59, 28, 17, DateTimeKind.Local).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 59, 28, 17, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 59, 28, 17, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 59, 28, 21, DateTimeKind.Local).AddTicks(924));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 59, 28, 21, DateTimeKind.Local).AddTicks(957));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 59, 28, 21, DateTimeKind.Local).AddTicks(960));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 59, 28, 21, DateTimeKind.Local).AddTicks(962));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 59, 28, 21, DateTimeKind.Local).AddTicks(964));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 59, 28, 21, DateTimeKind.Local).AddTicks(966));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 59, 28, 21, DateTimeKind.Local).AddTicks(968));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 59, 28, 21, DateTimeKind.Local).AddTicks(970));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 59, 28, 21, DateTimeKind.Local).AddTicks(972));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 59, 28, 21, DateTimeKind.Local).AddTicks(973));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 59, 28, 21, DateTimeKind.Local).AddTicks(975));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 59, 28, 21, DateTimeKind.Local).AddTicks(977));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 59, 28, 21, DateTimeKind.Local).AddTicks(979));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Attendances");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 44, 41, 727, DateTimeKind.Local).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 44, 41, 727, DateTimeKind.Local).AddTicks(7979));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 44, 41, 727, DateTimeKind.Local).AddTicks(7981));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 44, 41, 727, DateTimeKind.Local).AddTicks(7983));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 44, 41, 727, DateTimeKind.Local).AddTicks(7985));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 44, 41, 731, DateTimeKind.Local).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 44, 41, 731, DateTimeKind.Local).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 44, 41, 731, DateTimeKind.Local).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 44, 41, 731, DateTimeKind.Local).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 44, 41, 731, DateTimeKind.Local).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 44, 41, 731, DateTimeKind.Local).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 44, 41, 731, DateTimeKind.Local).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 44, 41, 731, DateTimeKind.Local).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 44, 41, 731, DateTimeKind.Local).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 44, 41, 731, DateTimeKind.Local).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 44, 41, 731, DateTimeKind.Local).AddTicks(4572));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 44, 41, 731, DateTimeKind.Local).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 1, 9, 44, 41, 731, DateTimeKind.Local).AddTicks(4576));
        }
    }
}
