using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VideoSharingService.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "CreatedAt", "Email", "Password", "Username" },
                values: new object[] { 1, new DateTime(2022, 8, 15, 14, 19, 51, 320, DateTimeKind.Local).AddTicks(4701), "admin@vidshare.com", "admin@1234", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);
        }
    }
}
