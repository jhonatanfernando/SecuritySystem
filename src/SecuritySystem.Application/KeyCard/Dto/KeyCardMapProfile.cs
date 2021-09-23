using AutoMapper;
using SecuritySystem.Core.Models;
using Models = SecuritySystem.Core.Models;

namespace SecuritySystem.Application.KeyCard.Dto
{
    public class KeyCardMapProfile : Profile
    {
        public KeyCardMapProfile()
        {
            CreateMap<KeyCardDto, Models.KeyCard>();

            CreateMap<KeyCardInsertDto, Models.KeyCard>();
            
            CreateMap<Models.KeyCard, KeyCardDto>();
        }
    }
}