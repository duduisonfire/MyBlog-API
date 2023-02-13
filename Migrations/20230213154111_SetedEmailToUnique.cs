using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogAPI.Migrations
{
    /// <inheritdoc />
    public partial class SetedEmailToUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEmail",
                table: "Users",
                column: "UserEmail",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserEmail",
                table: "Users");
        }
    }
}
