using CommGate.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly DbContext dbContext;
        protected DbSet<TEntity> DbSet;

        public RepositoryBase(DbContext db)
        {
            dbContext = db;
            DbSet = dbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity obj)
        {
            return DbSet.Add(obj).Entity;
        }

        public TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public ICollection<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public void Update(TEntity obj)
        {
            dbContext.Entry(obj).State = EntityState.Modified;
        }

        public void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).FirstOrDefault();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate, ICollection<string> includes)
        {
            IQueryable<TEntity> query = DbSet;
            query = query.Where(predicate);
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            TEntity result = query.FirstOrDefault();

            return result;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, ICollection<string> includes)
        {
            IQueryable<TEntity> query = DbSet;
            query = query.Where(predicate);
            query = includes.Aggregate(query, (current, include) => current.Include(include));

            IEnumerable<TEntity> result = query.ToList();
            return result;
        }

    }
}
