#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanB.Data;
using PlanB.Data.Models;

namespace PlanB.Areas.Manager.Controllers
{

    public class IngradientsController : ManagerController
    {
        private readonly ApplicationDbContext _context;

        public IngradientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employee/Ingradients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ingredients.ToListAsync());
        }

        // GET: Employee/Ingradients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingradient = await _context.Ingredients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingradient == null)
            {
                return NotFound();
            }

            return View(ingradient);
        }

        // GET: Employee/Ingradients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Ingradients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Product,Quantity,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Ingradient ingradient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingradient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingradient);
        }

        // GET: Employee/Ingradients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingradient = await _context.Ingredients.FindAsync(id);
            if (ingradient == null)
            {
                return NotFound();
            }
            return View(ingradient);
        }

        // POST: Employee/Ingradients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Product,Quantity,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Ingradient ingradient)
        {
            if (id != ingradient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingradient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngradientExists(ingradient.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ingradient);
        }

        // GET: Employee/Ingradients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingradient = await _context.Ingredients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingradient == null)
            {
                return NotFound();
            }

            return View(ingradient);
        }

        // POST: Employee/Ingradients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingradient = await _context.Ingredients.FindAsync(id);
            _context.Ingredients.Remove(ingradient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngradientExists(int id)
        {
            return _context.Ingredients.Any(e => e.Id == id);
        }
    }
}
