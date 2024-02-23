using GamesUp.Domain.Services.Communication;

namespace GamesUp.Resources;

public class GamesResource
{
    public List<GameResource> Games { get; set; }
    
    public GamesResource(List<GameResource> games)
    {
        Games = games;
    }
}