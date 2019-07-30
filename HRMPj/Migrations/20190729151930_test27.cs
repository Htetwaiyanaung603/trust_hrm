using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class test27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LateDebuct",
                table: "PayRoll");

            migrationBuilder.DropColumn(
                name: "LoanAmount",
                table: "PayRoll");

            migrationBuilder.DropColumn(
                name: "PrintStatus",
                table: "PayRoll");

            migrationBuilder.DropColumn(
                name: "Saving",
                table: "PayRoll");

            migrationBuilder.DropColumn(
                name: "TaxFee",
                table: "PayRoll");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LateDebuct",
                table: "PayRoll",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LoanAmount",
                table: "PayRoll",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "PrintStatus",
                table: "PayRoll",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Saving",
                table: "PayRoll",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxFee",
                table: "PayRoll",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
