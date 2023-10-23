namespace GamesUp.Models;

public class CustomList
{
    public int ID { get; set; }
    public string Name { get; set; }
    public User User { get; set; }
    public ICollection<Game> Games { get; set; }
}