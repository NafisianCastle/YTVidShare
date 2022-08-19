using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoSharingService.Migrations
{
    public partial class ChangedSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_AspNetUsers_ApiUserId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_ApiUserId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ApiUserId",
                table: "Videos");

            migrationBuilder.AddColumn<string>(
                name: "userEmail",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userEmail",
                table: "Videos");

            migrationBuilder.AddColumn<string>(
                name: "ApiUserId",
                table: "Videos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ApiUserId",
                table: "Videos",
                column: "ApiUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_AspNetUsers_ApiUserId",
                table: "Videos",
                column: "ApiUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
