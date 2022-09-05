using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechTreeWebApplication.Areas.Admin.Models.Category;
using TechTreeWebApplication.Areas.Admin.Models.CategoryItem;
using TechTreeWebApplication.Entities;
using TechTreeWebApplication.Interfaces;

namespace TechTreeWebApplication.Areas.Admin.Pages.CategoryItem
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryItemRepository categoryItemRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMediaTypeRepository mediaTypeRepository;

        public CreateModel(ICategoryItemRepository categoryItemRepository, 
            ICategoryRepository categoryRepository,
            IMediaTypeRepository mediaTypeRepository)
        {
            this.categoryItemRepository = categoryItemRepository ?? throw new ArgumentNullException(nameof(categoryItemRepository));
            this.categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            this.mediaTypeRepository = mediaTypeRepository ?? throw new ArgumentNullException(nameof(mediaTypeRepository));
        }

        [BindProperty]
        public CategoryItemCreateModel CategoryItem { get; set; } = default!;

        public CategoryModel Category { get; set; } = default!;

        public SelectList MediaTypeSelectList { get; set; } = default!;

        public async Task<IActionResult> OnGet(int categoryId)
        {
            MediaTypeSelectList = new SelectList(await mediaTypeRepository.GetAllAsync(), "Id", "Title");

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

            CategoryItem = new CategoryItemCreateModel { CategoryId = categoryId };

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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

            await categoryItemRepository.AddAsync(new CategoryItemEntity 
            {
                CategoryId = CategoryItem.CategoryId,
                Title = CategoryItem.Title,
                Description = CategoryItem.Description,
                MediaTypeId = CategoryItem.MediaTypeId,
                DateReleased = DateOnly.FromDateTime(CategoryItem.DateReleased),
            });
            
            await categoryItemRepository.SaveChangesAsync();

            return RedirectToPage("./Index", new { categoryId = CategoryItem.CategoryId });
        }
    }
}
