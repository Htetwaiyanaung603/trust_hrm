using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class test24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeaveRemainDay",
                table: "LeaveRequest",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeaveRemainDay",
                table: "LeaveRequest");
        }
    }
}
