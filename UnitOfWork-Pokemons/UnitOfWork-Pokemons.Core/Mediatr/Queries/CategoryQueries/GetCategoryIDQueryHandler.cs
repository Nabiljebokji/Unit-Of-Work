using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Pokemons.Core.Dto;
using UnitOfWork_Pokemons.Core.Interfaces;

namespace UnitOfWork_Pokemons.Core.Mediatr.Queries.CategoryQueries
{
    public class GetCategoryIDQueryHandler : IRequestHandler<GetCategoryIDQuery, CategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoryIDQueryHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryDto> Handle(GetCategoryIDQuery request, CancellationToken cancellationToken)
        {
            var thisId = await _unitOfWork.Category.GetEntity(request.categoryId);
            var categories = _mapper.Map<CategoryDto>(thisId);
            return categories;
        }
    }
}
