using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Pokemons.Core.Dto;
using UnitOfWork_Pokemons.Core.Interfaces;
using UnitOfWork_Pokemons.Core.Models;

namespace UnitOfWork_Pokemons.Core.Mediatr.Commands.ReviewCommands
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, ReviewDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ReviewDto> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var thisReview = _mapper.Map<Review>(request.reviewDto);

            thisReview.Pokemon = await _unitOfWork.Pokemon.GetEntity(request.pokeId);
            thisReview.Reviewer = await _unitOfWork.Reviewer.GetEntity(request.reviewerId);

            await _unitOfWork.Review.CreateEntity(thisReview);
            _unitOfWork.Complete();
            return request.reviewDto;
        }
    }
}
