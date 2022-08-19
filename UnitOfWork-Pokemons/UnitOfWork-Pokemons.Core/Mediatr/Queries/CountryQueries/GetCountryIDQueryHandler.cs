using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Pokemons.Core.Dto;
using UnitOfWork_Pokemons.Core.Interfaces;

namespace UnitOfWork_Pokemons.Core.Mediatr.Queries.CountryQueries
{
    public class GetCountryIDQueryHandler : IRequestHandler<GetCountryIDQuery, CountryDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetCountryIDQueryHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CountryDto> Handle(GetCountryIDQuery request, CancellationToken cancellationToken)
        {
            var country = _mapper.Map<CountryDto>(await _unitOfWork.Country.GetEntity(request.countryId));
            return country;
        }
    }
}
