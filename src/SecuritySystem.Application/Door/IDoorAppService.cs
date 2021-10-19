using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SecuritySystem.Application.Door.Dto;
using SecuritySystem.Application.KeyCard.Dto;

namespace SecuritySystem.Application.Services.Door
{
    public interface IDoorAppService : IAppService<DoorDto, DoorInsertDto, Guid>
    {
        Task<bool> OpenDoor(Guid doorId, Guid keyCardId);

        Task<IEnumerable<KeyCardDto>> GetAllKeyCards(Guid doorId);

    }
}