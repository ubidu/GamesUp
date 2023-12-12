using ErrorOr;
using GamesUp.Contracts.Game;
using GamesUp.Models;
using GamesUp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamesUp.Controllers;

public class GameController : ApiController
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetGame(Guid id)
    {
        ErrorOr<Game> getGameResult = _gameService.GetGame(id);

        return getGameResult.Match(
            game => Ok(MapGameResponse(game)),
            errors => Problem(errors));
    }

    [HttpGet]
    public IActionResult GetAllGames()
    {
        ErrorOr<List<Game>> getAllGamesResult = _gameService.GetAllGames();

        return getAllGamesResult.Match(
            games => Ok(games.Select(game => MapGamesResponse(game))),
            errors => Problem(errors));
    }
    

    [HttpPost]
    public IActionResult CreateGame(CreateGameRequest request)
    {
        ErrorOr<Game> requestToGameResult = Game.Create(
            request.Name,
            request.Description,
            request.CoverPath,
            request.Category,
            request.ReleaseDate,
            request.Platform,
            request.Developer,
            request.Publisher);

        if (requestToGameResult.IsError)
        {
            return Problem(requestToGameResult.Errors);
        }

        var game = requestToGameResult.Value;
        ErrorOr<Created> createGameResult = _gameService.CreateGame(game);

        return createGameResult.Match(
            created => CreatedAtGetGame(game),
            errors => Problem(errors));
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertGame(Guid id, CreateGameRequest request)
    {
        ErrorOr<Game> requestToGameResult = Game.Create(
            request.Name,
            request.Description,
            request.CoverPath,
            request.Category,
            request.ReleaseDate,
            request.Platform,
            request.Developer,
            request.Publisher,
            id);

        if (requestToGameResult.IsError)
        {
            return Problem(requestToGameResult.Errors);
        }

        var game = requestToGameResult.Value;
        ErrorOr<UpsertedGame> upsertedGameResult = _gameService.UpsertGame(game);

        return upsertedGameResult.Match(
            upserted => upserted.isNewlyCreated ? CreatedAtGetGame(game) : NoContent(),
            errors => Problem(errors));
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteGame(Guid id)
    {
        ErrorOr<Deleted> deleteGameResult = _gameService.DeleteGame(id);

        return deleteGameResult.Match(
            deleted => NoContent(),
            errors => Problem(errors));
    }

    private static GameResponse MapGameResponse(Game game)
    {
        var response = new GameResponse(
            game.Id,
            game.Name,
            game.Description,
            game.CoverPath,
            game.Category,
            game.ReleaseDate,
            game.Platform,
            game.Developer,
            game.Publisher);
        
        return response;
    }

    private static GamesResponse MapGamesResponse(Game game)
    {
        var response = new GamesResponse(
            game.Name,
            game.CoverPath);

        return response;
    }

    private CreatedAtActionResult CreatedAtGetGame(Game game)
    {
        return CreatedAtAction(
            nameof(GetGame),
            new { id = game.Id },
            MapGameResponse(game));
    }
    
}