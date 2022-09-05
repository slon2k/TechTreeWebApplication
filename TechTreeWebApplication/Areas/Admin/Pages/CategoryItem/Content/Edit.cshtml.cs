using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechTreeWebApplication.Areas.Admin.Models.Content;
using TechTreeWebApplication.Interfaces;

namespace TechTreeWebApplication.Areas.Admin.Pages.CategoryItem.Content
{
    public class EditModel : PageModel
    {
        private readonly ICategoryItemRepository categoryItemRepository;

        public EditModel(ICategoryItemRepository categoryItemRepository)
        {
            this.categoryItemRepository = categoryItemRepository ?? throw new ArgumentNullException(nameof(categoryItemRepository));
        }

        [BindProperty]
        public ContentModel ItemContent { get; set; } = default!;

        public int CategoryId { get; set; }

        public async Task<IActionResult> OnGetAsync(int itemId)
        {
            var item = await categoryItemRepository.GetItemByIdAsync(itemId);

            if (item is null)
            {
                return NotFound();
            }

            if (item.Content is null)
            {
                return BadRequest();
            }

            CategoryId = item.CategoryId;

            ItemContent = new ContentModel {
                Id = item.Content.Id,
                CategoryItemId = itemId,
                Title = item.Content.Title,
                HTMLContent = item.Content.HTMLContent,
                VideoLink = item.Content.VideoLink,
            };

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
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

            if (item.Content is null)
            {
                return BadRequest();
            }

            item.Content.Title = ItemContent.Title;
            item.Content.HTMLContent = ItemContent.HTMLContent;
            item.Content.VideoLink = ItemContent.VideoLink;

            categoryItemRepository.Update(item);
            await categoryItemRepository.SaveChangesAsync();

            return RedirectToPage("../Index", new { categoryId = item.CategoryId });

        }
    }
}
