using ListaTracker.Data;
using ListaTracker.Entities;
using MediatR;

namespace ListaTracker.Features.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public string Id { get; set; }
        public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category> 
        {
            private readonly ApplicationDbContext _applicationDbContext;
            public GetCategoryByIdQueryHandler(ApplicationDbContext applicationDbContext) 
            {
                _applicationDbContext = applicationDbContext;
            }
            public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
                => await _applicationDbContext.Categories.FindAsync(request.Id);
        }
    }
}
