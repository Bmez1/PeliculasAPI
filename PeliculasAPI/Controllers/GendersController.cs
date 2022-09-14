using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeliculasCore.DTOs;
using PeliculasCore.Entities;
using PeliculasCore.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<ActionResult<IEnumerable<ListGenderDTO>>> GetGenders()
        {
            try
            {
                IEnumerable<Gender> response = await _genderService.GetAllAsync();
                IEnumerable<ListGenderDTO> responseDTO = _mapper.Map<List<ListGenderDTO>>(response);

                return Ok(responseDTO);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error: {ex.Message}");
                return BadRequest("Error interno en el servidor");
            }
        }

        // GET api/<GendersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GendersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GendersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GendersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
