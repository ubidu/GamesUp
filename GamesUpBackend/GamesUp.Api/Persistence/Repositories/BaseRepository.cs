namespace GamesUp.Persistence.Repositories;

public abstract class BaseRepository
{
    protected readonly GamesUpDbContext _context;
    
    public BaseRepository(GamesUpDbContext context)
    {
        _context = context;
    }
}