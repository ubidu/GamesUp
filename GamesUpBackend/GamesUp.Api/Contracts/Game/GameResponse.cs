using GamesUp.Models;

namespace GamesUp.Contracts.Game;

public record GameResponse(
    Guid id,
    string Name,
    string Description,
    string CoverPath,
    string Category,
    DateTime ReleaseDate,
    string Platform,
    string Developer,
    string Publisher);