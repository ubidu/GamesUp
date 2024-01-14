using Microsoft.AspNetCore.Identity;

namespace GamesUp.Models;

public class User : IdentityUser
{
    public List<Game> FavoriteGames { get; set; } = new List<Game>();
    public List<Game> CompletionGames { get; set; } = new List<Game>();
    public List<Game> GamesToFinish { get; set; } = new List<Game>();
    public List<UserList> UserLists { get; set; } = new List<UserList>();

    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}