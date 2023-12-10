using Microsoft.AspNetCore.Identity;

namespace GamesUp.Models;

public class User : IdentityUser
{
    public List<Game> FavoriteGames { get; set; } = new ();
    
}