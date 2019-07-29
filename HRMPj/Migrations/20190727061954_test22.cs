using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class test22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_LeaveType_LeaveTypeId",
                table: "LeaveRequest");

            migrationBuilder.DropTable(
                name: "EmployeeLeaveInfo");

            migrationBuilder.DropTable(
                name: "LeaveRequestApprovedUser");

            migrationBuilder.DropTable(
                name: "PayRollSetting");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "LeaveType");

            migrationBuilder.DropColumn(
                name: "RunningYear",
                table: "LeaveType");

            migrationBuilder.DropColumn(
                name: "HalfStatus",
                table: "LeaveRequest");

            migrationBuilder.DropColumn(
                name: "PayRollStatus",
                table: "LeaveRequest");

            migrationBuilder.AlterColumn<long>(
                name: "LeaveTypeId",
                table: "LeaveRequest",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<decimal>(
                name: "LeaveTotalDay",
                table: "LeaveRequest",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "FromEmployeeInfoId",
                table: "LeaveRequest",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ToEmployeeInfoId",
                table: "LeaveRequest",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "AttendanceSearchViewModel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceSearchViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequest_FromEmployeeInfoId",
                table: "LeaveRequest",
                column: "FromEmployeeInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequest_ToEmployeeInfoId",
                table: "LeaveRequest",
                column: "ToEmployeeInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_EmployeeInfo_FromEmployeeInfoId",
                table: "LeaveRequest",
                column: "FromEmployeeInfoId",
                principalTable: "EmployeeInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_LeaveType_LeaveTypeId",
                table: "LeaveRequest",
                column: "LeaveTypeId",
                principalTable: "LeaveType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_EmployeeInfo_ToEmployeeInfoId",
                table: "LeaveRequest",
                column: "ToEmployeeInfoId",
                principalTable: "EmployeeInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_EmployeeInfo_FromEmployeeInfoId",
                table: "LeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_LeaveType_LeaveTypeId",
                table: "LeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_EmployeeInfo_ToEmployeeInfoId",
                table: "LeaveRequest");

            migrationBuilder.DropTable(
                name: "AttendanceSearchViewModel");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequest_FromEmployeeInfoId",
                table: "LeaveRequest");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequest_ToEmployeeInfoId",
                table: "LeaveRequest");

            migrationBuilder.DropColumn(
                name: "FromEmployeeInfoId",
                table: "LeaveRequest");

            migrationBuilder.DropColumn(
                name: "ToEmployeeInfoId",
                table: "LeaveRequest");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "LeaveType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RunningYear",
                table: "LeaveType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "LeaveTypeId",
                table: "LeaveRequest",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LeaveTotalDay",
                table: "LeaveRequest",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AddColumn<string>(
                name: "HalfStatus",
                table: "LeaveRequest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayRollStatus",
                table: "LeaveRequest",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeLeaveInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedId = table.Column<string>(nullable: true),
                    EmployeeInfoId = table.Column<long>(nullable: false),
                    LeaveTypeId = table.Column<long>(nullable: false),
                    RemainDay = table.Column<long>(nullable: false),
                    TotalDay = table.Column<long>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "LeaveRequestApprovedUser",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovedBy = table.Column<string>(nullable: true),
                    ApprovedLevel = table.Column<long>(nullable: false),
                    ApprovedStatus = table.Column<string>(nullable: true),
                    LeaveRequestId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequestApprovedUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequestApprovedUser_LeaveRequest_LeaveRequestId",
                        column: x => x.LeaveRequestId,
                        principalTable: "LeaveRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayRollSetting",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Allowance = table.Column<bool>(nullable: false),
                    BasicSalary = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Bonus = table.Column<bool>(nullable: false),
                    Claim = table.Column<bool>(nullable: false),
                    EmployeeInfoId = table.Column<long>(nullable: false),
                    LateDebuct = table.Column<bool>(nullable: false),
                    Loan = table.Column<bool>(nullable: false),
                    OT = table.Column<bool>(nullable: false),
                    Saving = table.Column<bool>(nullable: false),
                    SavingPerMonth = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayRollSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayRollSetting_EmployeeInfo_EmployeeInfoId",
                        column: x => x.EmployeeInfoId,
                        principalTable: "EmployeeInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeaveInfo_EmployeeInfoId",
                table: "EmployeeLeaveInfo",
                column: "EmployeeInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeaveInfo_LeaveTypeId",
                table: "EmployeeLeaveInfo",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestApprovedUser_LeaveRequestId",
                table: "LeaveRequestApprovedUser",
                column: "LeaveRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PayRollSetting_EmployeeInfoId",
                table: "PayRollSetting",
                column: "EmployeeInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_LeaveType_LeaveTypeId",
                table: "LeaveRequest",
                column: "LeaveTypeId",
                principalTable: "LeaveType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
