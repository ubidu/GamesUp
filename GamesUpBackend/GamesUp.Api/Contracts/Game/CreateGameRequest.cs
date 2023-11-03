using GamesUp.Models;

namespace GamesUp.Contracts.Game;

public record CreateGameRequest(
    string Name,
    string Description,
    string CoverPath,
    string Category,
    DateTime ReleaseDate,
    string Platform,
    string Developer,
    string Publisher);