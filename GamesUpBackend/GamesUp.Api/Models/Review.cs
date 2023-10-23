namespace GamesUp.Models;

public class Review
{
    public int ID { get; set; }
    private int Rating { get; set; }
    public string Text { get; set; }
    public Game Game { get; set; }
    public User User { get; set; }
}