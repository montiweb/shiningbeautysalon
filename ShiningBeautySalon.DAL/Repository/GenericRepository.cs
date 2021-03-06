﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using ShiningBeautySalon.Core.Repository;
using ShiningBeautySalon.DAL.Context;

namespace ShiningBeautySalon.DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ShiningContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ShiningContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query;

            if (filter != null)
            {
                query = GetAll().Where(filter);
            }
            else
            {
                query = GetAll();
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).FirstOrDefaultAsync();
        }

        public void Save(TEntity Entity)
        {
            if (_context.Entry(Entity).State == EntityState.Detached)
            {
                _dbSet.Attach(Entity);
            }

            _context.Entry(Entity).State = _context.Entry(Entity).IsKeySet ?
                                   EntityState.Modified:
                                   EntityState.Added;

            switch (_context.Entry(Entity).State)
            {
                case EntityState.Modified:
                    _dbSet.Update(Entity);
                    break;
                case EntityState.Added:
                    _dbSet.Add(Entity);
                    break;
                case EntityState.Unchanged:
                    //item already in db no need to do anything  
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void AddRange(IEnumerable<TEntity> entityList) => _dbSet.AddRange(entityList);

        public void Remove(TEntity Entity)
        {
            if (_context.Entry(Entity).State == EntityState.Detached)
            {
                _dbSet.Attach(Entity);
            }

            _dbSet.Remove(Entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entityList) => _dbSet.RemoveRange(entityList);

        public int CommitRepository()
        {
            return _context.SaveChanges();
        }
    }
}
