using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepsitoryPatternWithUOW.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public T GetById(int id);
        public Task<T> GetByIdAsync(int id);
        public Task<List<T>> GetAll();
        public T Find(Expression<Func<T, bool>> match, string[] includes = null);
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includ = null);
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int? take, int? skip);

        public T AddEntity(T entity);
        public T DeleteEntity(T entity);
        public T UpdateEntity(T entity);
        public int Count(Expression<Func<T, bool>> match);
    }
}