using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Interfaces.Services
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        /// <summary>
        /// Finalidad: Retornar listado de la entidad correspondiente
        /// </summary>
        /// <returns><Listado de registros</returns>
        public Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Finalidad: Retorna una entidad dado el ID del registro
        /// </summary>
        /// <param name="id">id que identifica el registro</param>
        /// <returns>Retorna el registro</returns>
        public Task<TEntity> GetAsync(long id);

        /// <summary>
        /// Finalidad: Eliminar un registro de la base de datos
        /// </summary>
        /// <param name="id">Id de la entidad a eliminar</param>
        public Task<TEntity> DeleteAsync(long id);

        /// <summary>
        /// Finalidad: Actualizar un registro dentro de la base de datos
        /// </summary>
        /// <param name="entity">Entidad a actualizar</param>
        /// <param name="id">Id de la entidad a actualizar</param>
        /// <returns>Entidad actualizada o nulo</returns>
        public Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// Finalidad: Registrar una entidad dentro de la base de datos
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Entidad registrada</returns>
        public Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Finalidad: Buscar la cantidad de registros que posee una tabla
        /// </summary>
        /// <returns>Cantidad de registros de una tabla segun la entidad</returns>
        public Task<int> GetNumberRecords();

        /// <summary>
        /// Finalidad: Consultar los registros de una entidad por paginación
        /// </summary>
        /// <param name="page">Número de página</param>
        /// <param name="numberRecordsPage">Cantidad de registro por página</param>
        /// <returns></returns>
        public Task<IEnumerable<TEntity>> GetByPagination(int page, int numberRecordsPage);

    }
}