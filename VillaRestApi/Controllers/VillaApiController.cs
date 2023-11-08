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
        // Get all villas in the database
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        public ActionResult<IEnumerable<VillaDto>> GetVillas() {
            return Ok(VillaDatastore.VillaList);
        }


        // Get a single villa from the database 

        [HttpGet("{id:int}")]
        //[ProducesResponseType(200, Type = typeof(VillaDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult<VillaDto> GetVilla(int id)
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

        // Add new villa in the database
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villaDto) {

          if(villaDto == null)
            {
                return BadRequest(villaDto);
            }    

          if(villaDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

          villaDto.Id = VillaDatastore.VillaList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;

          VillaDatastore.VillaList.Add(villaDto);

          return Ok(villaDto);
        }
    }
}
