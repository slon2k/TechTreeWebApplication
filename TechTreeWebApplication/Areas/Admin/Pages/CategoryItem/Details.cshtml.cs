using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechTreeWebApplication.Data;
using TechTreeWebApplication.Entities;

namespace TechTreeWebApplication.Areas.Admin.Pages.CategoryItem
{
    public class DetailsModel : PageModel
    {
        private readonly TechTreeWebApplication.Data.ApplicationDbContext _context;

        public DetailsModel(TechTreeWebApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public CategoryItemEntity CategoryItemEntity { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CategoryItems == null)
            {
                return NotFound();
            }

            var categoryitementity = await _context.CategoryItems.FirstOrDefaultAsync(m => m.Id == id);
            if (categoryitementity == null)
            {
                return NotFound();
            }
            else 
            {
                CategoryItemEntity = categoryitementity;
            }
            return Page();
        }
    }
}
