using System.ComponentModel.DataAnnotations.Schema;

namespace GamesUp.Models;

public class Game
{
    public Guid Id { get; private set; }
    public string Name { get; internal set; }
    public string Description { get; internal set; }
    public string CoverPath { get; internal set; }
    public string Category { get; internal set; }
    
    [Column(TypeName = "Date")]
    public DateTime ReleaseDate { get; internal set; }
    public string Platform { get; internal set; }
    public string Developer { get; internal set; }
    public string Publisher { get; internal set; }
    public ICollection<Review> Reviews { get; set; } = new List<Review>();

}