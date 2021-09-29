using System;
using System.ComponentModel.DataAnnotations;
using SecuritySystem.Application.Services.Dto;

namespace SecuritySystem.Application.DoorLogActivity.Dto
{
    public class DoorLogActivityDto : EntityDto<long>
    {
        [Required]
        public string DoorName { get; set; }

        [Required]
        public string keyCardName { get; set; }

        [Required]
        public bool IsGranted { get; set; }
    }
}