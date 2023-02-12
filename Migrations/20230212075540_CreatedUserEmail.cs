using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreatedUserEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Users",
                table: "Users",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Users",
                table: "Users",
                newName: "IX_Users_User");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Users",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Users",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_Users_User",
                table: "Users",
                newName: "IX_Users_Users");
        }
    }
}
