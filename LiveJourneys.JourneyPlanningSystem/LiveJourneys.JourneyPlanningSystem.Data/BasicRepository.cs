using LiveJourneys.JourneyPlanningSystem.Data.Repository;
using LiveJourneys.JourneyPlanningSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace LiveJourneys.JourneyPlanningSystem.Data
{
    public class BasicRepository<TEntity> : IBasicRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly JourneyPlanningSystemDbContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public BasicRepository(JourneyPlanningSystemDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> Delete(int id)
        {
            var entity = await this.GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            return await _dbContext.SaveChangesAsync();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> Update(TEntity entity)
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();

        }
    }
}
