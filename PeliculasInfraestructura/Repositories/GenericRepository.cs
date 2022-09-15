using Microsoft.EntityFrameworkCore;
using PeliculasCore.Interfaces.Repositories;
using PeliculasInfraestructura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasInfraestructura.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDBContext _dbContext;
        private DbSet<TEntity> _db;

        public GenericRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            _db = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _db.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _db.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _db.ToListAsync();

        public async Task<TEntity> GetAsync(long id) => await _db.FindAsync(id);

        public async Task UpdateAsync(TEntity entity)
        {
            _db.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<TEntity>> FindByFilterAsync(Expression<Func<TEntity, bool>> expression) =>
            await _db.Where(expression).ToListAsync();
    }
}
