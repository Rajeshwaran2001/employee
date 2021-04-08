using Microsoft.EntityFrameworkCore.Migrations;

namespace employee.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "EmployeeTable",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNo",
                table: "EmployeeTable",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "EmployeeTable");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "EmployeeTable");
        }
    }
}
