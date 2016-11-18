using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Linq;
using System.Collections;

namespace SudokuApp.Repository
{
    /// <summary>
    /// Repository pattern to encapsulate queries
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        // never return IQueryable<>
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        // queryable
        public Expression Expression
        {
            get
            {
                var queryable = (IQueryable<TEntity>) Context.Set<TEntity>();
                return queryable.Expression;
            }
        }

        public Type ElementType
        {
            get
            {
                var queryable = (IQueryable<TEntity>)Context.Set<TEntity>();
                return queryable.ElementType;
            }
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            var queryable = (IQueryable<TEntity>)Context.Set<TEntity>();
            return queryable.GetEnumerator();
        }


        // Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Repository()
        {
            Dispose(false);
        }
    }
}