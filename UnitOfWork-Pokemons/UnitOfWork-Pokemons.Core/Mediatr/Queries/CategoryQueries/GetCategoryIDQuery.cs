using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Pokemons.Core.Dto;

namespace UnitOfWork_Pokemons.Core.Mediatr.Queries.CategoryQueries
{
    public class GetCategoryIDQuery : IRequest<CategoryDto>
    {
        public int categoryId { get; set; }
    }
}
