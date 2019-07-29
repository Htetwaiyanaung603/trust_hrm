using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class test16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayRollSetting",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OT = table.Column<bool>(nullable: false),
                    Bonus = table.Column<bool>(nullable: false),
                    LateDebuct = table.Column<bool>(nullable: false),
                    Tax = table.Column<float>(nullable: false),
                    Allowance = table.Column<bool>(nullable: false),
                    Saving = table.Column<bool>(nullable: false),
                    Claim = table.Column<bool>(nullable: false),
                    BasicSalary = table.Column<decimal>(nullable: false),
                    Loan = table.Column<bool>(nullable: false),
                    SavingPerMonth = table.Column<decimal>(nullable: false),
                    EmployeeInfoId = table.Column<long>(nullable: false)
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
                name: "IX_PayRollSetting_EmployeeInfoId",
                table: "PayRollSetting",
                column: "EmployeeInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayRollSetting");
        }
    }
}
