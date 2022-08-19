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
    public class ReviewerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<ReviewerDto>> GetAllCategories()
        {
            var allcategories = await _unitOfWork.Reviewer.GetAllEntities();
            var catMap = _mapper.Map<List<ReviewerDto>>(allcategories);
            return catMap;
        }

        [HttpGet("categooryId")]
        public async Task<IActionResult> GetReviewerById([FromQuery] int ReviewerId)
        {
            var thisId = await _unitOfWork.Reviewer.GetEntity(ReviewerId);
            var catMap = _mapper.Map<ReviewerDto>(thisId);
            return Ok(catMap);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReviewer([FromBody] ReviewerDto createCat)
        {
            var ReviewerMap = _mapper.Map<Reviewer>(createCat);
            await _unitOfWork.Reviewer.CreateEntity(ReviewerMap);
            _unitOfWork.Complete();
            return Ok(createCat);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReviewer([FromBody] ReviewerDto updatedReviewer)
        {
            var ReviewerMap = _mapper.Map<Reviewer>(updatedReviewer);
            await _unitOfWork.Reviewer.UpdateEntity(ReviewerMap);
            _unitOfWork.Complete();
            return Ok(updatedReviewer);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReviewer([FromQuery] int ReviewerId)
        {
            var thisEntity = await _unitOfWork.Reviewer.GetEntity(ReviewerId);
            _unitOfWork.Reviewer.DeleteEntity(thisEntity);
            _unitOfWork.Complete();
            return Ok(thisEntity);
        }
    }
}
