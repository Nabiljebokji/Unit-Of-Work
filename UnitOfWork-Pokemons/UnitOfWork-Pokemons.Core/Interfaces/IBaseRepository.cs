using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork_Pokemons.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<List<T>> GetAllEntities();
        public Task<T> GetEntity(int id);
        public Task<ICollection<T>> GetFirstEntityBySecondEntity(int Id);
        public Task<bool> EntityExists(int id);
        public Task<T> CreateEntity(T entity);
        public Task<T> UpdateEntity(T entity);
        public T DeleteEntity(T entity);
        
    }
}
