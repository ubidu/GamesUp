using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GamesUp.Migrations
{
    /// <inheritdoc />
    public partial class UsersList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserListId",
                table: "Games",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserListId",
                table: "Games",
                column: "UserListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_UserList_UserListId",
                table: "Games",
                column: "UserListId",
                principalTable: "UserList",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_UserList_UserListId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "UserList");

            migrationBuilder.DropIndex(
                name: "IX_Games_UserListId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UserListId",
                table: "Games");
        }
    }
}
