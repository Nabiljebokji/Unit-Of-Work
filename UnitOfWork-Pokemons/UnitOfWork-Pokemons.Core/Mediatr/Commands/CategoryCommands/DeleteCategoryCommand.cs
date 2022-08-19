using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Pokemons.Core.Dto;
using UnitOfWork_Pokemons.Core.Models;

namespace UnitOfWork_Pokemons.Core.Mediatr.Commands.CategoryCommands
{
    public class DeleteCategoryCommand : IRequest<Category>
    {
        public int categoryId { get; set; }
    }
}
