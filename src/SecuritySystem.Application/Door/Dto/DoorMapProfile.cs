using AutoMapper;
using SecuritySystem.Core.Models;
using Models = SecuritySystem.Core.Models;

namespace SecuritySystem.Application.Door.Dto
{
    public class DoorMapProfile : Profile
    {
        public DoorMapProfile()
        {
            CreateMap<DoorDto, Models.Door>();
            
            CreateMap<Models.Door, DoorDto>();
        }
    }
}