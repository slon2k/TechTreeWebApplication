using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechTreeWebApplication.Areas.Admin.Models.Category;
using TechTreeWebApplication.Areas.Admin.Models.CategoryItem;
using TechTreeWebApplication.Interfaces;

namespace TechTreeWebApplication.Areas.Admin.Pages.CategoryItem
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryItemRepository categoryItemRepository;
        private readonly ICategoryRepository categoryRepository;

        public IndexModel(ICategoryItemRepository categoryItemRepository, ICategoryRepository categoryRepository)
        {
            ArgumentNullException.ThrowIfNull(categoryItemRepository, nameof(categoryItemRepository));
            ArgumentNullException.ThrowIfNull(categoryRepository, nameof(categoryRepository));
            this.categoryItemRepository = categoryItemRepository;
            this.categoryRepository = categoryRepository;
        }

        public IList<CategoryItemModel> CategoryItems { get;set; } = default!;

        public CategoryModel Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int categoryId)
        {
            var category = await categoryRepository.FindAsync(categoryId);

            if (category is null)
            {
                return NotFound();
            }

            Category = new CategoryModel
            {
                Description = category.Description,
                Title = category.Title,
                Thumbnail = category.Thumbnail,
                Id = category.Id
            };

            var categoryItems = await categoryItemRepository.GetItemsForCategoryAsync(categoryId);

            CategoryItems = categoryItems
                .Select(x => new CategoryItemModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    CategoryId = x.CategoryId,
                    MediaTypeId = x.MediaTypeId,
                    DateReleased = x.DateReleased.ToDateTime(TimeOnly.MinValue),
                    ContentId = x.Content?.Id ?? 0 
                }).ToList();

            return Page();
        }
    }
}

