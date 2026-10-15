    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    #nullable disable

    namespace Hr.Infrastructure.Data.Migrations
    {
        /// <inheritdoc />
        public partial class addNewTables : Migration
        {
            /// <inheritdoc />
            protected override void Up(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.DropForeignKey(
                    name: "FK_AspNetUsers_Role_RoleId",
                    table: "AspNetUsers");

                migrationBuilder.DropForeignKey(
                    name: "FK_Attendance_Employee_EmployeeId",
                    table: "Attendance");

                migrationBuilder.DropForeignKey(
                    name: "FK_Employee_Department_DepartmentId",
                    table: "Employee");

                migrationBuilder.DropForeignKey(
                    name: "FK_Employee_Nationality_NationalityId",
                    table: "Employee");

                migrationBuilder.DropForeignKey(
                    name: "FK_RolePermission_Role_RoleId",
                    table: "RolePermission");

                migrationBuilder.DropPrimaryKey(
                    name: "PK_RolePermission",
                    table: "RolePermission");

                migrationBuilder.DropPrimaryKey(
                    name: "PK_Role",
                    table: "Role");

                migrationBuilder.DropPrimaryKey(
                    name: "PK_Nationality",
                    table: "Nationality");

                migrationBuilder.DropPrimaryKey(
                    name: "PK_Employee",
                    table: "Employee");

                migrationBuilder.DropPrimaryKey(
                    name: "PK_Department",
                    table: "Department");

                migrationBuilder.DropPrimaryKey(
                    name: "PK_Attendance",
                    table: "Attendance");

                migrationBuilder.RenameTable(
                    name: "RolePermission",
                    newName: "RolePermissions");

                migrationBuilder.RenameTable(
                    name: "Role",
                    newName: "Roles");

                migrationBuilder.RenameTable(
                    name: "Nationality",
                    newName: "Nationalities");

                migrationBuilder.RenameTable(
                    name: "Employee",
                    newName: "Employees");

                migrationBuilder.RenameTable(
                    name: "Department",
                    newName: "Departments");

                migrationBuilder.RenameTable(
                    name: "Attendance",
                    newName: "Attendances");

                migrationBuilder.RenameIndex(
                    name: "IX_RolePermission_RoleId",
                    table: "RolePermissions",
                    newName: "IX_RolePermissions_RoleId");

                migrationBuilder.RenameIndex(
                    name: "IX_Employee_NationalityId",
                    table: "Employees",
                    newName: "IX_Employees_NationalityId");

                migrationBuilder.RenameIndex(
                    name: "IX_Employee_NationalId",
                    table: "Employees",
                    newName: "IX_Employees_NationalId");

                migrationBuilder.RenameIndex(
                    name: "IX_Employee_DepartmentId",
                    table: "Employees",
                    newName: "IX_Employees_DepartmentId");

                migrationBuilder.RenameIndex(
                    name: "IX_Department_Name",
                    table: "Departments",
                    newName: "IX_Departments_Name");

                migrationBuilder.RenameIndex(
                    name: "IX_Attendance_EmployeeId",
                    table: "Attendances",
                    newName: "IX_Attendances_EmployeeId");

                migrationBuilder.AddPrimaryKey(
                    name: "PK_RolePermissions",
                    table: "RolePermissions",
                    column: "Id");

                migrationBuilder.AddPrimaryKey(
                    name: "PK_Roles",
                    table: "Roles",
                    column: "Id");

                migrationBuilder.AddPrimaryKey(
                    name: "PK_Nationalities",
                    table: "Nationalities",
                    column: "Id");

                migrationBuilder.AddPrimaryKey(
                    name: "PK_Employees",
                    table: "Employees",
                    column: "Id");

                migrationBuilder.AddPrimaryKey(
                    name: "PK_Departments",
                    table: "Departments",
                    column: "Id");

                migrationBuilder.AddPrimaryKey(
                    name: "PK_Attendances",
                    table: "Attendances",
                    column: "Id");

                migrationBuilder.CreateTable(
                    name: "GeneralSettings",
                    columns: table => new
                    {
                        Id = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        OverTimeVal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                        DeducationVal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                        FirstDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        SecondDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                        LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_GeneralSettings", x => x.Id);
                    });

                migrationBuilder.CreateTable(
                    name: "officialHolidays",
                    columns: table => new
                    {
                        Id = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                        EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                        LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_officialHolidays", x => x.Id);
                    });

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

                migrationBuilder.AddForeignKey(
                    name: "FK_AspNetUsers_Roles_RoleId",
                    table: "AspNetUsers",
                    column: "RoleId",
                    principalTable: "Roles",
                    principalColumn: "Id");

                migrationBuilder.AddForeignKey(
                    name: "FK_Attendances_Employees_EmployeeId",
                    table: "Attendances",
                    column: "EmployeeId",
                    principalTable: "Employees",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);

                migrationBuilder.AddForeignKey(
                    name: "FK_Employees_Departments_DepartmentId",
                    table: "Employees",
                    column: "DepartmentId",
                    principalTable: "Departments",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);

                migrationBuilder.AddForeignKey(
                    name: "FK_Employees_Nationalities_NationalityId",
                    table: "Employees",
                    column: "NationalityId",
                    principalTable: "Nationalities",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);

                migrationBuilder.AddForeignKey(
                    name: "FK_RolePermissions_Roles_RoleId",
                    table: "RolePermissions",
                    column: "RoleId",
                    principalTable: "Roles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            }

            /// <inheritdoc />
            protected override void Down(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.DropForeignKey(
                    name: "FK_AspNetUsers_Roles_RoleId",
                    table: "AspNetUsers");

                migrationBuilder.DropForeignKey(
                    name: "FK_Attendances_Employees_EmployeeId",
                    table: "Attendances");

                migrationBuilder.DropForeignKey(
                    name: "FK_Employees_Departments_DepartmentId",
                    table: "Employees");

                migrationBuilder.DropForeignKey(
                    name: "FK_Employees_Nationalities_NationalityId",
                    table: "Employees");

                migrationBuilder.DropForeignKey(
                    name: "FK_RolePermissions_Roles_RoleId",
                    table: "RolePermissions");

                migrationBuilder.DropTable(
                    name: "GeneralSettings");

                migrationBuilder.DropTable(
                    name: "officialHolidays");

                migrationBuilder.DropPrimaryKey(
                    name: "PK_Roles",
                    table: "Roles");

                migrationBuilder.DropPrimaryKey(
                    name: "PK_RolePermissions",
                    table: "RolePermissions");

                migrationBuilder.DropPrimaryKey(
                    name: "PK_Nationalities",
                    table: "Nationalities");

                migrationBuilder.DropPrimaryKey(
                    name: "PK_Employees",
                    table: "Employees");

                migrationBuilder.DropPrimaryKey(
                    name: "PK_Departments",
                    table: "Departments");

                migrationBuilder.DropPrimaryKey(
                    name: "PK_Attendances",
                    table: "Attendances");

                migrationBuilder.RenameTable(
                    name: "Roles",
                    newName: "Role");

                migrationBuilder.RenameTable(
                    name: "RolePermissions",
                    newName: "RolePermission");

                migrationBuilder.RenameTable(
                    name: "Nationalities",
                    newName: "Nationality");

                migrationBuilder.RenameTable(
                    name: "Employees",
                    newName: "Employee");

                migrationBuilder.RenameTable(
                    name: "Departments",
                    newName: "Department");

                migrationBuilder.RenameTable(
                    name: "Attendances",
                    newName: "Attendance");

                migrationBuilder.RenameIndex(
                    name: "IX_RolePermissions_RoleId",
                    table: "RolePermission",
                    newName: "IX_RolePermission_RoleId");

                migrationBuilder.RenameIndex(
                    name: "IX_Employees_NationalityId",
                    table: "Employee",
                    newName: "IX_Employee_NationalityId");

                migrationBuilder.RenameIndex(
                    name: "IX_Employees_NationalId",
                    table: "Employee",
                    newName: "IX_Employee_NationalId");

                migrationBuilder.RenameIndex(
                    name: "IX_Employees_DepartmentId",
                    table: "Employee",
                    newName: "IX_Employee_DepartmentId");

                migrationBuilder.RenameIndex(
                    name: "IX_Departments_Name",
                    table: "Department",
                    newName: "IX_Department_Name");

                migrationBuilder.RenameIndex(
                    name: "IX_Attendances_EmployeeId",
                    table: "Attendance",
                    newName: "IX_Attendance_EmployeeId");

                migrationBuilder.AddPrimaryKey(
                    name: "PK_Role",
                    table: "Role",
                    column: "Id");

                migrationBuilder.AddPrimaryKey(
                    name: "PK_RolePermission",
                    table: "RolePermission",
                    column: "Id");

                migrationBuilder.AddPrimaryKey(
                    name: "PK_Nationality",
                    table: "Nationality",
                    column: "Id");

                migrationBuilder.AddPrimaryKey(
                    name: "PK_Employee",
                    table: "Employee",
                    column: "Id");

                migrationBuilder.AddPrimaryKey(
                    name: "PK_Department",
                    table: "Department",
                    column: "Id");

                migrationBuilder.AddPrimaryKey(
                    name: "PK_Attendance",
                    table: "Attendance",
                    column: "Id");

                migrationBuilder.UpdateData(
                    table: "Department",
                    keyColumn: "Id",
                    keyValue: 1,
                    column: "CreatedOn",
                    value: new DateTime(2026, 10, 14, 14, 53, 6, 901, DateTimeKind.Local).AddTicks(7618));

                migrationBuilder.UpdateData(
                    table: "Department",
                    keyColumn: "Id",
                    keyValue: 2,
                    column: "CreatedOn",
                    value: new DateTime(2026, 10, 14, 14, 53, 6, 901, DateTimeKind.Local).AddTicks(7666));

                migrationBuilder.UpdateData(
                    table: "Department",
                    keyColumn: "Id",
                    keyValue: 3,
                    column: "CreatedOn",
                    value: new DateTime(2026, 10, 14, 14, 53, 6, 901, DateTimeKind.Local).AddTicks(7668));

                migrationBuilder.UpdateData(
                    table: "Department",
                    keyColumn: "Id",
                    keyValue: 4,
                    column: "CreatedOn",
                    value: new DateTime(2026, 10, 14, 14, 53, 6, 901, DateTimeKind.Local).AddTicks(7670));

                migrationBuilder.UpdateData(
                    table: "Department",
                    keyColumn: "Id",
                    keyValue: 5,
                    column: "CreatedOn",
                    value: new DateTime(2026, 10, 14, 14, 53, 6, 901, DateTimeKind.Local).AddTicks(7672));

                migrationBuilder.UpdateData(
                    table: "Nationality",
                    keyColumn: "Id",
                    keyValue: 1,
                    column: "CreatedOn",
                    value: new DateTime(2026, 10, 14, 14, 53, 6, 907, DateTimeKind.Local).AddTicks(5603));

                migrationBuilder.UpdateData(
                    table: "Nationality",
                    keyColumn: "Id",
                    keyValue: 2,
                    column: "CreatedOn",
                    value: new DateTime(2026, 10, 14, 14, 53, 6, 907, DateTimeKind.Local).AddTicks(5637));

                migrationBuilder.UpdateData(
                    table: "Nationality",
                    keyColumn: "Id",
                    keyValue: 3,
                    column: "CreatedOn",
                    value: new DateTime(2026, 10, 14, 14, 53, 6, 907, DateTimeKind.Local).AddTicks(5640));

                migrationBuilder.UpdateData(
                    table: "Nationality",
                    keyColumn: "Id",
                    keyValue: 4,
                    column: "CreatedOn",
                    value: new DateTime(2026, 10, 14, 14, 53, 6, 907, DateTimeKind.Local).AddTicks(5643));

                migrationBuilder.UpdateData(
                    table: "Nationality",
                    keyColumn: "Id",
                    keyValue: 5,
                    column: "CreatedOn",
                    value: new DateTime(2026, 10, 14, 14, 53, 6, 907, DateTimeKind.Local).AddTicks(5645));

                migrationBuilder.UpdateData(
                    table: "Nationality",
                    keyColumn: "Id",
                    keyValue: 6,
                    column: "CreatedOn",
                    value: new DateTime(2026, 10, 14, 14, 53, 6, 907, DateTimeKind.Local).AddTicks(5647));

                migrationBuilder.UpdateData(
                    table: "Nationality",
                    keyColumn: "Id",
                    keyValue: 7,
                    column: "CreatedOn",
                    value: new DateTime(2026, 10, 14, 14, 53, 6, 907, DateTimeKind.Local).AddTicks(5649));

                migrationBuilder.UpdateData(
                    table: "Nationality",
                    keyColumn: "Id",
                    keyValue: 8,
                    column: "CreatedOn",
                    value: new DateTime(2026, 10, 14, 14, 53, 6, 907, DateTimeKind.Local).AddTicks(5651));

                migrationBuilder.UpdateData(
                    table: "Nationality",
                    keyColumn: "Id",
                    keyValue: 9,
                    column: "CreatedOn",
                    value: new DateTime(2026, 10, 14, 14, 53, 6, 907, DateTimeKind.Local).AddTicks(5652));

                migrationBuilder.UpdateData(
                    table: "Nationality",
                    keyColumn: "Id",
                    keyValue: 10,
                    column: "CreatedOn",
                    value: new DateTime(2026, 10, 14, 14, 53, 6, 907, DateTimeKind.Local).AddTicks(5654));

                migrationBuilder.UpdateData(
                    table: "Nationality",
                    keyColumn: "Id",
                    keyValue: 11,
                    column: "CreatedOn",
                    value: new DateTime(2026, 10, 14, 14, 53, 6, 907, DateTimeKind.Local).AddTicks(5656));

                migrationBuilder.UpdateData(
                    table: "Nationality",
                    keyColumn: "Id",
                    keyValue: 12,
                    column: "CreatedOn",
                    value: new DateTime(2026, 10, 14, 14, 53, 6, 907, DateTimeKind.Local).AddTicks(5658));

                migrationBuilder.UpdateData(
                    table: "Nationality",
                    keyColumn: "Id",
                    keyValue: 13,
                    column: "CreatedOn",
                    value: new DateTime(2026, 10, 14, 14, 53, 6, 907, DateTimeKind.Local).AddTicks(5660));

                migrationBuilder.AddForeignKey(
                    name: "FK_AspNetUsers_Role_RoleId",
                    table: "AspNetUsers",
                    column: "RoleId",
                    principalTable: "Role",
                    principalColumn: "Id");

                migrationBuilder.AddForeignKey(
                    name: "FK_Attendance_Employee_EmployeeId",
                    table: "Attendance",
                    column: "EmployeeId",
                    principalTable: "Employee",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);

                migrationBuilder.AddForeignKey(
                    name: "FK_Employee_Department_DepartmentId",
                    table: "Employee",
                    column: "DepartmentId",
                    principalTable: "Department",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);

                migrationBuilder.AddForeignKey(
                    name: "FK_Employee_Nationality_NationalityId",
                    table: "Employee",
                    column: "NationalityId",
                    principalTable: "Nationality",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);

                migrationBuilder.AddForeignKey(
                    name: "FK_RolePermission_Role_RoleId",
                    table: "RolePermission",
                    column: "RoleId",
                    principalTable: "Role",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            }
        }
    }
