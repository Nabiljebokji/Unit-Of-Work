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
    public class OwnerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OwnerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<List<OwnerDto>> GetOwnersAsync()
        {
            var AllOwners = await _unitOfWork.Owner.GetAllEntities();
            var OwnerMap = _mapper.Map<List<OwnerDto>>(AllOwners);
            return OwnerMap;
        }

        [HttpGet("OwnerId")]
        public async Task<IActionResult> GetOwnerById(int OwnerId)
        {
            var thisOwner = await _unitOfWork.Owner.GetEntity(OwnerId);
            var OwnerMap = _mapper.Map<OwnerDto>(thisOwner);
            return Ok(OwnerMap);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] OwnerDto OwnerDto)
        {
            var OwnerMap = _mapper.Map<Owner>(OwnerDto);
            await _unitOfWork.Owner.CreateEntity(OwnerMap);
            _unitOfWork.Complete();
            return Ok(OwnerDto);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOwner([FromBody] OwnerDto Owner)
        {
            var OwnerMap = _mapper.Map<Owner>(Owner);
            await _unitOfWork.Owner.UpdateEntity(OwnerMap);
            _unitOfWork.Complete();
            return Ok(Owner);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOwner([FromQuery] int OwnerId)
        {
            var Owner = await _unitOfWork.Owner.GetEntity(OwnerId);
            _unitOfWork.Owner.DeleteEntity(Owner);
            var OwnerMap = _mapper.Map<OwnerDto>(Owner);
            _unitOfWork.Complete();
            return Ok(OwnerMap);
        }


    }
}
