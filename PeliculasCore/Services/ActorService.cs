using PeliculasCore.DTOs;
using PeliculasCore.Entities;
using PeliculasCore.Interfaces.Repositories;
using PeliculasCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Services
{
    internal class ActorService : GenercicService<Actor>, IActorService
    {
        private readonly IGenericRepository<Actor> _repository;
        private readonly IStoreFile _storeFile;
        private const string CONTENEDOR = "wwwroot/images/Actores";

        public ActorService(IGenericRepository<Actor> repository, IStoreFile storeFile) : base(repository)
        {
            this._repository = repository;
            this._storeFile = storeFile;
        }

        public async Task<string> SaveImage(ActorCreateDTO actorDTO)
        {
            if (actorDTO.Photo != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await actorDTO.Photo.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(actorDTO.Photo.FileName);
                    return await _storeFile.SaveFile(contenido, extension, CONTENEDOR, actorDTO.Photo.ContentType);
                }
            }

            return null;
        }

        public async Task<string> UpdateImage(ActorCreateDTO actorDTO, string pathCurrentPhoto)
        {
            if (actorDTO.Photo != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await actorDTO.Photo.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(actorDTO.Photo.FileName);
                    return await _storeFile.EditFile(contenido, extension, CONTENEDOR, pathCurrentPhoto, actorDTO.Photo.ContentType);
                }
            }

            return null;
        }

        public async Task DeleteImage(string route)
        {
            await _storeFile.DeleteFile(route, CONTENEDOR);
        }
    }
}
