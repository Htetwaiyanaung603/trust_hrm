using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class test9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestApprovedUser_LeaveRequestId",
                table: "LeaveRequestApprovedUser",
                column: "LeaveRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequestApprovedUser");
        }
    }
}
