using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hr.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addIsDeletedColunmToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 52, 35, 419, DateTimeKind.Local).AddTicks(9014));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 52, 35, 419, DateTimeKind.Local).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 52, 35, 419, DateTimeKind.Local).AddTicks(9062));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 52, 35, 419, DateTimeKind.Local).AddTicks(9064));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 52, 35, 419, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 52, 35, 423, DateTimeKind.Local).AddTicks(4800));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 52, 35, 423, DateTimeKind.Local).AddTicks(4828));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 52, 35, 423, DateTimeKind.Local).AddTicks(4830));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 52, 35, 423, DateTimeKind.Local).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 52, 35, 423, DateTimeKind.Local).AddTicks(4834));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 52, 35, 423, DateTimeKind.Local).AddTicks(4836));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 52, 35, 423, DateTimeKind.Local).AddTicks(4838));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 52, 35, 423, DateTimeKind.Local).AddTicks(4839));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 52, 35, 423, DateTimeKind.Local).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 52, 35, 423, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 52, 35, 423, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 52, 35, 423, DateTimeKind.Local).AddTicks(4847));

            migrationBuilder.UpdateData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2026, 10, 21, 15, 52, 35, 423, DateTimeKind.Local).AddTicks(4848));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

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
    }
}
