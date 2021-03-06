﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace ShiningBeautySalon.Core.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "");
        Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Save(TEntity entity);
        void AddRange(IEnumerable<TEntity> entityList);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entityList);
        int CommitRepository();
    }
}
