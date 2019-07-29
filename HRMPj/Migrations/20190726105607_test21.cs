using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class test21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                table: "Attendance",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DepartmentId",
                table: "Attendance",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "SearchViewModel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: false),
                    AttendanceDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchViewModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchViewModel");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Attendance");
        }
    }
}
