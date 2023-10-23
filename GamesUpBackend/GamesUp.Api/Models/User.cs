namespace GamesUp.Models;

public class User
{
    public int ID { get; set; }
    public string Username { get; set; }
    //Password - trzeba ogarnac ASP.NET Identity
    //Email
    public ICollection<Review> UserReviews { get; set; }
    public ICollection<Game> Favourites { get; set; }
    public ICollection<Game> ToPlay { get; set; }
    public ICollection<Game> Completed { get; set; }
    public ICollection<CustomList> CustomLists { get; set; }
}