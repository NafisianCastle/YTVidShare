using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoSharingService.Migrations
{
    public partial class ModifiedvideonReaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Reactions",
                newName: "Like");

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dislike",
                table: "Reactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 16, 0, 9, 53, 833, DateTimeKind.Local).AddTicks(3127));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Dislike",
                table: "Reactions");

            migrationBuilder.RenameColumn(
                name: "Like",
                table: "Reactions",
                newName: "Value");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 15, 14, 19, 51, 320, DateTimeKind.Local).AddTicks(4701));
        }
    }
}
