using ErrorOr;

namespace GamesUp.ServiceErrors;

public static partial class Errors
{
    public static class Game
    {
        public static Error NotFound => Error.NotFound(
            "Game.NotFound",
            "Game was not found"
        );
    }
}