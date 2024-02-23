namespace GamesUp.Models;

public class UserList
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public List<Game> Games { get; set; } = new List<Game>();
}