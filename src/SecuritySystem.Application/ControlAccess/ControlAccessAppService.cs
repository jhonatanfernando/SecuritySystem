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
        public ControlAccessAppService(IMapper mapper, IRepositoryBase<SecuritySystem.Core.Models.ControlAccess, long> repository) : base(mapper, repository)
        {

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
            }
           
            return access;
        }
        

        public Task<ControlAccessDto> RemoveAccess(Guid doorId, Guid KeyCardId)
        {
            throw new NotImplementedException();
        }
    }
}