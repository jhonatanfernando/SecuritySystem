using System;
using System.ComponentModel.DataAnnotations;
using SecuritySystem.Application.Services.Dto;

namespace SecuritySystem.Application.MotionSensor.Dto
{
    public class MotionSensorInsertDto : EntityDto<Guid>
    {
        [Required]
        public string Name { get; set; }  
    }
}