using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoSharingService.Migrations
{
    public partial class Renaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userEmail",
                table: "Videos",
                newName: "UserEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Videos",
                newName: "userEmail");
        }
    }
}
