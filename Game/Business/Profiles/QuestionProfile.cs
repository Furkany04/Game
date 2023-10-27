using AutoMapper;
using Model.DTO_s;
using Model.Entities;

namespace Business.Profiles
{
    public class QuestionProfile:Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionDTO>().ReverseMap();
        }
    }
}
