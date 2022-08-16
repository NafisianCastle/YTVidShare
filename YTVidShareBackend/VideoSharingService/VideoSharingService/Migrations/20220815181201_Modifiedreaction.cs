using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VideoSharingService.Migrations
{
    public partial class Modifiedreaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 16, 0, 12, 1, 163, DateTimeKind.Local).AddTicks(6516));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 16, 0, 9, 53, 833, DateTimeKind.Local).AddTicks(3127));
        }
    }
}
