using LiveJourneys.JourneyPlanningSystem.Data.Repository;
using LiveJourneys.JourneyPlanningSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveJourneys.JourneyPlanningSystem.Data
{
    public class BasicInMemoryRepository<TEntity> : IBasicRepository<TEntity> where TEntity : class, IEntity
    {
        private ICollection<TEntity> EntityCollection { get; set; } = new List<TEntity>();

        /// <summary>
        /// 
        /// </summary>
        public BasicInMemoryRepository()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initTEntityCollection"></param>
        public BasicInMemoryRepository(Func<List<TEntity>> initTEntityCollection)
        {
            this.EntityCollection = initTEntityCollection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<TEntity> Create(TEntity entity)
        {
            
            return Task<TEntity>.Factory.StartNew(() => {
                EntityCollection.Add(entity);
                return entity;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TEntity> Delete(int id)
        {
            return Task<TEntity>.Factory.StartNew(() => {
                var result = EntityCollection.Where(e => e.Id == id);
                TEntity deletedItem = null;

                if(result.Count() > 0)
                {
                    deletedItem = result.First();
                    EntityCollection.Remove(deletedItem);
                }

                return deletedItem;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll()
        {
            return EntityCollection.AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TEntity> GetById(int id)
        {
            return Task<TEntity>.Factory.StartNew(() => {
                return EntityCollection.FirstOrDefault(e => e.Id == id);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<TEntity> Update(TEntity entity)
        {
            return Task<TEntity>.Factory.StartNew(() => {
                var deletedItem = this.Delete(entity.Id);
                if(deletedItem != null)
                {
                    deletedItem = this.Create(entity);
                }

                return deletedItem.Result;
            });
        }
    }
}
