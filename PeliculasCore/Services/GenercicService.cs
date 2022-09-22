using PeliculasCore.Interfaces.Repositories;
using PeliculasCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Services
{
    public class GenercicService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenercicService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            return entity;
        }

        public Task<int> GetNumberRecords()
        {
            return _repository.GetNumberRecords();
        }

        public async Task<IEnumerable<TEntity>> GetByPagination(int page, int numberRecordsPage)
        {
            return await _repository.GetByPagination(page, numberRecordsPage);
        }

        public virtual async Task<TEntity> DeleteAsync(long id)
        {
            TEntity entity = await _repository.GetAsync(id);
            if (entity != null)
            {
               await _repository.DeleteAsync(entity);
            }
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<TEntity> GetAsync(long id)
        {
            return await _repository.GetAsync(id);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
            return entity;
        }
    }
}
