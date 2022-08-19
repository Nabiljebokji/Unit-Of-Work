﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Pokemons.Core.Dto;

namespace UnitOfWork_Pokemons.Core.Mediatr.Commands.CountryCommands
{
    public class UpdateCountryCommand : IRequest<CountryDto>
    {
        public CountryDto countryDto { get; set; }
    }
}
