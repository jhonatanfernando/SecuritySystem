using System;
using System.ComponentModel.DataAnnotations;
using SecuritySystem.Application.Services.Dto;

namespace SecuritySystem.Application.ControlAccess.Dto
{
    public class ControlAccessInsertDto : EntityDto<long>
    {
        [Required]
        public Guid DoorId { get; set; }
        
        [Required]
        public Guid KeyCardId {get; set;}

        [Required]
        public bool HasAccess { get; set; }
    }
}