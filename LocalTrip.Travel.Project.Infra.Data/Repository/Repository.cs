using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LocalTrip.Travel.Project.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocalTrip.Travel.Project.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Property

        protected Context.MySql.MySqlContext Db = new Context.MySql.MySqlContext();
        protected DbSet<TEntity> DbSet = new Context.MySql.MySqlContext().Set<TEntity>();

        public IDbConnection Conn { get; set; }
        
        #endregion
        
        #region # Methods

        public void Add(TEntity _obj)
        {
            Db.Set<TEntity>().Add(_obj);
            Db.SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Db.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity _obj)
        {
            Db.Set<TEntity>().Remove(_obj);
            Db.SaveChanges();
        }

        public void Update(TEntity _obj)
        {
            Db.Entry(_obj).State = EntityState.Modified;

            Db.SaveChanges();
        }

        public void Detach(TEntity _obj)
        {
            Db.Entry(_obj).State = EntityState.Detached;
        }

        public void Attach(TEntity _obj)
        {
            DbSet.Attach(_obj);
        }
        
        #endregion

        #region # IDisponsable

        private Component component = new Component();
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    component.Dispose();

                disposed = true;
            }
        }
        #endregion
    }
}