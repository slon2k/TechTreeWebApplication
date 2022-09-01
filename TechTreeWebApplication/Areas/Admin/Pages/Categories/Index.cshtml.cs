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
    public class IndexModel : PageModel
    {
        private readonly TechTreeWebApplication.Data.ApplicationDbContext _context;

        public IndexModel(TechTreeWebApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CategoryEntity> CategoryEntity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                CategoryEntity = await _context.Categories.ToListAsync();
            }
        }
    }
}
