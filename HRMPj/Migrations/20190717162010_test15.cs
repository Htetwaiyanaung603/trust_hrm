using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class test15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayRoll",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    BasicSalary = table.Column<decimal>(nullable: false),
                    OTFee = table.Column<decimal>(nullable: false),
                    TotalAllowence = table.Column<decimal>(nullable: false),
                    Bonus = table.Column<decimal>(nullable: false),
                    LoanAmount = table.Column<decimal>(nullable: false),
                    LateDebuct = table.Column<decimal>(nullable: false),
                    PenaltyFee = table.Column<decimal>(nullable: false),
                    TaxFee = table.Column<decimal>(nullable: false),
                    Saving = table.Column<decimal>(nullable: false),
                    NetPay = table.Column<decimal>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    PrintStatus = table.Column<string>(nullable: true),
                    Claim = table.Column<string>(nullable: true),
                    EmployeeInfoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayRoll", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayRoll_EmployeeInfo_EmployeeInfoId",
                        column: x => x.EmployeeInfoId,
                        principalTable: "EmployeeInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayRoll_EmployeeInfoId",
                table: "PayRoll",
                column: "EmployeeInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayRoll");
        }
    }
}
