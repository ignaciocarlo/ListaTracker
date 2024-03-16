using AutoMapper;
using ListaTracker.Data;
using ListaTracker.Entities;
using ListaTracker.Models;
using MediatR;
using NuGet.Protocol.Plugins;

namespace ListaTracker.Features.Categories.Commands
{
    public class CreateCategoryCommand : CategoryViewModel, IRequest<Category>
    {
        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category> 
        {
            private readonly ApplicationDbContext _applicationDbContext;
            private readonly IMapper _mapper;
            public CreateCategoryCommandHandler(ApplicationDbContext applicationDbContext,
                IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }
            public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = _mapper.Map<Category>(request);
                _applicationDbContext.Add(category);
                await _applicationDbContext.SaveChangesAsync();
                return category;
            }
        }
    }
}
