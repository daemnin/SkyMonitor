using SkyMonitor.Data.Contracts;
using SkyMonitor.Data.Extensions;
using SkyMonitor.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SkyMonitor.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected IDbSet<TEntity> Entities { get; set; }

        protected IContext CurrentContext { get; private set; }

        public Repository(IContext context)
        {
            CurrentContext = context;
            Entities = CurrentContext.Set<TEntity>();
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Any(predicate);
        }

        public TEntity Create(TEntity entity)
        {
            return Entities.Add(entity);
        }

        public TEntity Delete<TKey>(TKey id)
        {
            var entity = Entities.Find(id);
            Entities.Remove(entity);
            return entity;
        }

        public IList<TEntity> Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = FindBy(predicate);
            foreach (var entity in entities)
            {
                Entities.Remove(entity);
            }
            return entities;
        }

        public IList<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return Entities.IncludeMultiple(includes).Where(predicate).ToList();
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = Entities;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includes != null)
            {
                query = query.IncludeMultiple(includes);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity Read<TKey>(TKey id, params Expression<Func<TEntity, object>>[] includes)
        {
            if (includes.Any())
            {
                Entities.IncludeMultiple(includes).Load();
            }
            return Entities.Find(id);
        }

        public TEntity Read(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            if (includes.Any())
            {
                Entities.IncludeMultiple(includes).Load();
            }

            return Entities.FirstOrDefault(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            Entities.Attach(entity);
            CurrentContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
