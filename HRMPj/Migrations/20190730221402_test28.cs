using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class test28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resign_EmployeeInfo_EmployeeInfoId",
                table: "Resign");

            migrationBuilder.DropIndex(
                name: "IX_Resign_EmployeeInfoId",
                table: "Resign");

            migrationBuilder.RenameColumn(
                name: "EmployeeInfoId",
                table: "Resign",
                newName: "ToEmployeeInfoId");

            migrationBuilder.AddColumn<long>(
                name: "FromEmployeeInfoId",
                table: "Resign",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ResignId",
                table: "EmployeeInfo",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmpResignViewModel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: false),
                    DesignationId = table.Column<long>(nullable: false),
                    EmployeeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpResignViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resign_FromEmployeeInfoId",
                table: "Resign",
                column: "FromEmployeeInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Resign_ToEmployeeInfoId",
                table: "Resign",
                column: "ToEmployeeInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInfo_ResignId",
                table: "EmployeeInfo",
                column: "ResignId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeInfo_Resign_ResignId",
                table: "EmployeeInfo",
                column: "ResignId",
                principalTable: "Resign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resign_EmployeeInfo_FromEmployeeInfoId",
                table: "Resign",
                column: "FromEmployeeInfoId",
                principalTable: "EmployeeInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resign_EmployeeInfo_ToEmployeeInfoId",
                table: "Resign",
                column: "ToEmployeeInfoId",
                principalTable: "EmployeeInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeInfo_Resign_ResignId",
                table: "EmployeeInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Resign_EmployeeInfo_FromEmployeeInfoId",
                table: "Resign");

            migrationBuilder.DropForeignKey(
                name: "FK_Resign_EmployeeInfo_ToEmployeeInfoId",
                table: "Resign");

            migrationBuilder.DropTable(
                name: "EmpResignViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Resign_FromEmployeeInfoId",
                table: "Resign");

            migrationBuilder.DropIndex(
                name: "IX_Resign_ToEmployeeInfoId",
                table: "Resign");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeInfo_ResignId",
                table: "EmployeeInfo");

            migrationBuilder.DropColumn(
                name: "FromEmployeeInfoId",
                table: "Resign");

            migrationBuilder.DropColumn(
                name: "ResignId",
                table: "EmployeeInfo");

            migrationBuilder.RenameColumn(
                name: "ToEmployeeInfoId",
                table: "Resign",
                newName: "EmployeeInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Resign_EmployeeInfoId",
                table: "Resign",
                column: "EmployeeInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Resign_EmployeeInfo_EmployeeInfoId",
                table: "Resign",
                column: "EmployeeInfoId",
                principalTable: "EmployeeInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
