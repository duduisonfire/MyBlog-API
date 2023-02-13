using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUserNameToUserFullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "UserFullName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserFullName",
                table: "Users",
                newName: "UserName");
        }
    }
}
