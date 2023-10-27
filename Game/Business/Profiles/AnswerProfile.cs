using AutoMapper;
using Model.DTO_s;
using Model.Entities;

namespace Business.Profiles
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<Answer, AnswerDTO>().ReverseMap();
        }
    }
}
