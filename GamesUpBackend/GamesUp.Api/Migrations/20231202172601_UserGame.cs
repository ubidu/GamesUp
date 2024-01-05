using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesUp.Migrations
{
    /// <inheritdoc />
    public partial class UserGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGame_AspNetUsers_UserId",
                table: "FavoriteGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGame_Games_GameId",
                table: "FavoriteGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGame",
                table: "FavoriteGames");

            migrationBuilder.RenameTable(
                name: "FavoriteGames",
                newName: "UserGames");

            migrationBuilder.RenameIndex(
                name: "IX_UserGame_GameId",
                table: "UserGames",
                newName: "IX_UserGames_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGames",
                table: "UserGames",
                columns: new[] { "UserId", "GameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserGames_AspNetUsers_UserId",
                table: "UserGames",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGames_Games_GameId",
                table: "UserGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGames_AspNetUsers_UserId",
                table: "UserGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGames_Games_GameId",
                table: "UserGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGames",
                table: "UserGames");

            migrationBuilder.RenameTable(
                name: "UserGames",
                newName: "FavoriteGames");

            migrationBuilder.RenameIndex(
                name: "IX_UserGames_GameId",
                table: "FavoriteGames",
                newName: "IX_UserGame_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGame",
                table: "FavoriteGames",
                columns: new[] { "UserId", "GameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserGame_AspNetUsers_UserId",
                table: "FavoriteGames",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGame_Games_GameId",
                table: "FavoriteGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
