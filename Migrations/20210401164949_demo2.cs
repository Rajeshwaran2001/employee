using Microsoft.EntityFrameworkCore.Migrations;

namespace employee.Migrations
{
    public partial class demo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTable1",
                table: "EmployeeTable1");

            migrationBuilder.RenameTable(
                name: "EmployeeTable1",
                newName: "EmployeeTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTable",
                table: "EmployeeTable",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTable",
                table: "EmployeeTable");

            migrationBuilder.RenameTable(
                name: "EmployeeTable",
                newName: "EmployeeTable1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTable1",
                table: "EmployeeTable1",
                column: "EmployeeId");
        }
    }
}
