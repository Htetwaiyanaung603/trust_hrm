using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class _18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Year",
                table: "BonusType",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<long>(
                name: "Amount",
                table: "BonusType",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Year",
                table: "BonusType",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "BonusType",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
