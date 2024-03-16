using AutoMapper;
using ListaTracker.Data;
using ListaTracker.Entities;
using ListaTracker.Models;
using MediatR;

namespace ListaTracker.Features.Categories.Commands
{
    public class UpdateCategoryCommand : CategoryViewModel, IRequest<Category>
    {
        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Category> 
        {
            private readonly ApplicationDbContext _applicationDbContext;
            private readonly IMapper _mapper;
            public UpdateCategoryCommandHandler(ApplicationDbContext applicationDbContext,
                IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }
            public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await _applicationDbContext.Categories.FindAsync(request.Id, cancellationToken);
                category = _mapper.Map(request, category);
                _applicationDbContext.Update(category);
                await _applicationDbContext.SaveChangesAsync();
                return category;
            }
        }
    }
}
