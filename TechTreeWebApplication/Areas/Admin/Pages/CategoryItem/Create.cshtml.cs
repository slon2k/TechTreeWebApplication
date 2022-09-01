using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechTreeWebApplication.Data;
using TechTreeWebApplication.Entities;

namespace TechTreeWebApplication.Areas.Admin.Pages.CategoryItem
{
    public class CreateModel : PageModel
    {
        private readonly TechTreeWebApplication.Data.ApplicationDbContext _context;

        public CreateModel(TechTreeWebApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int categoryId)
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Thumbnail");
        ViewData["MediaTypeId"] = new SelectList(_context.MediaTypes, "Id", "Thumbnail");
            return Page();
        }

        [BindProperty]
        public CategoryItemEntity CategoryItemEntity { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CategoryItems == null || CategoryItemEntity == null)
            {
                return Page();
            }

            _context.CategoryItems.Add(CategoryItemEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
