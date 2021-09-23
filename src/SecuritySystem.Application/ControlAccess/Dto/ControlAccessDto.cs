using SecuritySystem.Application.Services.Dto;
using Models = SecuritySystem.Core.Models;

namespace SecuritySystem.Application.ControlAccess.Dto
{
    public class ControlAccessDto : EntityDto<long>
    {
        public Models.Door Door { get; set; }
        public Models.KeyCard KeyCard { get; set; }

        public bool HasAccess { get; set; }
    }
}