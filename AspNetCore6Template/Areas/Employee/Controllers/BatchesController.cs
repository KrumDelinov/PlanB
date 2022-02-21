#nullable disable
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlanB.Common;
using PlanB.Data;
using PlanB.Data.Models;
using PlanB.Services.Data.Contracts;
using PlanB.Web.ViewModels.Employee.Batches;

namespace PlanB.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class BatchesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITanksServise tanksServise;
        private readonly IBatchesService batchesService;

        public BatchesController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            ITanksServise tanksServise,
            IBatchesService batchesService)
        {
            _context = context;
            this.userManager = userManager;
            this.tanksServise = tanksServise;
            this.batchesService = batchesService;
        }

        // GET: Employee/Batches
        public IActionResult Index()
        {
            var batches = batchesService.GetAll<BatchViewModel>();
            var view = new BatchesListViewModel { Batches = batches };

            return this.View(view);
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

        public async Task<IActionResult> CreateBigCup()
        {
            var user = await userManager.GetUserAsync(User);
            var batch = new Batch { Type = GlobalConstants.BigCup, UserId = user.Id };
            await tanksServise.UpdateTanksAsync(batch.Type);
            _context.Add(batch);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CreateSmallCup()
        {
            var user = await userManager.GetUserAsync(User);
            var batch = new Batch { Type = GlobalConstants.SmallCup, UserId = user.Id };
            await tanksServise.UpdateTanksAsync(batch.Type);
            _context.Add(batch);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        // GET: Employee/Batches/Create
        public IActionResult Create()
        {
            var test = new List<string> { GlobalConstants.BigCup, GlobalConstants.SmallCup };
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
