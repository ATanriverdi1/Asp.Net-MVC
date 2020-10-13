using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AgriDoktorum.WebApp.Models.EntityDb
{
    public class Repository<T> : RepositoryBase where T : class
    {
        private readonly DbSet<T> _dbSet;

        public Repository()
        {
            _dbSet = _context.Set<T>();
        }

        public List<T> List()
        {
            return _dbSet.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }

        public T Find(Expression<Func<T, bool>> where) => _dbSet.FirstOrDefault(@where);

        public int Insert(T obj)
        {
            _dbSet.Add(obj);
            return Save();
        }

        public int Delete(T obj)
        {
            _dbSet.Remove(obj);
            return Save();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}