using GamesUp.Domain.Repositories;
using GamesUp.Domain.Services.Communication;
using GamesUp.Models;

namespace GamesUp.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<GameResponse> GetGameByIdAsync(Guid id)
    {
        var game = await _gameRepository.GetGameByIdAsync(id);

        if (game == null)
        {
            return new GameResponse("Game not found.");
        }
        
        return new GameResponse(game);
    }
    
    public async Task<IEnumerable<Game>> GetAllGamesAsync()
    {
        var games = await _gameRepository.GetAllGamesAsync();
        
        return games;
    }
    
    public async Task<GameResponse> AddGameAsync(Game game)
    {
        try
        {
            await _gameRepository.AddGameAsync(game);
            return new GameResponse(game);
        }
        catch (Exception ex)
        {
            return new GameResponse($"An error occurred when adding the game: {ex.Message}");
        }
    }
    
    public async Task<GameResponse> AddGamesAsync(IEnumerable<Game> games)
    {
        try
        {
            await _gameRepository.AddGamesAsync(games);
            return new GameResponse(games);
        }
        catch (Exception ex)
        {
            return new GameResponse($"An error occurred when adding the games: {ex.Message}");
        }
    }
    
    public async Task<GameResponse> UpdateGameAsync(Guid id, Game game)
    {
        var existingGame = await _gameRepository.GetGameByIdAsync(id);

        if (existingGame == null)
        {
            return new GameResponse("Game not found.");
        }

        existingGame.Name = game.Name;
        existingGame.Description = game.Description;
        existingGame.ReleaseDate = game.ReleaseDate;
        existingGame.CoverPath = game.CoverPath;
        existingGame.Developer = game.Developer;
        existingGame.Publisher = game.Publisher;
        existingGame.Category = game.Category;
        existingGame.Platform = game.Platform;

        try
        {
            _gameRepository.UpdateGame(existingGame);
            return new GameResponse(existingGame);
        }
        catch (Exception ex)
        {
            return new GameResponse($"An error occurred when updating the game: {ex.Message}");
        }
    }
    
    public async Task<GameResponse> DeleteGameAsync(Guid id)
    {
        var existingGame = await _gameRepository.GetGameByIdAsync(id);

        if (existingGame == null)
        {
            return new GameResponse("Game not found.");
        }

        try
        {
            _gameRepository.DeleteGame(existingGame);
            return new GameResponse(existingGame);
        }
        catch (Exception ex)
        {
            return new GameResponse($"An error occurred when deleting the game: {ex.Message}");
        }
    }
    
    
}