using Microsoft.AspNetCore.Mvc.RazorPages;
using TechTreeWebApplication.Areas.Admin.Models.Category;
using TechTreeWebApplication.Interfaces;

namespace TechTreeWebApplication.Areas.Admin.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryRepository repository;

        public IndexModel(ICategoryRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));
            this.repository = repository;
        }

        public IList<CategoryModel> Categories { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var items = await repository.GetAllAsync();

            Categories = items.Select(c => new CategoryModel { 
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Thumbnail = c.Thumbnail
            }).ToList();

        }
    }
}
