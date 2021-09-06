using System;
using AutoMapper;
using SecuritySystem.Application.Door.Dto;
using SecuritySystem.Core.Repositories;

namespace SecuritySystem.Application.Services.Door
{
    public class DoorAppService :  AppService<SecuritySystem.Core.Models.Door, DoorDto, Guid>
    {
        public DoorAppService(IMapper mapper, IRepositoryBase<SecuritySystem.Core.Models.Door, Guid> repository) : base(mapper, repository)
        {

        }
    }
}