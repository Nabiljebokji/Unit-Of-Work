using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Pokemons.Core.Dto;
using UnitOfWork_Pokemons.Core.Interfaces;
using UnitOfWork_Pokemons.Core.Models;

namespace UnitOfWork_Pokemons.Core.Mediatr.Commands.CategoryCommands
{
     public class UpdateCategoryIdCommandHandler : IRequestHandler<UpdateCategoryIdCommand, CategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategoryIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(UpdateCategoryIdCommand request, CancellationToken cancellationToken)
        {
            var categoryMap = _mapper.Map<Category>(request.updatedCategory);
            await _unitOfWork.Category.UpdateEntity(categoryMap);
             _unitOfWork.Complete();
            return request.updatedCategory;
        }
    }
}
