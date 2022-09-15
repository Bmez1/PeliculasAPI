using PeliculasCore.DTOs;
using PeliculasCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Interfaces.Services
{
    public interface IActorService : IGenericService<Actor>
    {
        /// <summary>
        /// Finalidad: Guardar la fotografía en el local.
        /// </summary>
        /// <param name="actorDTO">Objeto con los datos a guardarse</param>
        /// <returns>Ruta que se guardará en el base de datos</returns>
        Task<string> SaveImage(ActorCreateDTO actorDTO);

        /// <summary>
        /// Finalidad: Actualizar la imágen de un autor en el local.
        /// </summary>
        /// <param name="actorDTO"></param>
        /// <param name="pathCurrentPhoto"></param>
        /// <returns>Ruta actualizada del actor para almacenar en la db.</returns>
        Task<string> UpdateImage(ActorCreateDTO actorDTO, string pathCurrentPhoto);

        /// <summary>
        /// Finalidad: Eliminar una imagen del local.
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        Task DeleteImage(string route);

    }
}
