using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Pokemons.Core.Interfaces;
using UnitOfWork_Pokemons.Core.Models;

namespace UnitOfWork_Pokemons.Core.Mediatr.Commands.ReviewCommands
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Review>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Review> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var Thiscou = await _unitOfWork.Review.GetEntity(request.reviewId);
            _unitOfWork.Review.DeleteEntity(Thiscou);
            _unitOfWork.Complete();
            return Thiscou;
        }
    }
}
