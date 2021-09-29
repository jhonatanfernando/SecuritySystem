using System;
using AutoMapper;
using SecuritySystem.Application.DoorLogActivity.Dto;
using SecuritySystem.Core.Repositories;

namespace SecuritySystem.Application.Services.DoorLogActivity
{
    public class DoorLogActivityAppService :  AppService<SecuritySystem.Core.Models.DoorLogActivity, DoorLogActivityDto, long>
    {
        public DoorLogActivityAppService(IMapper mapper, IRepositoryBase<SecuritySystem.Core.Models.DoorLogActivity, long> repository) : base(mapper, repository)
        {

        }
    }
}