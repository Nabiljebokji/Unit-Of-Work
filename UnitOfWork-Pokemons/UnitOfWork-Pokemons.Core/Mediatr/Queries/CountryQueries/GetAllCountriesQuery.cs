﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Pokemons.Core.Dto;

namespace UnitOfWork_Pokemons.Core.Mediatr.Queries.CountryQueries
{
    public class GetAllCountriesQuery : IRequest<List<CountryDto>>
    {
    }
}
