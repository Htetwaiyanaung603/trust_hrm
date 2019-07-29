using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class test14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resign",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResignDate = table.Column<DateTime>(nullable: false),
                    ResignStatus = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Remark = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ApprovedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Year = table.Column<long>(nullable: false),
                    EmployeeInfoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resign_EmployeeInfo_EmployeeInfoId",
                        column: x => x.EmployeeInfoId,
                        principalTable: "EmployeeInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resign_EmployeeInfoId",
                table: "Resign",
                column: "EmployeeInfoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resign");
        }
    }
}
