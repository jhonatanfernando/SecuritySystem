using System;
using AutoMapper;
using SecuritySystem.Application.MotionSensor.Dto;
using SecuritySystem.Core.Repositories;

namespace SecuritySystem.Application.Services.MotionSensor
{
    public class MotionSensorAppService :  AppService<SecuritySystem.Core.Models.MotionSensor, MotionSensorDto, MotionSensorInsertDto, Guid>
    {
        public MotionSensorAppService(IMapper mapper, IRepositoryBase<SecuritySystem.Core.Models.MotionSensor, Guid> repository) : base(mapper, repository)
        {

        }
    }
}