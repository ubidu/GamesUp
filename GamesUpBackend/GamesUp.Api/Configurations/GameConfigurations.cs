using ErrorOr;
using GamesUp.Models;
using GamesUp.Persistence;
using GamesUp.ServiceErrors;
using GamesUp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesUp.Configurations;

public class GameConfigurations : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
            .ValueGeneratedNever()
            .IsRequired();

    }
}