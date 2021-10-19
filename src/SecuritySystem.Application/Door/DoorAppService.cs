using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SecuritySystem.Application.Door.Dto;
using SecuritySystem.Application.KeyCard.Dto;
using SecuritySystem.Core.Repositories;

namespace SecuritySystem.Application.Services.Door
{
    public class DoorAppService :  AppService<SecuritySystem.Core.Models.Door, DoorDto, DoorInsertDto, Guid>, IDoorAppService
    {
         IRepositoryBase<SecuritySystem.Core.Models.DoorLogActivity, long> repositoryDoorLog;
         IRepositoryBase<SecuritySystem.Core.Models.ControlAccess, long> repositoryControlAccess;
         IRepositoryBase<SecuritySystem.Core.Models.KeyCard, Guid> repositoryKeyCard;

        public DoorAppService(IMapper mapper, IRepositoryBase<SecuritySystem.Core.Models.Door, Guid> repository,
        IRepositoryBase<SecuritySystem.Core.Models.DoorLogActivity, long> repositoryDoorLog,
        IRepositoryBase<SecuritySystem.Core.Models.ControlAccess, long> repositoryControlAccess,
        IRepositoryBase<SecuritySystem.Core.Models.KeyCard, Guid> repositoryKeyCard) : base(mapper, repository)
        {
            this.repositoryDoorLog = repositoryDoorLog;
            this.repositoryControlAccess = repositoryControlAccess;
            this.repositoryKeyCard = repositoryKeyCard;
        }

        public async Task<IEnumerable<KeyCardDto>> GetAllKeyCards(Guid doorId)
        {
            var keyCards = (await repositoryControlAccess.GetAllAsync()).Where(c=> c.DoorId == doorId).Select(c=> c.KeyCard);
            var result = Mapper.Map<IEnumerable<KeyCardDto>>(keyCards.AsEnumerable());

            return result;

        }

        public async Task<bool> OpenDoor(Guid doorId, Guid keyCardId)
        {
            var controlAcess = (await repositoryControlAccess.GetAllAsync()).SingleOrDefault(c=> c.KeyCardId == keyCardId && c.DoorId == doorId);
           
            bool isGranted = false; 
            string doorName = null, keyCardName = null; 
            DoorDto doorDto = null;

           
            if(controlAcess == null)
            {
                doorDto = await GetAsync(doorId);
                doorName = doorDto.Name;
                keyCardName = (await repositoryKeyCard.GetAsync(keyCardId)).Name;
                isGranted = false;
            }
            else if (controlAcess != null)
            {
                doorDto = Mapper.Map<DoorDto>(controlAcess.Door);
                isGranted = controlAcess.HasAccess;
                doorName = controlAcess.Door.Name;
                keyCardName = controlAcess.KeyCard.Name;
            }

            if(isGranted)
            {
                var doorInsertDto = Mapper.Map<DoorInsertDto>(doorDto); 
                doorInsertDto.Id = doorDto.Id;
                doorInsertDto.IsOpen = true;
                await UpdateAsync(doorInsertDto);
            }
           
            await repositoryDoorLog.InsertAsync(new Core.Models.DoorLogActivity()
            {
                DoorName = doorName,
                keyCardName = keyCardName,
                IsGranted = isGranted,
                DateTimeEvent = DateTimeOffset.UtcNow
            });

            return isGranted;
        }
    }
}