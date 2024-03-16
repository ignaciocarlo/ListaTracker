using ListaTracker.Data;
using ListaTracker.Entities;
using MediatR;

namespace ListaTracker.Features.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<Category>
    {
        public string Id { get; set; }
        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Category> 
        {
            private readonly ApplicationDbContext _applicationDbContext;
            public DeleteCategoryCommandHandler(ApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }
            public async Task<Category> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await _applicationDbContext.Categories.FindAsync(request.Id);
                if (category == null) throw new ArgumentException("Encountered an error while deleting the category.");
                _applicationDbContext.Categories.Remove(category);
                await _applicationDbContext.SaveChangesAsync();
                return category;
            }
        }
    }
}
