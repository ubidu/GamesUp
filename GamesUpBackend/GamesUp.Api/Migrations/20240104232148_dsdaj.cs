using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesUp.Migrations
{
    /// <inheritdoc />
    public partial class dsdaj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserListId",
                table: "Games",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserListId",
                table: "Games",
                column: "UserListId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLists_UserId",
                table: "UserLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_UserLists_UserListId",
                table: "Games",
                column: "UserListId",
                principalTable: "UserLists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_UserLists_UserListId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "UserLists");

            migrationBuilder.DropIndex(
                name: "IX_Games_UserListId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UserListId",
                table: "Games");
        }
    }
}
