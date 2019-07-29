using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllowanceDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Month = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    AllowanceTypeId = table.Column<long>(nullable: false),
                    EmployeeInfoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllowanceDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllowanceDetail_AllowancdType_AllowanceTypeId",
                        column: x => x.AllowanceTypeId,
                        principalTable: "AllowancdType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllowanceDetail_EmployeeInfo_EmployeeInfoId",
                        column: x => x.EmployeeInfoId,
                        principalTable: "EmployeeInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllowanceDetail_AllowanceTypeId",
                table: "AllowanceDetail",
                column: "AllowanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AllowanceDetail_EmployeeInfoId",
                table: "AllowanceDetail",
                column: "EmployeeInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllowanceDetail");
        }
    }
}
