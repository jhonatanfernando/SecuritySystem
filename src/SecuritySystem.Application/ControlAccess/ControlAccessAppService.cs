using System;
using System.Threading.Tasks;
using AutoMapper;
using SecuritySystem.Application.ControlAccess.Dto;
using SecuritySystem.Core.Repositories;
using System.Linq;
using SecuritySystem.Application.Services.Dto;

namespace SecuritySystem.Application.Services.ControlAccess
{
    public class ControlAccessAppService :  AppService<SecuritySystem.Core.Models.ControlAccess, ControlAccessDto, ControlAccessInsertDto, long>, IControlAccessAppService
    {
        IRepositoryBase<SecuritySystem.Core.Models.DoorLogActivity, long> repositoryDoorLog;
        public ControlAccessAppService(IMapper mapper, IRepositoryBase<SecuritySystem.Core.Models.ControlAccess, long> repository,
        IRepositoryBase<SecuritySystem.Core.Models.DoorLogActivity, long> repositoryDoorLog) : base(mapper, repository)
        {
            this.repositoryDoorLog = repositoryDoorLog;
        }

        public async Task<ControlAccessDto> GiveAccess(ControlAccessInsertDto entity)
        {
            var access = (await GetAllAsync()).SingleOrDefault(c=> c.Door.Id == entity.DoorId && c.KeyCard.Id == entity.KeyCardId);

            if(access == null || !access.HasAccess)
            {
                var insertDto = new ControlAccessInsertDto()
                { 
                    DoorId = entity.DoorId,
                    KeyCardId = entity.KeyCardId,
                    HasAccess = true
                };

                access = await InsertAsync(insertDto);

                await repositoryDoorLog.InsertAsync(new Core.Models.DoorLogActivity()
                {
                    DoorName = access.Door.Name,
                    keyCardName = access.KeyCard.Name,
                    IsGranted = true,
                    DateTimeEvent = DateTimeOffset.UtcNow
                });
            }
           
            return access;
        }
        

        public async Task<ControlAccessDto> RemoveAccess(ControlAccessInsertDto entity)
        {
            var access = (await GetAllAsync()).SingleOrDefault(c=> c.Door.Id == entity.DoorId && c.KeyCard.Id == entity.KeyCardId);

            if(access == null || access.HasAccess)
            {
                var updateDto = new ControlAccessInsertDto()
                { 
                    Id = access.Id,
                    DoorId = entity.DoorId,
                    KeyCardId = entity.KeyCardId,
                    HasAccess = false
                };

                access = await UpdateAsync(updateDto);

                await repositoryDoorLog.InsertAsync(new Core.Models.DoorLogActivity()
                {
                    DoorName = access.Door.Name,
                    keyCardName = access.KeyCard.Name,
                    IsGranted = false,
                    DateTimeEvent = DateTimeOffset.UtcNow
                });
            }
           
            return access;
        }
    }
}