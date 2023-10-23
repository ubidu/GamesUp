namespace GamesUp.Models;

public class Game
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CoverPath { get; set; }
    public Category Category { get; set; }
    public DateTime ReleaseDate { get; set; }
    public Platform Platform { get; set; }
    public Developer Developer { get; set; }
    public Publisher Publisher { get; set; }
    public ICollection<Review> Reviews { get; set; }
    //Pomyslec nad sensem: Fabula, Technologia, Mechanika
}