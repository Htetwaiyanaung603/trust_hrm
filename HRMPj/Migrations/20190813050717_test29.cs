using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class test29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remark",
                table: "Resign");

            migrationBuilder.DropColumn(
                name: "ResignStatus",
                table: "Resign");

            migrationBuilder.AlterColumn<string>(
                name: "MobilePhone",
                table: "EmployeeInfo",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "EmergencyNo",
                table: "EmployeeInfo",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "AccountNo",
                table: "EmployeeInfo",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "ATMNumber",
                table: "EmployeeInfo",
                nullable: true,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "Resign",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResignStatus",
                table: "Resign",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MobilePhone",
                table: "EmployeeInfo",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "EmergencyNo",
                table: "EmployeeInfo",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AccountNo",
                table: "EmployeeInfo",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ATMNumber",
                table: "EmployeeInfo",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
