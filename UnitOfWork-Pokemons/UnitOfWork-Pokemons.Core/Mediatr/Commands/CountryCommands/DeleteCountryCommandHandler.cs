using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Pokemons.Core.Interfaces;
using UnitOfWork_Pokemons.Core.Models;

namespace UnitOfWork_Pokemons.Core.Mediatr.Commands.CountryCommands
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteCountryCommand, Country>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Country> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var Thiscou = await _unitOfWork.Country.GetEntity(request.countryId);
            _unitOfWork.Country.DeleteEntity(Thiscou);
            _unitOfWork.Complete();
            return Thiscou;
        }
    }
}
