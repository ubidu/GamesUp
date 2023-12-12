using Microsoft.AspNetCore.Identity;

namespace GamesUp.Models;

public class User : IdentityUser
{
    public List<Game> FavoriteGames { get; set; } = new ();
    public List<Game> CompletionGames { get; set; } = new ();
    public List<Game> GamesToFinish { get; set; } = new ();
}