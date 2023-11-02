using GamesUp.Persistence;
using GamesUp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddScoped<IGameService, GameService>();
    builder.Services.AddDbContext<GamesUpDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("GamesUpDb")));
}



var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
