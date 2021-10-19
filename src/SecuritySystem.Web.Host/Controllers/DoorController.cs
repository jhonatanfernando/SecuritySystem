using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SecuritySystem.Application.Door.Dto;
using SecuritySystem.Application.Services;
using SecuritySystem.Application.Services.Door;
using SecuritySystem.Core.Models;
using SecuritySystem.Core.Repositories;

namespace SecuritySystem.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorController :  ControllerBase
    {
        IDoorAppService _service;
        public DoorController(IDoorAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAll()
        {
           var doors = await _service.GetAllAsync();
           return Ok(doors);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
           if(id == Guid.Empty)
              return BadRequest();

           var door = await _service.GetAsync(id);
           return Ok(door);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(DoorInsertDto entity)
        {
             if(entity == null)
                return BadRequest();

             var door = await _service.InsertAsync(entity); 

             return Ok(door);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(DoorInsertDto entity)
        {
             if(entity == null)
                return BadRequest();

             var door = await _service.UpdateAsync(entity); 

             return Ok(door);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid guid)
        {
             if(guid == Guid.Empty)
                return BadRequest();

             await _service.DeleteAsync(guid); 

             return Ok();
        }

        [HttpPut]
        [Route("Open")]
        public async Task<IActionResult> Open(OpenDoorDto openDoorDto)
        {
             if(openDoorDto == null || openDoorDto.DoorId == Guid.Empty || openDoorDto.KeyCardId == Guid.Empty)
                return BadRequest();

             var result = await _service.OpenDoor(openDoorDto.DoorId, openDoorDto.KeyCardId); 

             return Ok(result);
        }

        [HttpGet]
        [Route("AllKeyCards")]
        public async Task<IActionResult> GetAllKeyCards(Guid doorId)
        {
             if(doorId == Guid.Empty)
                return BadRequest();

             var result = await _service.GetAllKeyCards(doorId); 

             return Ok(result);
        }
    
    }
}