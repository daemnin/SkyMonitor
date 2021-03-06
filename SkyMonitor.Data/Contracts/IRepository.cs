﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SkyMonitor.Data.Contracts
{
    public interface IRepository<TEntity>
    {
        TEntity Create(TEntity entity);
        TEntity Delete<TKey>(TKey id);
        IList<TEntity> Delete(Expression<Func<TEntity, bool>> predicate);
        IList<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
        TEntity Read<TKey>(TKey id, params Expression<Func<TEntity, object>>[] includes);
        TEntity Read(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        TEntity Update(TEntity entity);
        bool Any(Expression<Func<TEntity, bool>> predicate);
    }
}
