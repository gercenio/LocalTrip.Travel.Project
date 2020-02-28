using System.Collections.Generic;

namespace LocalTrip.Travel.Project.Infra.Data.Interfaces
{
    
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity _obj);
        void Update(TEntity _obj);
        void Remove(TEntity _obj);
        void Dispose();
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Detach(TEntity _obj);
        void Attach(TEntity _obj);
    }
}