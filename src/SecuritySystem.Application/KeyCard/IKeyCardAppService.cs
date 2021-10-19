using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SecuritySystem.Application.Door.Dto;
using SecuritySystem.Application.KeyCard.Dto;

namespace SecuritySystem.Application.Services.KeyCard
{
    public interface IKeyCardAppService : IAppService<KeyCardDto, KeyCardInsertDto, Guid>
    {
        Task<IEnumerable<DoorDto>> GetAllDoors(Guid keyCardId);

    }
}