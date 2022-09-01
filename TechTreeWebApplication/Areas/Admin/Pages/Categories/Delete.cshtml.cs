using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechTreeWebApplication.Data;
using TechTreeWebApplication.Entities;

namespace TechTreeWebApplication.Areas.Admin.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly TechTreeWebApplication.Data.ApplicationDbContext _context;

        public DeleteModel(TechTreeWebApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CategoryEntity CategoryEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categoryentity = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (categoryentity == null)
            {
                return NotFound();
            }
            else 
            {
                CategoryEntity = categoryentity;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }
            var categoryentity = await _context.Categories.FindAsync(id);

            if (categoryentity != null)
            {
                CategoryEntity = categoryentity;
                _context.Categories.Remove(CategoryEntity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
