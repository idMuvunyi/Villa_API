using Microsoft.AspNetCore.Mvc;
using VillaRestApi.Data;
using VillaRestApi.Models;
using VillaRestApi.Models.Dto;

namespace VillaRestApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class VillaApiController: ControllerBase

    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        public ActionResult<IEnumerable<VillaDto>> GetVillas() {
            return Ok(VillaDatastore.VillaList);
        }

        [HttpGet("{id:int}")]
        //[ProducesResponseType(200, Type = typeof(VillaDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult<VillaDto> getVilla(int id)
        { 
            if(id == 0)
            {
                return BadRequest();
            }
            var villa = Ok(VillaDatastore.VillaList.FirstOrDefault(v => v.Id == id));
            if (villa == null) 
            {
                return NotFound();
            }

            return Ok(villa);
           
        }
    }
}
