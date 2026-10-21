using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hr.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addColumnsInAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedById",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 21, 30, 925, DateTimeKind.Local).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 21, 30, 925, DateTimeKind.Local).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 21, 30, 925, DateTimeKind.Local).AddTicks(4981));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 21, 30, 925, DateTimeKind.Local).AddTicks(4983));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 21, 30, 925, DateTimeKind.Local).AddTicks(4985));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 21, 30, 929, DateTimeKind.Local).AddTicks(3939));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 21, 30, 929, DateTimeKind.Local).AddTicks(3974));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 21, 30, 929, DateTimeKind.Local).AddTicks(3976));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 21, 30, 929, DateTimeKind.Local).AddTicks(3978));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 21, 30, 929, DateTimeKind.Local).AddTicks(3980));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 21, 30, 929, DateTimeKind.Local).AddTicks(3982));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 21, 30, 929, DateTimeKind.Local).AddTicks(3984));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 21, 30, 929, DateTimeKind.Local).AddTicks(3986));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 21, 30, 929, DateTimeKind.Local).AddTicks(3988));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 21, 30, 929, DateTimeKind.Local).AddTicks(3990));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 21, 30, 929, DateTimeKind.Local).AddTicks(3991));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 21, 30, 929, DateTimeKind.Local).AddTicks(3993));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 21, 30, 929, DateTimeKind.Local).AddTicks(3995));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOn",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 15, 10, 53, 28, 845, DateTimeKind.Local).AddTicks(461));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 15, 10, 53, 28, 845, DateTimeKind.Local).AddTicks(504));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 15, 10, 53, 28, 845, DateTimeKind.Local).AddTicks(507));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 15, 10, 53, 28, 845, DateTimeKind.Local).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 15, 10, 53, 28, 845, DateTimeKind.Local).AddTicks(511));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 15, 10, 53, 28, 848, DateTimeKind.Local).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 15, 10, 53, 28, 848, DateTimeKind.Local).AddTicks(7575));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 15, 10, 53, 28, 848, DateTimeKind.Local).AddTicks(7577));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 15, 10, 53, 28, 848, DateTimeKind.Local).AddTicks(7579));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 15, 10, 53, 28, 848, DateTimeKind.Local).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 15, 10, 53, 28, 848, DateTimeKind.Local).AddTicks(7583));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 15, 10, 53, 28, 848, DateTimeKind.Local).AddTicks(7585));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 15, 10, 53, 28, 848, DateTimeKind.Local).AddTicks(7587));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 15, 10, 53, 28, 848, DateTimeKind.Local).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 15, 10, 53, 28, 848, DateTimeKind.Local).AddTicks(7591));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 15, 10, 53, 28, 848, DateTimeKind.Local).AddTicks(7593));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 15, 10, 53, 28, 848, DateTimeKind.Local).AddTicks(7595));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 15, 10, 53, 28, 848, DateTimeKind.Local).AddTicks(7596));
        }
    }
}
