using GamesUp.Models;

namespace GamesUp.Domain.Repositories;

public interface IGameRepository
{
    Task<Game> GetGameByIdAsync(Guid id);
    Task<IEnumerable<Game>> GetAllGamesAsync();
    Task AddGameAsync(Game game);
    Task AddGamesAsync(IEnumerable<Game> games);
    void UpdateGame(Game game);
    void DeleteGame(Game game);
}