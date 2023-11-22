using GamesUp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GamesUp.Persistence;

public class GamesUpDbContext : IdentityDbContext<IdentityUser>
{
    public GamesUpDbContext(DbContextOptions<GamesUpDbContext> options) : base(options)
    {
    }

    public DbSet<Game> Games { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GamesUpDbContext).Assembly);
    }
}