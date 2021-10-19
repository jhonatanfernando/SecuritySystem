using System;
using System.ComponentModel.DataAnnotations;
using SecuritySystem.Application.Services.Dto;

namespace SecuritySystem.Application.Door.Dto
{
    public class OpenDoorDto 
    {
        [Required]
        public Guid DoorId { get; set; }

        [Required]
        public Guid KeyCardId { get; set; }

    }
}