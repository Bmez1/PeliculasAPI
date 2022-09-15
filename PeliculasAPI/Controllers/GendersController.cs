using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PeliculasCore.DTOs;
using PeliculasCore.Entities;
using PeliculasCore.Interfaces.Services;
using PeliculasAPI.Herlpers;


namespace PeliculasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IGenderService _genderService;
        private readonly ILogger<GendersController> _logger;
        private readonly IMapper _mapper;

        public GendersController(IGenderService genderService, ILogger<GendersController> logger, IMapper mapper)
        {
            this._genderService = genderService;
            this._logger = logger;
            this._mapper = mapper;
        }

        // GET: api/<GendersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenderDTO>>> GetGenders()
        {
            try
            {
                IEnumerable<Gender> response = await _genderService.GetAllAsync();
                IEnumerable<GenderDTO> responseDTO = _mapper.Map<List<GenderDTO>>(response);

                return Ok(responseDTO);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error: {ex.Message}");
                return BadRequest(ResponseAPI.ERROR_GENERAL);
            }
        }

        // GET api/<GendersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenderDTO>> GetGenderByID(long id)
        {
            try
            {
                Gender response = await _genderService.GetAsync(id);
                if (response is not null)
                {
                    return Ok(_mapper.Map<GenderDTO>(response));
                }
                else
                {
                    return NotFound(ResponseAPI.EntityNotFound(id));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error interno: " + ex.Message);
                return BadRequest(ResponseAPI.ERROR_GENERAL);
            }
        }

        // POST api/<GendersController>
        [HttpPost]
        public async Task<ActionResult> CreateGender([FromBody] GenderCreateDTO genderDTO)
        {
            try
            {
                Gender genderAdd = _mapper.Map<Gender>(genderDTO);
                await _genderService.AddAsync(genderAdd);

                return StatusCode(201, ResponseAPI.EntityInsertedSuccess(_mapper.Map<GenderDTO>(genderAdd)));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al insertar el objeto: {ex.Message}");
                return BadRequest(ResponseAPI.ERROR_GENERAL);
            }
        }

        // PUT api/<GendersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] GenderCreateDTO genderDTO)
        {
            try
            {
                Gender genderUpdate = await _genderService.GetAsync(id);
                if (genderUpdate == null) return NotFound(ResponseAPI.EntityNotFound(id));

                genderUpdate = _mapper.Map(genderDTO, genderUpdate);
                GenderDTO response = _mapper.Map<GenderDTO>(await _genderService.UpdateAsync(genderUpdate));

                return Ok(ResponseAPI.EntityUpdate(response));                    

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ResponseAPI.ERROR_GENERAL);
            }


        }

        // DELETE api/<GendersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                return await _genderService.DeleteAsync(id) is not null ? Ok(ResponseAPI.EntityDelete(id)) :
                    NotFound(ResponseAPI.EntityNotFound(id));

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ResponseAPI.ERROR_GENERAL);
            }
        }
    }
}
