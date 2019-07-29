using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class UpdatePayroll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Claim",
                table: "PayRoll");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tax",
                table: "PayRollSetting",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<bool>(
                name: "PrintStatus",
                table: "PayRoll",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Tax",
                table: "PayRollSetting",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AlterColumn<string>(
                name: "PrintStatus",
                table: "PayRoll",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<string>(
                name: "Claim",
                table: "PayRoll",
                nullable: true);
        }
    }
}
