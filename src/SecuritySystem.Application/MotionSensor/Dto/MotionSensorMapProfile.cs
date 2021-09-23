using AutoMapper;
using SecuritySystem.Core.Models;
using Models = SecuritySystem.Core.Models;

namespace SecuritySystem.Application.MotionSensor.Dto
{
    public class MotionSensorMapProfile : Profile
    {
        public MotionSensorMapProfile()
        {
            CreateMap<MotionSensorDto, Models.MotionSensor>();

            CreateMap<MotionSensorInsertDto, Models.MotionSensor>();
            
            CreateMap<Models.MotionSensor, MotionSensorDto>();
        }
    }
}