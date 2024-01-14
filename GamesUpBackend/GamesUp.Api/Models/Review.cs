namespace GamesUp.Models;

public class Review
{
    public Guid Id { get; private set; }
    public string Content { get; set; } = null!;
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public string UserId { get; set; } = null!;
    public User User { get; set; } = null!;
    public Guid GameId { get; set; }
    public Game Game { get; set; } = null!;

}