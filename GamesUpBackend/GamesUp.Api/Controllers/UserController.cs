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
     // Rozszerz kontroler o nowe akcje dla gier do przejścia
    [HttpPost("AddCompletedGame")]
    public async Task<IActionResult> AddCompletionGame([FromBody] CompletionGameAddModel model)
    {
        var game = await _context.Games.FindAsync(model.GameId);
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null || game == null)
        {
            return NotFound();
        }

        if (user.CompletionGames.All(f => f.Id != game.Id))
        {
            user.CompletionGames.Add(game);
            await _context.SaveChangesAsync();
        }

        return Ok();
    }

    [HttpGet("GetCompletedGames")]
    public async Task<IActionResult> GetCompleteGames()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);

        
        if (user == null)
        {
            return NotFound();
        }
        
        var completionGames = await _context.CompletionGames
            .Where(cg => cg.UserId == user.Id)
            .Select(cg => cg.GameId)
            .ToListAsync();
        
      
        return Ok(completionGames);
    }

    [HttpDelete("RemoveCompletedGame/{gameId}")]
    public async Task<IActionResult> RemoveGameCompletion(Guid gameId)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        var game = await _context.Games.FindAsync(gameId);

        if (user == null || game == null)
        {
            return NotFound();
        }

        if (!_context.CompletionGames.Any(fg => fg.UserId == user.Id && fg.GameId == game.Id))
        {
            return NotFound();
        }
        
        var completionGame = await _context.CompletionGames
            .Where(cg => cg.UserId == user.Id && cg.GameId == game.Id)
            .FirstOrDefaultAsync();
        
        _context.CompletionGames.Remove(completionGame);
        await _context.SaveChangesAsync();


        return NoContent();
    }
    // Rozszerz kontroler o nowe akcje dla gier do przejścia
    [HttpPost("AddGameToFinish")]
    public async Task<IActionResult> AddGameToFinish([FromBody] GameToFinishAddModel model)
    {
        var game = await _context.Games.FindAsync(model.GameId);
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null || game == null)
        {
            return NotFound();
        }

        if (user.GamesToFinish.All(f => f.Id != game.Id))
        {
            user.GamesToFinish.Add(game);
            await _context.SaveChangesAsync();
        }

        return Ok();
    }

    [HttpGet("GetGamesToFinish")]
    public async Task<IActionResult> GetGamesToFinish()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);

        
        if (user == null)
        {
            return NotFound();
        }
        
        var gamesToFinish = await _context.GamesToFinish
            .Where(gtf => gtf.UserId == user.Id)
            .Select(gtf => gtf.GameId)
            .ToListAsync();
        
      
        return Ok(gamesToFinish);
    }

    [HttpDelete("RemoveGameToFinish/{gameId}")]
    public async Task<IActionResult> RemoveGameToFinish(Guid gameId)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        var game = await _context.Games.FindAsync(gameId);

        if (user == null || game == null)
        {
            return NotFound();
        }

        if (!_context.GamesToFinish.Any(fg => fg.UserId == user.Id && fg.GameId == game.Id))
        {
            return NotFound();
        }
        
        var gamesToFinish = await _context.GamesToFinish
            .Where(cg => cg.UserId == user.Id && cg.GameId == game.Id)
            .FirstOrDefaultAsync();
        
        _context.GamesToFinish.Remove(gamesToFinish);
        await _context.SaveChangesAsync();


        return NoContent();
    }
    [HttpPost("CreateList")]
    public async Task<IActionResult> CreateList([FromBody] UserListCreateModel model)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null)
        {
            return NotFound("Użytkownik nie znaleziony.");
        }

        var userList = new UserList
        {
            Name = model.Name,
            UserId = user.Id
        };

        _context.UserLists.Add(userList);
        await _context.SaveChangesAsync();

        return Ok("Lista utworzona pomyślnie.");
    }
    [HttpPost("AddGameToList")]
    public async Task<IActionResult> AddGameToList([FromBody] GameToListAddModel model)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);

        if (user == null)
        {
            return NotFound();
        }

        var userList = await _context.UserLists
            .Include(ul => ul.Games)
            .FirstOrDefaultAsync(ul => ul.UserId == user.Id && ul.Name == model.ListName);

        if (userList == null)
        {
            return NotFound("User list not found");
        }

        var game = await _context.Games.FindAsync(model.GameId);

        if (game == null)
        {
            return NotFound("Game not found");
        }

        if (userList.Games.All(g => g.Id != game.Id))
        {
            userList.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        return Ok();
    }

    
    [HttpDelete("DeleteList/{listName}")]
    public async Task<IActionResult> DeleteList(string listName)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null)
        {
            return NotFound("Użytkownik nie znaleziony.");
        }

        var userList = await _context.UserLists
            .FirstOrDefaultAsync(ul => ul.Name == listName && ul.UserId == user.Id);

        if (userList == null)
        {
            return NotFound("Lista nie istnieje lub nie należy do użytkownika.");
        }

        _context.UserLists.Remove(userList);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("GetUserLists")]
    public async Task<IActionResult> GetUserLists()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);

        if (user == null)
        {
            return NotFound();
        }

        var userLists = await _context.UserLists
            .Where(ul => ul.UserId == user.Id)
            .Select(ul => new
            {
                ul.Id,
                ul.Name,
                ul.UserId
            })
            .ToListAsync();

        return Ok(userLists);
    }
    [HttpGet("GetUserListGames/{listId}")]
    public async Task<IActionResult> GetUserListGames(Guid listId)
    {
        var userList = await _context.UserLists
            .Include(ul => ul.Games)
            .FirstOrDefaultAsync(ul => ul.Id == listId);

        if (userList == null)
        {
            return NotFound();
        }

        var games = userList.Games;
        return Ok(games);
    }
    
    [HttpDelete("RemoveGameFromList")]
    public async Task<IActionResult> RemoveGameFromList([FromBody] GameRemoveFromListModel model)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null)
        {
            return NotFound("Użytkownik nie znaleziony.");
        }

        var userList = await _context.UserLists
            .FirstOrDefaultAsync(ul => ul.Name == model.ListName && ul.UserId == user.Id);

        if (userList == null)
        {
            return NotFound("Lista nie istnieje lub nie należy do użytkownika.");
        }

        var game = await _context.Games.FindAsync(model.GameId);

        if (game == null)
        {
            return NotFound("Gra nie istnieje.");
        }

        var gameToRemove = userList.Games.FirstOrDefault(g => g.Id == game.Id);

        if (gameToRemove != null)
        {
            userList.Games.Remove(gameToRemove);
            await _context.SaveChangesAsync();
        }

        return NoContent();
    }
    
}
