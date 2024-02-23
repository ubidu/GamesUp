using AutoMapper;
using GamesUp.Domain.Services.Communication;
using GamesUp.Extensions;
using GamesUp.Models;
using GamesUp.Resources;
using GamesUp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamesUp.Controllers;

[Route("games")]
public class GameController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IGameService _gameService;

    public GameController(IMapper mapper ,IGameService gameService)
    {
        mapper = _mapper;
        _gameService = gameService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetGameByIdAsync(Guid id)
    {
        var result = await _gameService.GetGameByIdAsync(id);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        
        var gameResource = _mapper.Map<Game, GameResource>(result.Game);

        return Ok(gameResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGamesAsync()
    {
        var result = await _gameService.GetAllGamesAsync();
        var resources = new List<GameResource>();
        
        foreach (var game in result)
        {
            var gameResource = _mapper.Map<Game, GameResource>(game);
            resources.Add(gameResource);
        }
        
        var gamesResource = new GamesResource(resources);
        
        return Ok(gamesResource);
    }
    

    [HttpPost]
    public async Task<IActionResult> AddGameAsync([FromBody] SaveGameResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        
        var game = _mapper.Map<SaveGameResource, Game>(resource);
        var result = await _gameService.AddGameAsync(game);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        
        var gameResource = _mapper.Map<Game, GameResource>(result.Game);
        
        return Ok(gameResource);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddGamesAsync([FromBody] List<SaveGameResource> resources)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        
        var games = _mapper.Map<List<SaveGameResource>, List<Game>>(resources);
        var result = await _gameService.AddGamesAsync(games);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        
        var gameResource = _mapper.Map<Game, GameResource>(result.Game);
        
        return Ok(gameResource);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateGameAsync(Guid id, [FromBody] SaveGameResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        
        var game = _mapper.Map<SaveGameResource, Game>(resource);
        var result = await _gameService.UpdateGameAsync(id, game);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        
        var gameResource = _mapper.Map<Game, GameResource>(result.Game);
        
        return Ok(gameResource);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteGameAsync(Guid id)
    {
        var result = await _gameService.DeleteGameAsync(id);
        
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        
        var gameResource = _mapper.Map<Game, GameResource>(result.Game);

        return Ok(gameResource);
    }
}