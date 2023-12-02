using System.Security.Claims;
using GamesUp.Authentication;
using GamesUp.Contracts.User;
using GamesUp.Models;
using GamesUp.Persistence;
using GamesUp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamesUp.Controllers;

[Authorize]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly GamesUpDbContext _context;

    public UserController(UserManager<User> userManager, GamesUpDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    [HttpPost("AddFavoriteGame")]
    public async Task<IActionResult> AddFavoriteGame([FromBody] FavoriteGameAddModel model)
    {
        var game = await _context.Games.FindAsync(model.GameId);
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null || game == null)
        {
            return NotFound();
        }

        if (user.FavoriteGames.All(f => f.Id != game.Id))
        {
            user.FavoriteGames.Add(game);
            await _context.SaveChangesAsync();
        }

        return Ok();
    }

    [HttpGet("GetFavoriteGames")]
    public async Task<IActionResult> GetFavoriteGames()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);

        
        if (user == null)
        {
            return NotFound();
        }

        var favoriteGames = await _context.FavoriteGames
            .Where(fg => fg.UserId == user.Id)
            .Select(fg => fg.GameId)
            .ToListAsync();

        return Ok(favoriteGames);
    }

    [HttpDelete("RemoveFavoriteGame/{gameId}")]
    public async Task<IActionResult> RemoveFavoriteGame(Guid gameId)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        var game = await _context.Games.FindAsync(gameId);

        if (user == null || game == null)
        {
            return NotFound();
        }

        if (!_context.FavoriteGames.Any(fg => fg.UserId == user.Id && fg.GameId == game.Id))
        {
            return NotFound();
        }
        
        var favoriteGame = await _context.FavoriteGames
            .Where(fg => fg.UserId == user.Id && fg.GameId == game.Id)
            .FirstOrDefaultAsync();
        
        _context.FavoriteGames.Remove(favoriteGame);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
