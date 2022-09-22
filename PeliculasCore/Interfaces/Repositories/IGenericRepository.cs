using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
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
        /// <param name="entity">Entidad a eliminar</param>
        public Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Finalidad: Actualizar un registro dentro de la base de datos
        /// </summary>
        /// <param name="entity">Entidad a actualizar</param>
        /// <returns>Entidad actualizada</returns>
        public Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Finalidad: Registrar una entidad dentro de la base de datos
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Entidad registrada</returns>
        public Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Finalidad: Busqueda por filtro
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Lista de entidades filtradas dada una condición</returns>
        public Task<IEnumerable<TEntity>> FindByFilterAsync(Expression<Func<TEntity, bool>> expression);
        
        /// <summary>
        /// Finalidad: Realizar la consulta de una entidad por paginación
        /// </summary>
        /// <param name="page">Número de la página a consultar</param>
        /// <param name="numberRecordsPage">Cantidad de registros a buscar</param>
        /// <returns></returns>
        public Task<IEnumerable<TEntity>> GetByPagination(int page, int numberRecordsPage);

        /// <summary>
        /// Finalidad: Devolver la cantidad de registros de una entidad en la db
        /// </summary>
        /// <returns>Valor numerico con la cantidad de registros de una entidad</returns>
        public Task<int> GetNumberRecords();
    }
}