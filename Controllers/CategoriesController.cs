using Microsoft.AspNetCore.Mvc;
using ListaTracker.Data;
using ListaTracker.Models;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using MediatR;
using ListaTracker.Features.Categories.Queries;
using ListaTracker.Features.Categories.Commands;

namespace ListaTracker.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoriesController(IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery());
            return View(_mapper.Map<IEnumerable<CategoryViewModel>>(categories));
        }

        // GET: Categories/CreateOrEdit
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(string? id)
        {
            if (id.IsNullOrEmpty())
            {
                return View(new CategoryViewModel());
            }
            else
            {
                return View(_mapper.Map<CategoryViewModel>(await _mediator.Send(new GetCategoryByIdQuery() { Id = id })));
            }
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit([Bind("Id,Title,Icon,Type")] CategoryViewModel request)
        {
            if (ModelState.IsValid)
            {
                if (request.Id.IsNullOrEmpty())
                {
                    _ = await _mediator.Send(_mapper.Map<CreateCategoryCommand>(request));
                }
                else
                {
                    // Assume that it is always an Edit Action
                    _ = await _mediator.Send(_mapper.Map<UpdateCategoryCommand>(request));
                    return RedirectToAction(nameof(Index));
                } 
            }
            return View(request);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            _ = await _mediator.Send(new DeleteCategoryCommand() { Id = id });
            return RedirectToAction(nameof(Index));
        }

    }
}
