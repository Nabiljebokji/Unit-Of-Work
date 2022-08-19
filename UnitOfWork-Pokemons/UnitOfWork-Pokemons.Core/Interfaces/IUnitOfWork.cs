using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Pokemons.Core.Models;

namespace UnitOfWork_Pokemons.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IBaseRepository<Category> Category { get; }
        public IBaseRepository<Country> Country { get; }
        public IBaseRepository<Owner> Owner { get; }
        public IPokemonRepository Pokemon { get; }
        public IBaseRepository<Review> Review { get; }
        public IBaseRepository<Reviewer> Reviewer { get; }
        public int Complete();
    }
}
