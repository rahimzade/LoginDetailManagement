using AutoMapper;
using LoginDetailManagement.Entities;
using LoginDetailManagement.Models;

namespace LoginDetailManagement.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<LoginDetail, LoginDetailDto>().ReverseMap();
        }
    }
}
