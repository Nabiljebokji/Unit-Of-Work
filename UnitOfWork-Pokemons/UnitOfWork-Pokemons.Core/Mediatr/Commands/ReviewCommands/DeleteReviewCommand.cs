using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Pokemons.Core.Models;

namespace UnitOfWork_Pokemons.Core.Mediatr.Commands.ReviewCommands
{
    public class DeleteReviewCommand : IRequest<Review>
    {
        public int reviewId { get; set; }
    }
}
