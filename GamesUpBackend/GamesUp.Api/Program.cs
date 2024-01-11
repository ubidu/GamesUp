using System.Security.Claims;
using System.Text;
using GamesUp.Models;
using GamesUp.Persistence;
using GamesUp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(option =>
    {
        option.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "GamesUp API",
            Version = "v1"
        });
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
            }
        });
    });
    builder.Services.AddScoped<IGameService, GameService>();
    builder.Services.AddDbContext<GamesUpDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("GamesUpDb")));
    builder.Services.AddIdentity<User, IdentityRole>(options =>
        {
            options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier;
        })
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
    app.UseCors(builder =>
    {
        builder.WithOrigins("http://localhost:3000") // Dodaj adresy, z których przyjmujesz żądania
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // Dodaj tę linijkę, jeśli korzystasz z uwierzytelniania z użyciem ciasteczek (cookies)
    });
    
    app.UseExceptionHandler("/error");
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.UseCors("http://localhost:3000");
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
