using System.ComponentModel.DataAnnotations.Schema;
using ErrorOr;

namespace GamesUp.Models;

public class Game
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string CoverPath { get; private set; }
    public string Category { get; private set; }
    
    [Column(TypeName = "Date")]
    public DateTime ReleaseDate { get; private set; }
    public string Platform { get; private set; }
    public string Developer { get; private set; }
    public string Publisher { get; private set; }
    

    private Game() {}

    private Game(Guid id, string name, string description, string coverPath, string category, DateTime releaseDate,
        string platform, string developer, string publisher)
    {
        Id = id;
        Name = name;
        Description = description;
        CoverPath = coverPath;
        Category = category;
        ReleaseDate = releaseDate;
        Platform = platform;
        Developer = developer;
        Publisher = publisher;
    }

    public static ErrorOr<Game> Create(string name, string description, string coverPath, string category,
        DateTime releaseDate, string platform, string developer, string publisher, Guid? id = null)
    {
        List<Error> errors = new();

        if (errors.Any())
        {
            return errors;
        }

        return new Game(
            id ?? Guid.NewGuid(),
            name,
            description,
            coverPath,
            category,
            releaseDate,
            platform,
            developer,
            publisher);
    }
}