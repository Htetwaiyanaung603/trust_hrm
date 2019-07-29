using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeInfo_Branch_BranchId",
                table: "EmployeeInfo");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeInfo_Branch_BranchId",
                table: "EmployeeInfo",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeInfo_Branch_BranchId",
                table: "EmployeeInfo");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeInfo_Branch_BranchId",
                table: "EmployeeInfo",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
