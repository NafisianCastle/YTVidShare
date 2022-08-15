using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoSharingService.Migrations
{
    public partial class Renamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Like",
                table: "Reactions",
                newName: "Likes");

            migrationBuilder.RenameColumn(
                name: "Dislike",
                table: "Reactions",
                newName: "Dislikes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 16, 0, 13, 26, 517, DateTimeKind.Local).AddTicks(4940));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Likes",
                table: "Reactions",
                newName: "Like");

            migrationBuilder.RenameColumn(
                name: "Dislikes",
                table: "Reactions",
                newName: "Dislike");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 16, 0, 12, 1, 163, DateTimeKind.Local).AddTicks(6516));
        }
    }
}
