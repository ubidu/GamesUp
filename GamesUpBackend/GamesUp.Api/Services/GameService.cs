using ErrorOr;
using GamesUp.Models;
using GamesUp.Persistence;
using GamesUp.ServiceErrors;

namespace GamesUp.Services;

public class GameService : IGameService
{
    private readonly GamesUpDbContext _dbContext;

    public GameService(GamesUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ErrorOr<Created> CreateGame(Game game)
    {
        _dbContext.Add(game);
        _dbContext.SaveChanges();

        return Result.Created;
    }

    public ErrorOr<Game> GetGame(Guid id)
    {
        if (_dbContext.Games.Find(id) is Game game)
        {
            return game;
        }

        return Errors.Game.NotFound;
    }

    public ErrorOr<List<Game>> GetAllGames()
    {
        var games = _dbContext.Games.ToList();

        if (games.Count > 0)
        {
            return games;
        }

        return Errors.Game.NotFound;
    }

    public ErrorOr<UpsertedGame> UpsertGame(Game game)
    {
        var isNewlyCreated = !_dbContext.Games.Any(g => g.Id == game.Id);

        if (isNewlyCreated)
        {
            _dbContext.Games.Add(game);
        }
        else
        {
            _dbContext.Games.Update(game);
        }

        _dbContext.SaveChanges();

        return new UpsertedGame(isNewlyCreated);
    }

    public ErrorOr<Deleted> DeleteGame(Guid id)
    {
        var game = _dbContext.Games.Find(id);

        if (game is null)
        {
            return Errors.Game.NotFound;
        }

        _dbContext.Remove(game);
        _dbContext.SaveChanges();
        
        return Result.Deleted;
    }
    public ErrorOr<List<Game>> CreateGames(List<Game> games)
    {
        _dbContext.Games.AddRange(games);
        _dbContext.SaveChanges();

        return games;
    }
}