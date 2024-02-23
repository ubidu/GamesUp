using AutoMapper;
using GamesUp.Models;
using GamesUp.Resources;

namespace GamesUp.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Game, GameResource>();
    }
}