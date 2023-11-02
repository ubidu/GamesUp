using ErrorOr;
using GamesUp.Models;

namespace GamesUp.Services;

public class GameService : IGameService
{
    public ErrorOr<Created> CreateGame(Game game)
    {
        throw new NotImplementedException();
    }

    public ErrorOr<Game> GetGame(Guid id)
    {
        throw new NotImplementedException();
    }

    public ErrorOr<UpsertedGame> UpsertGame(Game game)
    {
        throw new NotImplementedException();
    }

    public ErrorOr<Deleted> DeleteGame(Guid id)
    {
        throw new NotImplementedException();
    }
}