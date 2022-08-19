using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork_Pokemons.Core.Dto;
using UnitOfWork_Pokemons.Core.Interfaces;
using UnitOfWork_Pokemons.Core.Mediatr.Commands.CategoryCommands;
using UnitOfWork_Pokemons.Core.Mediatr.Queries.CategoryQueries;
using UnitOfWork_Pokemons.Core.Models;

namespace UnitOfWork_Pokemons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {

            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var query = new GetAllCategoriesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("categooryId")]
        public async Task<IActionResult> GetCategoryById([FromQuery] int categoryId)
        {
            var query = new GetCategoryIDQuery() { categoryId = categoryId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto createCat)
        {
            var command = new CreateCategoryCommand() { categoryDto = createCat };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryDto updatedCategory)
        {
            var command = new UpdateCategoryIdCommand() { updatedCategory = updatedCategory };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory([FromQuery] int categoryId)
        {
            var command = new DeleteCategoryCommand() { categoryId = categoryId };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
