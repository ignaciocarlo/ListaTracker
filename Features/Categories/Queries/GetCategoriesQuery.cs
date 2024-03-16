using ListaTracker.Data;
using ListaTracker.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ListaTracker.Features.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<IEnumerable<Category>> 
    {
        public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<Category>>
        {
            private readonly ApplicationDbContext _applicationDbContext;
            public GetCategoriesQueryHandler(ApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }
            public async Task<IEnumerable<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
               => await _applicationDbContext.Categories.ToListAsync();
        }
    }
}
