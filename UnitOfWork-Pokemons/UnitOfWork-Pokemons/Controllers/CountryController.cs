using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork_Pokemons.Core.Dto;
using UnitOfWork_Pokemons.Core.Interfaces;
using UnitOfWork_Pokemons.Core.Mediatr.Commands.CountryCommands;
using UnitOfWork_Pokemons.Core.Mediatr.Queries.CountryQueries;
using UnitOfWork_Pokemons.Core.Models;


namespace UnitOfWork_Pokemons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<List<CountryDto>> GetCountriesAsync()
        {
            var query = new GetAllCountriesQuery();
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet("countryId")]
        public async Task<IActionResult> GetCountryById(int countryId)
        {
            var query = new GetCountryIDQuery() { countryId = countryId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody] CountryDto countryDto)
        {
            var command = new CreateCountryCommand() { countryDto = countryDto };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCountry([FromBody] CountryDto country)
        {
            var command = new UpdateCountryCommand() {  countryDto = country };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCountry([FromQuery] int countryId)
        {
            var command = new DeleteCountryCommand() { countryId = countryId };
            var result = await _mediator.Send(command);
            return Ok(result);
        }


    }
}
