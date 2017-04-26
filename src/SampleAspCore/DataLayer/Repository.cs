using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SampleAspCore.DataLayer.Interfaces;

namespace SampleAspCore.DataLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dataContext;

        public Repository()
        {
            _dataContext = new DataContext();
        }

        private DbSet<T> DbSet()
        {
            return _dataContext.Set<T>();
        }

        public IQueryable<T> All()
        {
            return DbSet().AsQueryable();
        }

        public IQueryable<T> Table()
        {
            return DbSet();
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            var dbSet = DbSet().Where(predicate).AsQueryable();

            if (includes == null || !includes.Any()) return dbSet;

            return includes.Aggregate(dbSet, (current, include) => current.Include(include));
        }

        public T Find(params object[] keys)
        {
            return DbSet().Find(keys);
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet().FirstOrDefault(predicate);
        }

        public T Insert(T entity)
        {
            DbSet().Add(entity);

            return entity;
        }

        public void Update(T entity)
        {
            DbSet().Attach(entity);

            _dataContext.Entry(entity).State = EntityState.Modified;

        }

        public void Delete(T entity)
        {
            DbSet().Remove(entity);
        }
    }
}
