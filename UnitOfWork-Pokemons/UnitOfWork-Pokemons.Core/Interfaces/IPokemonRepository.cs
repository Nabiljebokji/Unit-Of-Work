using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Pokemons.Core.Models;

namespace UnitOfWork_Pokemons.Core.Interfaces
{
    public interface IPokemonRepository : IBaseRepository<Pokemon>
    {
        public  Task<Pokemon> CreatePokemon(int ownerId, int categoryId, Pokemon pokemon);
       
    }
}
