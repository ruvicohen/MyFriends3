using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFriends3.Migrations
{
    /// <inheritdoc />
    public partial class bb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Pictures_ProfilePictureId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProfilePictureId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfilePictureId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfilePictureId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfilePictureId",
                table: "Users",
                column: "ProfilePictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Pictures_ProfilePictureId",
                table: "Users",
                column: "ProfilePictureId",
                principalTable: "Pictures",
                principalColumn: "PictureId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
