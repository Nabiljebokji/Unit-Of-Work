using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork_Pokemons.Core.Dto;
using UnitOfWork_Pokemons.Core.Interfaces;
using UnitOfWork_Pokemons.Core.Mediatr.Commands.ReviewCommands;
using UnitOfWork_Pokemons.Core.Mediatr.Queries.ReviewQueries;
using UnitOfWork_Pokemons.Core.Models;

namespace UnitOfWork_Pokemons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ReviewController(IMediator mediator)
    {
            _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<ReviewDto>> GetAllReview()
    {
            var query = new GetAllReviewQuery();
            var result = await _mediator.Send(query);
            return result;
        }

    [HttpGet("categooryId")]
    public async Task<IActionResult> GetReviewById([FromQuery] int reviewId)
    {
            var query = new GetReviewIDQuery() { reviewId = reviewId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    [HttpPost]
    public async Task<IActionResult> CreateReview([FromQuery] int reviewerId, [FromQuery] int pokeId, [FromBody] ReviewDto reviewCreate)
        {
            var command = new CreateReviewCommand() { reviewDto = reviewCreate, pokeId= pokeId, reviewerId= reviewerId };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    [HttpPut]
    public async Task<IActionResult> UpdateReview([FromBody] ReviewDto updatedReview)
    {
            var command = new UpdateReviewCommand() { reviewDto = updatedReview };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    [HttpDelete]
    public async Task<IActionResult> DeleteReview([FromQuery] int reviewId)
    {
            var command = new DeleteReviewCommand() { reviewId = reviewId };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

}
}
