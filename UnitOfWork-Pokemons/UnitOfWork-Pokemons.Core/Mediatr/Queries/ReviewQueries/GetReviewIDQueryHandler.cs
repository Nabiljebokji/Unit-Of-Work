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
    public class GetReviewIDQueryHandler : IRequestHandler<GetReviewIDQuery, ReviewDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetReviewIDQueryHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ReviewDto> Handle(GetReviewIDQuery request, CancellationToken cancellationToken)
        {
            var review = _mapper.Map<ReviewDto>(await _unitOfWork.Review.GetEntity(request.reviewId));
            return review;
        }
    }
}
