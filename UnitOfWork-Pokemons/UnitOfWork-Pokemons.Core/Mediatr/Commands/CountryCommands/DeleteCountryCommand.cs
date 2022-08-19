using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Pokemons.Core.Models;

namespace UnitOfWork_Pokemons.Core.Mediatr.Commands.CountryCommands
{
    public class DeleteCountryCommand : IRequest<Country>
    {
        public int countryId { get; set; }
    }
}
