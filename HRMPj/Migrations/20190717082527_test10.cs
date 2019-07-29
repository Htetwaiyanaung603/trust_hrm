using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class test10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeLeaveInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    TotalDay = table.Column<long>(nullable: false),
                    RemainDay = table.Column<long>(nullable: false),
                    CreatedId = table.Column<string>(nullable: true),
                    LeaveTypeId = table.Column<long>(nullable: false),
                    EmployeeInfoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLeaveInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeLeaveInfo_EmployeeInfo_EmployeeInfoId",
                        column: x => x.EmployeeInfoId,
                        principalTable: "EmployeeInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLeaveInfo_LeaveType_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeaveInfo_EmployeeInfoId",
                table: "EmployeeLeaveInfo",
                column: "EmployeeInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeaveInfo_LeaveTypeId",
                table: "EmployeeLeaveInfo",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeLeaveInfo");
        }
    }
}
