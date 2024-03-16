using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ListaTracker.Data;
using ListaTracker.Entities;
using ListaTracker.Models;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace ListaTracker.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            var test = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            return View(test);
        }

        // GET: Categories/Create
        [HttpGet]
        public IActionResult CreateOrEdit(string? id)
        {
            if (id.IsNullOrEmpty())
            {
                return View(new CategoryViewModel());
            }
            else
            {
                CategoryViewModel category = _mapper.Map<CategoryViewModel>(_context.Categories.Find(id));
                return View(category);
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
                    Category category = _mapper.Map<Category>(request);
                    _context.Add(category);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Category? category = _context.Categories.Find(request.Id);
                    if(category != null)
                    {
                        category = _mapper.Map(request, category);
                        _context.Update(category);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                } 
            }
            return View(request);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
