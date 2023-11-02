using ErrorOr;

namespace GamesUp.Models;

public class Game
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string CoverPath { get; private set; }
    public Category Category { get; private set; }
    public DateTime ReleaseDate { get; private set; }
    public Platform Platform { get; private set; }
    public Developer Developer { get; private set; }
    public Publisher Publisher { get; private set; }
    public ICollection<Review> Reviews { get; private set; }
    
    private Game() {}

    private Game(Guid id, string name, string description, string coverPath, Category category, DateTime releaseDate,
        Platform platform, Developer developer, Publisher publisher, ICollection<Review>? reviews = null)
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
        Reviews = reviews;
    }

    public static ErrorOr<Game> Create(string name, string description, string coverPath, Category category,
        DateTime releaseDate, Platform platform, Developer developer, Publisher publisher, Guid? id = null)
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