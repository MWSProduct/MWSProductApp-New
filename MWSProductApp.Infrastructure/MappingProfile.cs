using AutoMapper;
using MWSProductApp.DTO;
using MWSProductApp.Model;

namespace MWSProductApp.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MWSUserRegister, MWSUserRegisterDTO>();
        }
        

    }
}
