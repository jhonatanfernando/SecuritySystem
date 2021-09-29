using AutoMapper;
using SecuritySystem.Core.Models;
using Models = SecuritySystem.Core.Models;

namespace SecuritySystem.Application.DoorLogActivity.Dto
{
    public class DoorLogActivityMapProfile : Profile
    {
        public DoorLogActivityMapProfile()
        {
            CreateMap<DoorLogActivityDto, Models.DoorLogActivity>();
            
            CreateMap<Models.DoorLogActivity, DoorLogActivityDto>();
        }
    }
}