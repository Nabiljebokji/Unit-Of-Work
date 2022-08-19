using MediatR;
using UnitOfWork_Pokemons.Core.Dto;

namespace UnitOfWork_Pokemons.Core.Mediatr.Queries.CategoryQueries
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryDto>>
    {
    }
}
