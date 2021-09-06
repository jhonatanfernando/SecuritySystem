using System;
using System.ComponentModel.DataAnnotations;
using SecuritySystem.Application.Services.Dto;

namespace SecuritySystem.Application.Door.Dto
{
    public class DoorDto : EntityDto<Guid>
    {
        [Required]
        public string Name { get; set; }

        public bool IsOpen { get; set; }
    }
}