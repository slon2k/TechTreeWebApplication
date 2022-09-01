using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechTreeWebApplication.Areas.Admin.Models.Category;
using TechTreeWebApplication.Interfaces;

namespace TechTreeWebApplication.Areas.Admin.Pages.Category
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryRepository repository;
        
        public DeleteModel(ICategoryRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));
            this.repository = repository;
        }

        [BindProperty]
        public CategoryModel Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var entity = await repository.FindAsync(id);

            if (entity is null)
            {
                return NotFound();
            }

            Category = new CategoryModel 
            { 
                Id = entity.Id,
                Description = entity.Description,
                Thumbnail = entity.Thumbnail,
                Title = entity.Title
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (! await repository.AnyAsync(id))
            {
                return NotFound();
            }
            
            await repository.DeleteAsync(id);

            try
            {
                await repository.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
