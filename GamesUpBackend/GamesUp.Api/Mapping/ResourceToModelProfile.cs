using AutoMapper;
using GamesUp.Models;
using GamesUp.Resources;

namespace GamesUp.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveGameResource, Game>();
    }
}