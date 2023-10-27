using AutoMapper;
using Model.DTO_s;
using Model.Entities;

namespace Business.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameDTO>().ReverseMap();
        }
    }
}
