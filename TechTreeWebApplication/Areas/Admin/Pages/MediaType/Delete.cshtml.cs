using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechTreeWebApplication.Data;
using TechTreeWebApplication.Entities;

namespace TechTreeWebApplication.Areas.Admin.Pages.MediaType
{
    public class DeleteModel : PageModel
    {
        private readonly TechTreeWebApplication.Data.ApplicationDbContext _context;

        public DeleteModel(TechTreeWebApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public MediaTypeEntity MediaTypeEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MediaTypes == null)
            {
                return NotFound();
            }

            var mediatypeentity = await _context.MediaTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (mediatypeentity == null)
            {
                return NotFound();
            }
            else 
            {
                MediaTypeEntity = mediatypeentity;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MediaTypes == null)
            {
                return NotFound();
            }
            var mediatypeentity = await _context.MediaTypes.FindAsync(id);

            if (mediatypeentity != null)
            {
                MediaTypeEntity = mediatypeentity;
                _context.MediaTypes.Remove(MediaTypeEntity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
