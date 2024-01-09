using GamesUp.Models;
using ErrorOr;

namespace GamesUp.Services;

public interface IGameService
{
    ErrorOr<Created> CreateGame(Game game);
    ErrorOr<Game> GetGame(Guid id);
    ErrorOr<List<Game>> GetAllGames();
    ErrorOr<List<Game>> CreateGames(List<Game> games);
    ErrorOr<UpsertedGame> UpsertGame(Game game);
    ErrorOr<Deleted> DeleteGame(Guid id);
}