using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SecuritySystem.Application.Door.Dto;
using SecuritySystem.Application.KeyCard.Dto;
using SecuritySystem.Core.Repositories;

namespace SecuritySystem.Application.Services.KeyCard
{
    public class KeyCardAppService :  AppService<SecuritySystem.Core.Models.KeyCard, KeyCardDto, KeyCardInsertDto, Guid>, IKeyCardAppService
    {
        IRepositoryBase<SecuritySystem.Core.Models.ControlAccess, long> repositoryControlAccess;
        public KeyCardAppService(IMapper mapper, IRepositoryBase<SecuritySystem.Core.Models.KeyCard, Guid> repository,
                                 IRepositoryBase<SecuritySystem.Core.Models.ControlAccess, long> repositoryControlAccess) : base(mapper, repository)
        {
            this.repositoryControlAccess = repositoryControlAccess;
        }

        public async Task<IEnumerable<DoorDto>> GetAllDoors(Guid keyCardId)
        {
            var doors = (await repositoryControlAccess.GetAllAsync()).Where(c=> c.KeyCardId == keyCardId).Select(c=> c.Door);
            var result = Mapper.Map<IEnumerable<DoorDto>>(doors.AsEnumerable());

            return result;
        }
    }
}