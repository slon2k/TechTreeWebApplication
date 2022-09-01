using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechTreeWebApplication.Areas.Admin.Models.Category;
using TechTreeWebApplication.Entities;
using TechTreeWebApplication.Interfaces;

namespace TechTreeWebApplication.Areas.Admin.Pages.Category
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryRepository repository;

        public CreateModel(ICategoryRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));
            this.repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CategoryCreate Category { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Category is null)
            {
                return Page();
            }

            await repository.AddAsync(new CategoryEntity { 
                Title = Category.Title,
                Description = Category.Description,
                Thumbnail = Category.Thumbnail
            });
            
            await repository.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
