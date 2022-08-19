using AutoMapper;
using MediatR;
using UnitOfWork_Pokemons.Core.Dto;
using UnitOfWork_Pokemons.Core.Interfaces;

namespace UnitOfWork_Pokemons.Core.Mediatr.Queries.CategoryQueries
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var allcategories = await _unitOfWork.Category.GetAllEntities();
            var catMap = _mapper.Map<List<CategoryDto>>(allcategories);
            return catMap;
        }
    }
}
