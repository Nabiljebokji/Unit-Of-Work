using MediatR;
using UnitOfWork_Pokemons.Core.Dto;

namespace UnitOfWork_Pokemons.Core.Mediatr.Commands.CountryCommands
{
    public class CreateCountryCommand : IRequest<CountryDto>
    {
        public CountryDto countryDto { get; set; }
    }
}
