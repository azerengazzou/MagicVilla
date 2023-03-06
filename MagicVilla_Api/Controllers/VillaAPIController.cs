using MagicVilla_Api.Data;
using MagicVilla_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_Api.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(VillaStore.VillaList);
        }

        [HttpGet("{id:int}",Name ="GetVilla")]
        //[ProducesResponseType(200,Type=typeof(VillaDTO))]
        //[ProducesResponseType(404)] //notfound
        //[ProducesResponseType(400)] //badrequest

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var villa=VillaStore.VillaList.FirstOrDefault(x => x.Id == id);
            if(villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            //    if (!ModelState.IsValid)
            //    {
            //        return BadRequest(ModelState);
            //    }

            if (VillaStore.VillaList.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower())!=null)
            {
                ModelState.AddModelError("CustomError", "Villa already exist!");
                return BadRequest(ModelState);
            }

            if(villaDTO == null)
            {
                return BadRequest(villaDTO);
            }

            if(villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            villaDTO.Id = VillaStore.VillaList.OrderByDescending(x => x.Id).FirstOrDefault().Id+1;
            VillaStore.VillaList.Add(villaDTO) ;
            return CreatedAtRoute("GetVilla", new { id = villaDTO.Id },villaDTO);
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteVilla(int id)
        {
            if(id == 0) {
                return BadRequest();
            }
            var villa = VillaStore.VillaList.FirstOrDefault(x => x.Id == id);
            if (villa ==null)
            {
                return NotFound();
            }

            if (VillaStore.VillaList.Remove(villa))
            {
                //return NoContent();
                return Ok("Hello it's me azer");
            }
            else
            {
                return Ok("Not deleted");
            }
        }


        [HttpPut("{id:int}",Name ="UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateVilla([FromBody] VillaDTO villaDTO,int id)
        {
            if (villaDTO == null || id != villaDTO.Id) {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var villa = VillaStore.VillaList.FirstOrDefault(x => x.Id == id);
            
            villa.Name = villaDTO.Name;
            villa.NbRoom = villaDTO.NbRoom;
            villa.Superficie = villaDTO.Superficie;
            return NoContent();
            
        }
    }
}
