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

        [HttpGet("{id:int}", Name ="GetVilla")]
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
        [ProducesResponseType(409)]

        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villaDto) {

            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (VillaDatastore.VillaList.FirstOrDefault(u => u.Name.ToLower() == villaDto.Name.ToLower()) != null){
                 ModelState.AddModelError("CustomError", "Name already exists");
                return Conflict(ModelState);
            }

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

            return CreatedAtRoute("GetVilla", new { id = villaDto.Id }, villaDto);
        }

        [HttpDelete("{id:int}", Name ="DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var villa = VillaDatastore.VillaList.FirstOrDefault(u => u.Id == id);

            if(villa == null)
            {
                return NotFound();
            }

            VillaDatastore.VillaList.Remove(villa);

            return NoContent();
        }

        [HttpPut("{id:int}", Name ="UpdateVilla")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<VillaDto> UpdateVila(int id, [FromBody]VillaDto villaDto)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var villa = VillaDatastore.VillaList.FirstOrDefault(u => u.Id == id);
            if (villa == null || villaDto.Id != id)
            {
                return NotFound();  
            }

            villa.Name = villaDto.Name;
            villa.Owner = villaDto.Owner;
            villa.PlotArea = villaDto.PlotArea;
            villa.CreatedDate = villaDto.CreatedDate;

            return NoContent() ;

        } 
    }
}
