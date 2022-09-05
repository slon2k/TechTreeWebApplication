using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechTreeWebApplication.Data;
using TechTreeWebApplication.Entities;

namespace TechTreeWebApplication.Areas.Admin.Pages.CategoryItem.Content
{
    public class DeleteModel : PageModel
    {
        private readonly TechTreeWebApplication.Data.ApplicationDbContext _context;

        public DeleteModel(TechTreeWebApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ContentEntity ContentEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Contents == null)
            {
                return NotFound();
            }

            var contententity = await _context.Contents.FirstOrDefaultAsync(m => m.Id == id);

            if (contententity == null)
            {
                return NotFound();
            }
            else 
            {
                ContentEntity = contententity;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Contents == null)
            {
                return NotFound();
            }
            var contententity = await _context.Contents.FindAsync(id);

            if (contententity != null)
            {
                ContentEntity = contententity;
                _context.Contents.Remove(ContentEntity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
