using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class _17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "AllowancdType");

            migrationBuilder.AlterColumn<string>(
                name: "Year",
                table: "PayRoll",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Month",
                table: "PayRoll",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Hour",
                table: "OverTimeSetting",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "OverTime",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "OverTime");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "PayRoll",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Month",
                table: "PayRoll",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Hour",
                table: "OverTimeSetting",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "AllowancdType",
                nullable: false,
                defaultValue: 0);
        }
    }
}
