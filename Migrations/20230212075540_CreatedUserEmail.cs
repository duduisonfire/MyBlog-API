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
            _ = migrationBuilder.RenameColumn(name: "Users", table: "Users", newName: "User");

            _ = migrationBuilder.RenameIndex(
                name: "IX_Users_Users",
                newName: "IX_Users_User",
                table: "Users"
            );

            _ = migrationBuilder
                .AddColumn<string>(
                    name: "UserEmail",
                    table: "Users",
                    type: "varchar(255)",
                    maxLength: 255,
                    nullable: false,
                    defaultValue: ""
                )
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropColumn(name: "UserEmail", table: "Users");

            _ = migrationBuilder.RenameColumn(name: "User", table: "Users", newName: "Users");

            _ = migrationBuilder.RenameIndex(
                name: "IX_Users_User",
                newName: "IX_Users_Users",
                table: "Users"
            );
        }
    }
}
