using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesUp.Migrations
{
    /// <inheritdoc />
    public partial class ttttest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Karma",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Karma",
                table: "AspNetUsers");
        }
    }
}
