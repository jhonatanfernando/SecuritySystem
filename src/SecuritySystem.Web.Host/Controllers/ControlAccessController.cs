using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SecuritySystem.Application.ControlAccess.Dto;
using SecuritySystem.Application.Services;
using SecuritySystem.Application.Services.ControlAccess;

namespace SecuritySystem.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlAccessController :  ControllerBase
    {
        IControlAccessAppService _service;
        public ControlAccessController(IControlAccessAppService service)
        {
            _service = service;
        }

        [HttpPut]
        [Route("GiveAccess")]
        public async Task<IActionResult> Update(ControlAccessInsertDto entity)
        {
             if(entity == null)
                return BadRequest();

             var controlAccess = await _service.GiveAccess(entity); 

             return Ok(controlAccess);
        }
    }
}