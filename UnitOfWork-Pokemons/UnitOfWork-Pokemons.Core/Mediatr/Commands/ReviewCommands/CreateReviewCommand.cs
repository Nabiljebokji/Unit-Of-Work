using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Pokemons.Core.Dto;

namespace UnitOfWork_Pokemons.Core.Mediatr.Commands.ReviewCommands
{
    public class CreateReviewCommand : IRequest<ReviewDto>
    {
        public ReviewDto reviewDto { get; set; }
        public int pokeId { get; set; }
        public int reviewerId { get; set; }
    }
}
