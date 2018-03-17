using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LiveJourneys.JourneyPlanningSystem.Models.Repositories
{
    public interface IBasicRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Add(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Update(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
