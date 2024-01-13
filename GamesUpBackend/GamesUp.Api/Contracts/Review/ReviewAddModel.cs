namespace GamesUp.Contracts.Review;

public class ReviewAddModel
{
    public Guid GameId { get; set; }
    public string Content { get; set; }
    public int Rating { get; set; }
}