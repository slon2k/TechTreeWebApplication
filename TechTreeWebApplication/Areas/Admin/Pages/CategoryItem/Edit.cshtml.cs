using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechTreeWebApplication.Areas.Admin.Models.Category;
using TechTreeWebApplication.Areas.Admin.Models.CategoryItem;
using TechTreeWebApplication.Interfaces;

namespace TechTreeWebApplication.Areas.Admin.Pages.CategoryItem
{
    public class EditModel : PageModel
    {
        private readonly ICategoryItemRepository categoryItemRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMediaTypeRepository mediaTypeRepository;

        public EditModel(ICategoryItemRepository categoryItemRepository, ICategoryRepository categoryRepository, IMediaTypeRepository mediaTypeRepository)
        {
            this.categoryItemRepository = categoryItemRepository ?? throw new ArgumentNullException(nameof(categoryItemRepository));
            this.categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            this.mediaTypeRepository = mediaTypeRepository ?? throw new ArgumentNullException(nameof(mediaTypeRepository));
        }

        [BindProperty]
        public CategoryItemModel CategoryItem { get; set; } = default!;

        public CategoryModel Category { get; set; } = default!;

        public SelectList MediaTypeSelectList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var categoryItem = await categoryItemRepository.FindAsync(id);

            if (categoryItem is null)
            {
                return NotFound();
            }

            var category = await categoryRepository.FindAsync(categoryItem.CategoryId);

            if (category is null)
            {
                return NotFound();
            }

            MediaTypeSelectList = new SelectList(await mediaTypeRepository.GetAllAsync(), "Id", "Title");

            Category = new CategoryModel
            {
                Description = category.Description,
                Title = category.Title,
                Thumbnail = category.Thumbnail,
                Id = category.Id
            };

            CategoryItem = new CategoryItemModel 
            {
                Id = categoryItem.Id,
                MediaTypeId = categoryItem.MediaTypeId,
                Title = categoryItem.Title,
                DateReleased = categoryItem.DateReleased.ToDateTime(TimeOnly.MinValue),
                CategoryId = categoryItem.CategoryId,
                Description = categoryItem.Description,
            };

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (CategoryItem is null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                var category = await categoryRepository.FindAsync(CategoryItem.CategoryId);

                if (category is null)
                {
                    return NotFound();
                }

                MediaTypeSelectList = new SelectList(await mediaTypeRepository.GetAllAsync(), "Id", "Title");

                Category = new CategoryModel
                {
                    Description = category.Description,
                    Title = category.Title,
                    Thumbnail = category.Thumbnail,
                    Id = category.Id
                };

                return Page();
            }

            var categoryItemEntity = await categoryItemRepository.FindAsync(CategoryItem.Id);

            if (categoryItemEntity is null)
            {
                return NotFound();
            }

            categoryItemEntity.Title = CategoryItem.Title;
            categoryItemEntity.Description = CategoryItem.Description;
            categoryItemEntity.MediaTypeId = CategoryItem.MediaTypeId;
            categoryItemEntity.DateReleased = DateOnly.FromDateTime(CategoryItem.DateReleased);

            categoryItemRepository.Update(categoryItemEntity);
            await categoryItemRepository.SaveChangesAsync();

            return RedirectToPage("./Index", new { categoryId = categoryItemEntity.CategoryId });
        }
    }
}
