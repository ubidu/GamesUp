using GamesUp.Domain.Repositories;
using GamesUp.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesUp.Persistence.Repositories;

public class GameRepository : BaseRepository, IGameRepository
{
    public GameRepository(GamesUpDbContext context) : base(context)
    {
    }

    public async Task<Game> GetGameByIdAsync(Guid id)
    {
        return await _context.Games.FindAsync(id);
    }
    
    public async Task<IEnumerable<Game>> GetAllGamesAsync()
    {
        return await _context.Games.ToListAsync();
    }
    
    public async Task AddGameAsync(Game game)
    {
        await _context.Games.AddAsync(game);
    }
    
    public async Task AddGamesAsync(IEnumerable<Game> games)
    {
        await _context.Games.AddRangeAsync(games);
    }
    
    public void UpdateGame(Game game)
    {
        _context.Games.Update(game);
    }
    
    public void DeleteGame(Game game)
    {
        _context.Games.Remove(game);
    }
}