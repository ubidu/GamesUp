using GamesUp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GamesUp.Persistence;

public class GamesUpDbContext : IdentityDbContext<User>
{
    public GamesUpDbContext(DbContextOptions<GamesUpDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Game> Games { get; set; } = null!;
    public DbSet<FavoriteGames> FavoriteGames { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GamesUpDbContext).Assembly);

        modelBuilder.Entity<User>()
            .HasMany(u => u.FavoriteGames)
            .WithMany()
            .UsingEntity<FavoriteGames>();
    }
}