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
    [HttpPost("AddNewList")]
    public async Task<IActionResult> AddNewList([FromBody] UserListAddModel model)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);

        if (user == null)
        {
            return NotFound();
        }

        var newList = new UserList
        {
            Name = model.Name,
            UserId = user.Id, // Przypisujemy identyfikator zalogowanego użytkownika
        };

        _context.UserList.Add(newList);
        await _context.SaveChangesAsync();

        return Ok(new { ListId = newList.Id });
    }
    [HttpGet("UserLists")]
    public async Task<IActionResult> GetUserLists()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);

        if (user == null)
        {
            return NotFound();
        }

        var userLists = await _context.UserList
            .Where(ul => ul.UserId == user.Id)
            .Select(ul => new
            {
                ListId = ul.Id,
                ListName = ul.Name,
                Games = ul.Games.Select(g => new
                {
                    GameId = g.Id,
                    GameName = g.Name, // Zakładam, że w modelu Game jest właściwość Name
                    // Dodaj inne właściwości gry, jeśli to konieczne
                }).ToList()
            })
            .ToListAsync();

        return Ok(userLists);
    }
    [HttpPost("AddGameToUserList")]
    public async Task<IActionResult> AddGameToUserList([FromBody] UserListGameAddModel model)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);

        if (user == null)
        {
            return NotFound();
        }

        var userList = await _context.UserList
            .Include(ul => ul.Games)
            .FirstOrDefaultAsync(ul => ul.Name == model.ListName && ul.UserId == user.Id);

        if (userList == null)
        {
            return NotFound("Nie znaleziono listy o podanej nazwie i przypisanym użytkowniku.");
        }

        var game = await _context.Games.FindAsync(model.GameId);

        if (game == null)
        {
            return NotFound("Nie znaleziono gry o podanym identyfikatorze.");
        }

        if (userList.Games.Any(g => g.Id == model.GameId))
        {
            return BadRequest("Gra już istnieje na liście.");
        }

        userList.Games.Add(game);
        await _context.SaveChangesAsync();

        return Ok(new { GameId = game.Id });
    }
    [HttpDelete("RemoveUserList")]
    public async Task<IActionResult> RemoveUserList(string listName)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);

        if (user == null)
        {
            return NotFound();
        }

        var userList = await _context.UserList
            .Include(ul => ul.Games)
            .FirstOrDefaultAsync(ul => ul.Name == listName && ul.UserId == user.Id);

        if (userList == null)
        {
            return NotFound("Nie znaleziono listy o podanej nazwie i przypisanym użytkowniku.");
        }

        _context.UserList.Remove(userList);
        await _context.SaveChangesAsync();

        return Ok(new { Message = "Lista została usunięta pomyślnie." });
    }
    [HttpDelete("RemoveGameFromUserList")]
    public async Task<IActionResult> RemoveGameFromUserList([FromBody] UserListGameAddModel model)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);

        if (user == null)
        {
            return NotFound();
        }

        var userList = await _context.UserList
            .Include(ul => ul.Games)
            .FirstOrDefaultAsync(ul => ul.Name == model.ListName && ul.UserId == user.Id);

        if (userList == null)
        {
            return NotFound("Nie znaleziono listy o podanej nazwie i przypisanym użytkowniku.");
        }

        var gameToRemove = userList.Games.FirstOrDefault(g => g.Id == model.GameId);

        if (gameToRemove == null)
        {
            return NotFound("Nie znaleziono gry o podanym identyfikatorze na liście.");
        }

        userList.Games.Remove(gameToRemove);
        await _context.SaveChangesAsync();

        return Ok(new { GameId = gameToRemove.Id, Message = "Gra została usunięta z listy pomyślnie." });
    }


}
