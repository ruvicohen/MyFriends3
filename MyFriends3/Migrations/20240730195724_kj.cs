using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFriends3.Migrations
{
    /// <inheritdoc />
    public partial class kj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureName",
                table: "Pictures");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureName",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
