using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class test13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bonus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<DateTime>(nullable: false),
                    Month = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    EmployeeInfoId = table.Column<long>(nullable: false),
                    BonusTypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bonus_BonusType_BonusTypeId",
                        column: x => x.BonusTypeId,
                        principalTable: "BonusType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bonus_EmployeeInfo_EmployeeInfoId",
                        column: x => x.EmployeeInfoId,
                        principalTable: "EmployeeInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bonus_BonusTypeId",
                table: "Bonus",
                column: "BonusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bonus_EmployeeInfoId",
                table: "Bonus",
                column: "EmployeeInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bonus");
        }
    }
}
