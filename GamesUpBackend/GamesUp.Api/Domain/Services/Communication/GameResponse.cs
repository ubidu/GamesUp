using GamesUp.Models;

namespace GamesUp.Domain.Services.Communication;

public class GameResponse : BaseResponse
{
    public Game Game { get; private set; }
    
    public GameResponse(bool success, string message, Game game) : base(success, message)
    {
        Game = game;
    }
    
    /// <summary>
    /// Creates a success response.
    /// </summary>
    /// <param name="game">Saved game.</param>
    /// <returns>Response.</returns>
    public GameResponse(Game game) : this(true, string.Empty, game)
    {}
    
    public GameResponse(IEnumerable<Game> games) : this(true, string.Empty, null)
    {}
    
    /// <summary>
    /// Creates an error response.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <returns>Response.</returns>
    public GameResponse(string message) : this(false, message, null)
    {}
}