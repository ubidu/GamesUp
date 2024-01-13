namespace GamesUp.Contracts.Review;

public class ReviewResponse
{
    public Guid Id { get; set; }
    public string Content { get; set; } = null!;
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UserId { get; set; } = null!;
    public Guid GameId { get; set; }
}