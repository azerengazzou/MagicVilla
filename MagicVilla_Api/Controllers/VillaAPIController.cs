﻿using AutoMapper;
using MagicVilla_Api.Data;
using MagicVilla_Api.Logging;
using MagicVilla_Api.Models;
using MagicVilla_Api.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;

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
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;

        protected APIResponse _response;
        public VillaAPIController(ApplicationDbContext db,IMapper mapper,IVillaRepository dbVilla)
        {
            _db = db;
            _mapper = mapper;
            _dbVilla = dbVilla;
            this._response=new ();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            //_logger.Log("getting all villa ","");
            
            IEnumerable<Villa> villaList= await _dbVilla.GetAllAsync();
            _response.Result = _mapper.Map<List<VillaDTO>>(villaList);
            _response.StatusCode=HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpGet("{id:int}",Name ="GetVilla")]
        //[ProducesResponseType(200,Type=typeof(VillaDTO))]
        //[ProducesResponseType(404)] //notfound
        //[ProducesResponseType(400)] //badrequest

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> GetVilla(int id)
        {

            if(id == 0)
            {
                //_logger.Log("get villa error!" + id, "error");
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsError = true;
                return (_response);
            }
            var villa= await _dbVilla.GetAsync(x => x.Id == id);
            
            if(villa == null)
            {
                _response.StatusCode=HttpStatusCode.NotFound;
                _response.IsError = true;
                return (_response);
            }
            _response.Result = _mapper.Map<VillaDTO>(villa);
            return Ok(_response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaCreateDTO villaCreateDTO)
        {

            if (await _dbVilla.GetAsync(u => u.Name.ToLower() == villaCreateDTO.Name.ToLower())!=null)
            {
                ModelState.AddModelError("CustomError", "Villa already exist!");

                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsError = true;
                return (_response);
            }
            if(villaCreateDTO == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsError = true;
                return (_response);
            }

            Villa model = _mapper.Map<Villa>(villaCreateDTO);
            //villaDTO.Id = _db.Villas.OrderByDescending(x => x.Id).FirstOrDefault().Id+1; Id is autoincremante
            await _dbVilla.CreateAsync(model);
            return CreatedAtRoute("GetVilla", new { id = model.Id },model);
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteVilla(int id)
        {
            if(id == 0) {
                return BadRequest();
            }
            var villa = await _dbVilla.GetAsync(x => x.Id == id);

            if (villa ==null)
            {
                return NotFound();
            }
            await _dbVilla.RemoveAsync(villa);
            await _dbVilla.Save();
            return NoContent();
            
        }

        [HttpPut("{id:int}",Name ="UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateVilla([FromBody] VillaUpdateDTO villaUpdateDTO,int id)
        {
            if (villaUpdateDTO == null || id != villaUpdateDTO.Id) {
                return BadRequest();
            }

            Villa model=_mapper.Map<Villa>(villaUpdateDTO);
            await _dbVilla.UpdateAsync(model);
            await _dbVilla.Save();
            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartial")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVilla(int id,JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id ==0 )
            {
                return BadRequest();
            }
            var villa = await _dbVilla.GetAsync(x => x.Id == id,tracked:false);
            VillaUpdateDTO villatopatch = _mapper.Map<VillaUpdateDTO>(villa);

            if (villa == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(villatopatch, ModelState);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Villa villatodb = _mapper.Map<Villa>(villatopatch);
            await _dbVilla.UpdateAsync(villatodb);
            return NoContent();
        }
    }
}
