using AutoMapper;
using SecuritySystem.Core.Models;
using Models = SecuritySystem.Core.Models;

namespace SecuritySystem.Application.ControlAccess.Dto
{
    public class ControlAccessMapProfile : Profile
    {
        public ControlAccessMapProfile()
        {
            CreateMap<ControlAccessDto, Models.ControlAccess>();

            CreateMap<ControlAccessInsertDto, Models.ControlAccess>();
            
            CreateMap<Models.ControlAccess, ControlAccessDto>();
        }
    }
}