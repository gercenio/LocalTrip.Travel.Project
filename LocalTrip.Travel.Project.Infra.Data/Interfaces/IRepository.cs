using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LocalTrip.Travel.Project.Infra.Data.Interfaces
{
    
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity _obj);
        void Update(TEntity _obj);
        void Remove(TEntity _obj);
        void Dispose();
        Task<IEnumerable<TEntity>> GetAllAsync();
        TEntity GetById(int id);
        void Detach(TEntity _obj);
        void Attach(TEntity _obj);
        Task<Tuple<IEnumerable<TEntity>, int>> GetAllAsync
        (
            int skip,
            int take,
            Expression<Func<TEntity, bool>> where,
            bool asNoTracking = true
        );
    }
}