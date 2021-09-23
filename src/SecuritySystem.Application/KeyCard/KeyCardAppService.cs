using System;
using AutoMapper;
using SecuritySystem.Application.KeyCard.Dto;
using SecuritySystem.Core.Repositories;

namespace SecuritySystem.Application.Services.KeyCard
{
    public class KeyCardAppService :  AppService<SecuritySystem.Core.Models.KeyCard, KeyCardDto, KeyCardInsertDto, Guid>
    {
        public KeyCardAppService(IMapper mapper, IRepositoryBase<SecuritySystem.Core.Models.KeyCard, Guid> repository) : base(mapper, repository)
        {

        }
    }
}