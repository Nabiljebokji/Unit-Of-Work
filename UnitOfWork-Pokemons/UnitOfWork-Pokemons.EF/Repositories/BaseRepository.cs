using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Pokemons.Core.Interfaces;
using UnitOfWork_Pokemons.EF.DataContext;

namespace UnitOfWork_Pokemons.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<T> CreateEntity(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public T DeleteEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }

        public async Task<bool> EntityExists(int id)
        {
            var exists = await _context.Set<T>().FindAsync(id);
            if (exists == null)
                return false;
            return true;

        }

        public async Task<List<T>> GetAllEntities()
        {
            return await _context.Set<T>().ToListAsync();

        }

        public async Task<T> GetEntity(int id)
        {
            return await _context.Set<T>().FindAsync(id);

        }

        public Task<ICollection<T>> GetFirstEntityBySecondEntity(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateEntity(T entity)
        {
             _context.Set<T>().Update(entity);
            return entity;
        }
    }
}
