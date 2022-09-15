using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using PeliculasAPI.Herlpers;
using PeliculasCore.DTOs;
using PeliculasCore.Entities;
using PeliculasCore.Interfaces.Services;
using PeliculasCore.Services;

namespace PeliculasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;
        private readonly ILogger<ActorsController> _logger;
        private readonly IMapper _mapper;

        public ActorsController(IActorService actorService, ILogger<ActorsController> logger, IMapper mapper)
        {
            this._actorService = actorService;
            this._logger = logger;
            this._mapper = mapper;
        }

        // GET: api/<ActorsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> GetActors()
        {
            try
            {
                IEnumerable<Actor> listActors = await _actorService.GetAllAsync(); 
                IEnumerable<ActorDTO> listActorsDTO = _mapper.Map<IEnumerable<ActorDTO>>(listActors);
                return Ok(listActorsDTO);                

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {ex.Message}");
                return BadRequest(ResponseAPI.ERROR_GENERAL);
            }
        }

        // GET api/<ActorsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActorDTO>> GetActorByID(long id)
        {
            try
            {
                Actor actorResponse = await _actorService.GetAsync(id);
                if (actorResponse != null)
                {
                    ActorDTO actorDTO = _mapper.Map<ActorDTO>(actorResponse);
                    return Ok(actorDTO);
                }
                else
                {
                    return NotFound(ResponseAPI.EntityNotFound(id));
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return BadRequest(ResponseAPI.ERROR_GENERAL);
            }
        }

        // POST api/<ActorsController>
        [HttpPost]
        public async Task<ActionResult> PostActor([FromForm] ActorCreateDTO actorDTO)
        {
            try
            {
                Actor actorAdd = _mapper.Map<Actor>(actorDTO);
                // Guardando la imágen en el local
                actorAdd.Photo = await _actorService.SaveImage(actorDTO);
                // Guardando la imágen en la db
                await _actorService.AddAsync(actorAdd);
                ActorDTO actorResponse = _mapper.Map<ActorDTO>(actorAdd);
                return new CreatedAtActionResult("GetActorByID", "Actors", new { id = actorAdd.Id }, actorResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al insertar el objeto: {ex.Message}");
                return BadRequest(ResponseAPI.ERROR_GENERAL);
            }

        }

        // PUT api/<ActorsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutActor(long id, [FromForm] ActorCreateDTO actorCreateDTO)
        {
            try
            {
                // Verificando que exista el registro
                Actor actorUpdate = await _actorService.GetAsync(id);
                if (actorUpdate == null) return NotFound(ResponseAPI.EntityNotFound(id));

                // Copiando las propiedades del dto a la entidad
                actorUpdate = _mapper.Map(actorCreateDTO, actorUpdate);

                //Actualizando la ruta de la imagen en el proyecto
                actorUpdate.Photo = await _actorService.UpdateImage(actorCreateDTO, actorUpdate.Photo);

                // Actualizando los datos en la base de datos
                ActorDTO actorDto = _mapper.Map<ActorDTO>(await _actorService.UpdateAsync(actorUpdate));

                return Ok(ResponseAPI.EntityUpdate(actorUpdate));                   

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al insertar el objeto: {ex.Message}");
                return BadRequest(ResponseAPI.ERROR_GENERAL);
            }

        }

        // DELETE api/<ActorsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActor(long id)
        {
            try
            {
                Actor actorDelete = await _actorService.GetAsync(id);
                if (actorDelete == null) return NotFound(ResponseAPI.EntityNotFound(id));

                await _actorService.DeleteImage(actorDelete.Photo);
                await _actorService.DeleteAsync(id);
                return Ok(ResponseAPI.EntityDelete(id));
                    
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al insertar el objeto: {ex.Message}");
                return BadRequest(ResponseAPI.ERROR_GENERAL);
            }
        }
    }
}
