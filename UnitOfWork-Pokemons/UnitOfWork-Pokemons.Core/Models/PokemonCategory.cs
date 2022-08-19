﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork_Pokemons.Core.Models
{
    public class PokemonCategory
    {
        public int PokemonId { get; set; }
        public int CategoryId { get; set; }
        public Pokemon Pokemon { get; set; }
        public Category Category { get; set; }
    }
}
