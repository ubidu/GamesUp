using GamesUp.Domain.Repositories;

namespace GamesUp.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly GamesUpDbContext _context;
    
    public UnitOfWork(GamesUpDbContext context)
    {
        _context = context;
    }
    
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}