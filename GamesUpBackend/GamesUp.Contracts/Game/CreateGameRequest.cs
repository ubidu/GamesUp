using GamesUp.Models;

namespace GamesUp.Contracts.Game;

public record CreateGameRequest(
    string Name,
    string Description,
    string CoverPath,
    Category Category,
    DateTime ReleaseDate,
    Platform Platform,
    Developer Developer,
    Publisher Publisher);