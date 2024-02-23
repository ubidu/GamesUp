using GamesUp.Domain.Services.Communication;
using GamesUp.Models;

namespace GamesUp.Services;

public interface IGameService
{
    Task<GameResponse> GetGameByIdAsync(Guid id);
    Task<IEnumerable<Game>> GetAllGamesAsync();
    Task<GameResponse> AddGameAsync(Game game);
    Task<GameResponse> AddGamesAsync(IEnumerable<Game> games);
    Task<GameResponse> UpdateGameAsync(Guid id, Game game);
    Task<GameResponse> DeleteGameAsync(Guid id);
}