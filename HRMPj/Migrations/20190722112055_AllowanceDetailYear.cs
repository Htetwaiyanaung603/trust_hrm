using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class AllowanceDetailYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Limit",
                table: "OverTimeSetting");

            migrationBuilder.DropColumn(
                name: "MaxRange",
                table: "OverTimeSetting");

            migrationBuilder.RenameColumn(
                name: "MinRange",
                table: "OverTimeSetting",
                newName: "Hour");

            migrationBuilder.AlterColumn<string>(
                name: "Year",
                table: "AllowanceDetail",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hour",
                table: "OverTimeSetting",
                newName: "MinRange");

            migrationBuilder.AddColumn<decimal>(
                name: "Limit",
                table: "OverTimeSetting",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxRange",
                table: "OverTimeSetting",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "AllowanceDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
