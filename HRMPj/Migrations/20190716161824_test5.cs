using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OverTime",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OTDate = table.Column<DateTime>(nullable: false),
                    OTStartTime = table.Column<DateTime>(nullable: false),
                    OTEndTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: false),
                    OTTime = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    FromEmployeeInfoId = table.Column<long>(nullable: false),
                    ToEmployeeInfoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverTime_EmployeeInfo_FromEmployeeInfoId",
                        column: x => x.FromEmployeeInfoId,
                        principalTable: "EmployeeInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OverTime_EmployeeInfo_ToEmployeeInfoId",
                        column: x => x.ToEmployeeInfoId,
                        principalTable: "EmployeeInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OverTime_FromEmployeeInfoId",
                table: "OverTime",
                column: "FromEmployeeInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_OverTime_ToEmployeeInfoId",
                table: "OverTime",
                column: "ToEmployeeInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OverTime");
        }
    }
}
