using System;
using System.ComponentModel.DataAnnotations;
using SecuritySystem.Application.Services.Dto;

namespace SecuritySystem.Application.Door.Dto
{
    public class DoorInsertDto : EntityDto<Guid>
    {
        [Required]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public bool IsOpen { get; set; }
    }
}