using System;
using System.ComponentModel.DataAnnotations;
using SecuritySystem.Application.Services.Dto;

namespace SecuritySystem.Application.KeyCard.Dto
{
    public class KeyCardDto : EntityDto<Guid>
    {
        [Required]
        public string Name { get; set; }
    }
}