namespace GamesUp.Contracts.Game;

public record GameResponse(
    Guid Id,
    string Name,
    string Description,
    string CoverPath,
    string Category,
    DateTime ReleaseDate,
    string Platform,
    string Developer,
    string Publisher,
    ICollection<Review> Reviews);
