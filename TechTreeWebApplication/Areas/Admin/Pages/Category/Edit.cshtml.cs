using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechTreeWebApplication.Areas.Admin.Models.Category;
using TechTreeWebApplication.Interfaces;

namespace TechTreeWebApplication.Areas.Admin.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ICategoryRepository repository;

        public EditModel(ICategoryRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));
            this.repository = repository;
        }

        [BindProperty]
        public CategoryModel Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var category =  await repository.FindAsync(id);
  
            if (category is null)
            {
                return NotFound();
            }

            Category = new CategoryModel
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description,
                Thumbnail = category.Thumbnail,
            };
            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Category is null)
            {
                return Page();
            }

            var categoryEntity = await repository.FindAsync(Category.Id);

            if (categoryEntity is null)
            {
                return NotFound();
            }

            categoryEntity.Title = Category.Title;
            categoryEntity.Description = Category.Description;
            categoryEntity.Thumbnail = Category.Thumbnail;

            repository.Update(categoryEntity);

            try
            {
                await repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await repository.AnyAsync(Category.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
