namespace GamesUp.Contracts.Game;

public record GamesResponse(
    Guid Id,
    string Name,
    string CoverPath,
    string Description);