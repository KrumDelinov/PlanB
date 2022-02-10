#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlanB.Data;
using PlanB.Data.Models;
using PlanB.Web.ViewModels.Employee.Batch;
using PlanB.Common;

namespace PlanB.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class BatchesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public BatchesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: Employee/Batches
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Batches.Include(b => b.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Employee/Batches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = await _context.Batches
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        // GET: Employee/Batches/Create
        public IActionResult Create()
        {
            var test = new List<string> { GlobalConstants.BigCup, GlobalConstants.SmallCup};
            ViewData["Type"] = new SelectList(test);
            return View();
        }

        // POST: Employee/Batches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBatchViewModel viewModel)
        {
            var user = await userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                var batch = new Batch { Type = viewModel.Type, UserId = user.Id };
                _context.Add(batch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var test = new List<string> { GlobalConstants.BigCup, GlobalConstants.SmallCup };
            ViewData["Type"] = new SelectList(test);
            return View(viewModel);
        }

        // GET: Employee/Batches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = await _context.Batches.FindAsync(id);
            if (batch == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", batch.UserId);
            return View(batch);
        }

        // POST: Employee/Batches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Type,UserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Batch batch)
        {
            if (id != batch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(batch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatchExists(batch.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", batch.UserId);
            return View(batch);
        }

        // GET: Employee/Batches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = await _context.Batches
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        // POST: Employee/Batches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var batch = await _context.Batches.FindAsync(id);
            _context.Batches.Remove(batch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatchExists(int id)
        {
            return _context.Batches.Any(e => e.Id == id);
        }
    }
}
