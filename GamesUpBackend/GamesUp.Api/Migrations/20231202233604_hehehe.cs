using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesUp.Migrations
{
    /// <inheritdoc />
    public partial class hehehe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteGames_Games_FavoriteGamesId",
                table: "FavoriteGames");

            migrationBuilder.RenameColumn(
                name: "FavoriteGamesId",
                table: "FavoriteGames",
                newName: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteGames_Games_GameId",
                table: "FavoriteGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteGames_Games_GameId",
                table: "FavoriteGames");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "FavoriteGames",
                newName: "FavoriteGamesId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteGames_Games_FavoriteGamesId",
                table: "FavoriteGames",
                column: "FavoriteGamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
