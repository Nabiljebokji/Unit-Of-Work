using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Pokemons.Core.Dto;
using UnitOfWork_Pokemons.Core.Interfaces;

namespace UnitOfWork_Pokemons.Core.Mediatr.Queries.ReviewQueries
{
    public class GetAllReviewQueryHandler : IRequestHandler<GetAllReviewQuery, List<ReviewDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllReviewQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ReviewDto>> Handle(GetAllReviewQuery request, CancellationToken cancellationToken)
        {
            var allCountries = await _unitOfWork.Review.GetAllEntities();
            var catMap = _mapper.Map<List<ReviewDto>>(allCountries);
            return catMap;
        }
    }

}
