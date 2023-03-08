using MagicVilla_Api.Data;
using MagicVilla_Api.Logging;
using MagicVilla_Api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Api.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    
    public class VillaAPIController : ControllerBase
    {
        /*private readonly ILogger<VillaAPIController> _logger;
        public VillaAPIController(ILogger<VillaAPIController> logger)
        {
            _logger = logger;
        }*/

        //private readonly ILogging _logger;
        //public VillaAPIController(ILogging logger)
        //{
        //    _logger = logger;
        //}
        private readonly ApplicationDbContext _db;
        public VillaAPIController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            //_logger.Log("getting all villa ","");
            return Ok(_db.Villas.ToList());
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
                //_logger.Log("get villa error!" + id, "error");
                return BadRequest();
            }
            var villa=_db.Villas.FirstOrDefault(x => x.Id == id);
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

            if (_db.Villas.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower())!=null)
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

            Villa modelVilla = new ()
            {
                Name = villaDTO.Name,
                Description=villaDTO.Description,
                Superficie =villaDTO.Superficie,
                NbRoom=villaDTO.NbRoom,
                ImageUrl=villaDTO.ImageUrl,
                Rate=villaDTO.Rate
            };
            //villaDTO.Id = _db.Villas.OrderByDescending(x => x.Id).FirstOrDefault().Id+1; Id is autoincremante
            _db.Villas.Add(modelVilla);
            _db.SaveChanges();
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
            var villa = _db.Villas.FirstOrDefault(x => x.Id == id);

            if (villa ==null)
            {
                return NotFound();
            }
            _db.Villas.Remove(villa);
            _db.SaveChanges();
            return NoContent();
            
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

            Villa modelVilla = new ()
            {
                Id=villaDTO.Id,
                Name = villaDTO.Name,
                Description = villaDTO.Description,
                Superficie = villaDTO.Superficie,
                NbRoom = villaDTO.NbRoom,
                ImageUrl = villaDTO.ImageUrl,
                Rate = villaDTO.Rate
            };
            _db.Update(modelVilla);
            _db.SaveChanges();
            return NoContent();
            
        }

        [HttpPatch("{id:int}", Name = "UpdatePartial")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id,JsonPatchDocument<VillaDTO> patchDTO)
        {
            if (patchDTO == null || id ==0 )
            {
                return BadRequest();
            }
            var villa = _db.Villas.AsNoTracking().FirstOrDefault(x => x.Id == id);
            VillaDTO modelVilla = new()
            {
                Id = villa.Id,
                Name = villa.Name,
                Description = villa.Description,
                Superficie = villa.Superficie,
                NbRoom = villa.NbRoom,
                ImageUrl = villa.ImageUrl,
                Rate = villa.Rate
            };

            if (villa == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(modelVilla, ModelState);

            Villa model = new()
            {
                Id = villa.Id,
                Name = villa.Name,
                Description = villa.Description,
                Superficie = villa.Superficie,
                NbRoom = villa.NbRoom,
                ImageUrl = villa.ImageUrl,
                Rate = villa.Rate
            };
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Update(modelVilla);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
