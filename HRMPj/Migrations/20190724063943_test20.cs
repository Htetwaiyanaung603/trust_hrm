using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMPj.Migrations
{
    public partial class test20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EarlyInTime",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "EarlyOutTime",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "InTime",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "LateInTime",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "LateOutTime",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "OutTime",
                table: "Attendance");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Attendance",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Attendance");

            migrationBuilder.AddColumn<DateTime>(
                name: "EarlyInTime",
                table: "Attendance",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EarlyOutTime",
                table: "Attendance",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InTime",
                table: "Attendance",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LateInTime",
                table: "Attendance",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LateOutTime",
                table: "Attendance",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OutTime",
                table: "Attendance",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
