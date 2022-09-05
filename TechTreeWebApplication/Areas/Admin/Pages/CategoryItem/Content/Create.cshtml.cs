using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechTreeWebApplication.Areas.Admin.Models.Content;
using TechTreeWebApplication.Entities;
using TechTreeWebApplication.Interfaces;

namespace TechTreeWebApplication.Areas.Admin.Pages.CategoryItem.Content
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryItemRepository categoryItemRepository;

        public CreateModel(ICategoryItemRepository categoryItemRepository)
        {
            this.categoryItemRepository = categoryItemRepository ?? throw new ArgumentNullException(nameof(categoryItemRepository));
        }

        public async Task<IActionResult> OnGetAsync(int itemId)
        {
            var item = await categoryItemRepository.GetItemByIdAsync(itemId);

            if (item is null)
            {
                return NotFound();
            }

            CategoryId = item.CategoryId;

            ItemContent = new ContentCreateModel { CategoryItemId = itemId };
            return Page();
        }

        [BindProperty]
        public ContentCreateModel ItemContent { get; set; } = default!;

        public int CategoryId { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (ItemContent is null)
            {
                return BadRequest();
            }

            var item = await categoryItemRepository.GetItemByIdAsync(ItemContent.CategoryItemId);

            if (item is null)
            {
                return NotFound();
            }

            CategoryId = item.CategoryId;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            item.Content = new ContentEntity
            {
                Title = ItemContent.Title,
                HTMLContent = ItemContent.HTMLContent,
                VideoLink = ItemContent.VideoLink,

            };

            await categoryItemRepository.SaveChangesAsync();

            return RedirectToPage("../Index", new { categoryId = item.CategoryId });
        }
    }
}
