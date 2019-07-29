using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class test8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequest",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrentYear = table.Column<long>(nullable: false),
                    LeaveFromDate = table.Column<DateTime>(nullable: false),
                    LeaveToDate = table.Column<DateTime>(nullable: false),
                    LeaveTotalDay = table.Column<long>(nullable: false),
                    HalfDay = table.Column<string>(nullable: true),
                    HalfStatus = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UnPaidLeaveStatus = table.Column<string>(nullable: true),
                    PayRollStatus = table.Column<string>(nullable: true),
                    LeaveTypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequest_LeaveType_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequest_LeaveTypeId",
                table: "LeaveRequest",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequest");
        }
    }
}
