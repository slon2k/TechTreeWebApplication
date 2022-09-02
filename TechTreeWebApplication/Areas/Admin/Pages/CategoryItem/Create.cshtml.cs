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

        [BindProperty]
        public CategoryItemCreate CategoryItem { get; set; } = default!;

        public CategoryModel Category { get; set; } = default!;

        public SelectList CategorySelectList { get; set; } = default!;

        public SelectList MediaTypeSelectList { get; set; } = default!;

        public CreateModel(ICategoryItemRepository categoryItemRepository,
            ICategoryRepository categoryRepository,
            IMediaTypeRepository mediaTypeRepository)
        {
            ArgumentNullException.ThrowIfNull(categoryItemRepository, nameof(categoryItemRepository));
            ArgumentNullException.ThrowIfNull(categoryRepository, nameof(categoryRepository));
            ArgumentNullException.ThrowIfNull(mediaTypeRepository, nameof(mediaTypeRepository));
            this.categoryItemRepository = categoryItemRepository;
            this.categoryRepository = categoryRepository;
            this.mediaTypeRepository = mediaTypeRepository;
        }
        
        public async Task<IActionResult> OnGet(int categoryId)
        {
            CategorySelectList = new SelectList(await categoryRepository.GetAllAsync(), "Id", "Title");
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

            return Page();
        }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || CategoryItem is null)
            {
                return Page();
            }

            await categoryItemRepository.AddAsync(new CategoryItemEntity 
            {
                CategoryId = Category.Id,
                Title = CategoryItem.Title,
                Description = CategoryItem.Description,
                MediaTypeId = CategoryItem.MediaTypeId,
                DateReleased = CategoryItem.DateReleased,
            });
            
            await categoryItemRepository.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
