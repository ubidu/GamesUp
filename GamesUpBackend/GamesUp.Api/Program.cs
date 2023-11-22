using System.Text;
using GamesUp.Persistence;
using GamesUp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddScoped<IGameService, GameService>();
    builder.Services.AddDbContext<GamesUpDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("GamesUpDb")));
    builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<GamesUpDbContext>()
        .AddDefaultTokenProviders();
    builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
    
            // Ensure that configuration values are not null
            string validAudience = builder.Configuration["JWT:ValidAudience"];
            string validIssuer = builder.Configuration["JWT:ValidIssuer"];
            string secret = builder.Configuration["JWT:Secret"];

            if (validAudience == null || validIssuer == null || secret == null)
            {
                // Handle the case when configuration values are null
                throw new InvalidOperationException("JWT configuration values cannot be null");
            }

            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = validAudience,
                ValidIssuer = validIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
            };
        });


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
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
