using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SecuritySystem.Application.Door.Dto;
using SecuritySystem.Application.Services;
using SecuritySystem.Core.Models;
using SecuritySystem.Core.Repositories;

namespace SecuritySystem.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorController :  ControllerBase
    {
        IAppService<DoorDto, Guid> _service;
        public DoorController(IAppService<DoorDto, Guid> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var doors = await _service.GetAllAsync();
           return Ok(doors);
        }
    }
}