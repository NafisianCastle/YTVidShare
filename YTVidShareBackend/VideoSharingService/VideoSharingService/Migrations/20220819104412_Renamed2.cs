using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoSharingService.Migrations
{
    public partial class Renamed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_AspNetUsers_UserID",
                table: "Videos");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Videos",
                newName: "ApiUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_UserID",
                table: "Videos",
                newName: "IX_Videos_ApiUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_AspNetUsers_ApiUserId",
                table: "Videos",
                column: "ApiUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_AspNetUsers_ApiUserId",
                table: "Videos");

            migrationBuilder.RenameColumn(
                name: "ApiUserId",
                table: "Videos",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_ApiUserId",
                table: "Videos",
                newName: "IX_Videos_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_AspNetUsers_UserID",
                table: "Videos",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
