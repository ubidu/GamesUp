using GamesUp.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesUp.Persistence;

public class GamesUpDbContext : DbContext
{
    public GamesUpDbContext(DbContextOptions<GamesUpDbContext> options) : base(options)
    {
    }

    public DbSet<Game> Games { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GamesUpDbContext).Assembly);
    }
}