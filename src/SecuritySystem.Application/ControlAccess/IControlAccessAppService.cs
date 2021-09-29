using System;
using System.Threading.Tasks;
using SecuritySystem.Application.ControlAccess.Dto;

namespace SecuritySystem.Application.Services.ControlAccess
{
    public interface IControlAccessAppService : IAppService<ControlAccessDto, ControlAccessInsertDto, long>
    {
        Task<ControlAccessDto> GiveAccess(ControlAccessInsertDto entity);

        Task<ControlAccessDto> RemoveAccess(ControlAccessInsertDto entity);
    }
}