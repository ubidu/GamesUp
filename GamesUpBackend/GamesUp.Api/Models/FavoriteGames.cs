namespace GamesUp.Models;

public class FavoriteGames
{
    public string UserId { get; set; } = null!;
    public Guid GameId { get; set; }
}