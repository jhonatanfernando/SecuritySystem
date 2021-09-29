using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Newtonsoft.Json;
using SecuritySystem.Application.Services.Dto;
using Models = SecuritySystem.Core.Models;

namespace SecuritySystem.Application.ControlAccess.Dto
{
    public class ControlAccessDto : EntityDto<long>
    {
        public virtual Models.Door Door { get; set; }
        public virtual Models.KeyCard KeyCard { get; set; }
        public bool HasAccess { get; set; }
    }
}