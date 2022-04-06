#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlanB.Data;
using PlanB.Data.Models;
using PlanB.Services.Data.Contracts;
using PlanB.Web.ViewModels.Employee.Recipe;

namespace PlanB.Areas.Manager.Controllers
{

    public class RecipesController : ManagerController
    {
        private readonly ApplicationDbContext _context;
        private readonly IRecipesService recipesService;

        public RecipesController(ApplicationDbContext context, IRecipesService recipesService)
        {
            _context = context;
            this.recipesService = recipesService;
        }

        public string StatusMessage { get; set; }

        // GET: Manager/Recipes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recipes.ToListAsync());
        }

        // GET: Manager/Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.Id == id);
            var viewModel = recipesService.Details(id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Manager/Recipes/Create
        public IActionResult Create()
        {
            var ingradients = _context.Ingredients.Select(x => new SelectListItem()
            {
                Text = x.Product + x.Quantity.ToString(),
                Value = x.Id.ToString()
            }).ToList();
           

            var viewModel = new CreateRecipeViewModel { Ingradients = ingradients };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRecipeViewModel viewModel)
        {

            if (viewModel.Ingradients == null)
            {
                this.TempData["InfoMessage"] = "First create ingradients";
                return RedirectToAction("Create", "Ingradients");
            }

            if (ModelState.IsValid )
            {
                var recipe = new Recipe { Name = viewModel.Name };

                var ingradientsId = viewModel.Ingradients.Where(x => x.Selected).Select(i => i.Value);

                
                foreach (var item in ingradientsId)
                {
                    recipe.RecipesIngradients.Add(new RecipesIngradients
                    {
                       
                        IngradientId = int.Parse(item)
                    });
                }

                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Manager/Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Manager/Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.Id))
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
            return View(recipe);
        }

        // GET: Manager/Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Manager/Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }
    }
}
