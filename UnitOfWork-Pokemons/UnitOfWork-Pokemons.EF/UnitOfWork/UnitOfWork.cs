using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Pokemons.Core.Interfaces;
using UnitOfWork_Pokemons.Core.Models;
using UnitOfWork_Pokemons.EF.DataContext;
using UnitOfWork_Pokemons.EF.Repositories;

namespace UnitOfWork_Pokemons.EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBaseRepository<Category> Category { get; private set; }
        public IBaseRepository<Country> Country { get; private set; }
        public IBaseRepository<Owner> Owner { get; private set; }
        public IPokemonRepository Pokemon { get; private set; }
        public IBaseRepository<Review> Review { get; private set; }
        public IBaseRepository<Reviewer> Reviewer { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
           
            Category = new BaseRepository<Category>(_context);
            Country = new BaseRepository<Country>(_context);
            Owner = new BaseRepository<Owner>(_context);
            Pokemon = new PokemonRepository(_context);
            Review = new BaseRepository<Review>(_context);
            Reviewer = new BaseRepository<Reviewer>(_context);
        }
       

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
