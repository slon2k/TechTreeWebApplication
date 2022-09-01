using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechTreeWebApplication.Data;
using TechTreeWebApplication.Entities;

namespace TechTreeWebApplication.Areas.Admin.Pages.CategoryItem
{
    public class EditModel : PageModel
    {
        private readonly TechTreeWebApplication.Data.ApplicationDbContext _context;

        public EditModel(TechTreeWebApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CategoryItemEntity CategoryItemEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CategoryItems == null)
            {
                return NotFound();
            }

            var categoryitementity =  await _context.CategoryItems.FirstOrDefaultAsync(m => m.Id == id);
            if (categoryitementity == null)
            {
                return NotFound();
            }
            CategoryItemEntity = categoryitementity;
           ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Thumbnail");
           ViewData["MediaTypeId"] = new SelectList(_context.MediaTypes, "Id", "Thumbnail");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CategoryItemEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryItemEntityExists(CategoryItemEntity.Id))
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

        private bool CategoryItemEntityExists(int id)
        {
          return (_context.CategoryItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
