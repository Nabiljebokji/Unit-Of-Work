using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork_Pokemons.Core.Dto;
using UnitOfWork_Pokemons.Core.Interfaces;
using UnitOfWork_Pokemons.Core.Models;

namespace UnitOfWork_Pokemons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PokemonController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<PokemonDto>> GetAllCategories()
        {
            var allcategories = await _unitOfWork.Pokemon.GetAllEntities();
            var catMap = _mapper.Map<List<PokemonDto>>(allcategories);
            return catMap;
        }

        [HttpGet("categooryId")]
        public async Task<IActionResult> GetPokemonById([FromQuery] int PokemonId)
        {
            var thisId = await _unitOfWork.Pokemon.GetEntity(PokemonId);
            var catMap = _mapper.Map<PokemonDto>(thisId);
            return Ok(catMap);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePokemon([FromBody] PokemonDto createCat, [FromQuery]int ownerId, [FromQuery] int categoryId)
        {
            var PokemonMap = _mapper.Map<Pokemon>(createCat);
             _unitOfWork.Pokemon.CreatePokemon(ownerId,categoryId, PokemonMap);
            _unitOfWork.Complete();
            return Ok(createCat);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePokemon([FromBody] PokemonDto updatedPokemon)
        {
            var PokemonMap = _mapper.Map<Pokemon>(updatedPokemon);
            await _unitOfWork.Pokemon.UpdateEntity(PokemonMap);
            _unitOfWork.Complete();
            return Ok(updatedPokemon);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePokemon([FromQuery] int PokemonId)
        {
            var thisEntity = await _unitOfWork.Pokemon.GetEntity(PokemonId);
            _unitOfWork.Pokemon.DeleteEntity(thisEntity);
            _unitOfWork.Complete();
            return Ok(thisEntity);
        }

    }
}
