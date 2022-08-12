using Microsoft.EntityFrameworkCore;
using RepsitoryPatternWithUOW.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepsitoryPatternWithUOW.EF.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public T AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public int Count(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Count(match); 
        }

        public T DeleteEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }

        public T Find(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

            return query.SingleOrDefault(match);
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

            return query.Where(match).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int? take, int? skip)
        {
            IQueryable<T> query = _context.Set<T>();

            if (skip.HasValue && take.HasValue)
                return query.Where(match).Skip(skip.Value).Take(take.Value).ToList();

            if (take.HasValue)
                return query.Where(match).Take(take.Value).ToList();

            if (skip.HasValue)
                return query.Where(match).Skip(skip.Value).ToList();

            return query.Where(match).ToList();

        }
        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T UpdateEntity(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
    }
}
