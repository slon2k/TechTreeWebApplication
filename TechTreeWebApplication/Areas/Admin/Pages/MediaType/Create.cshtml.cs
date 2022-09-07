using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechTreeWebApplication.Areas.Admin.Models.MediaType;
using TechTreeWebApplication.Entities;
using TechTreeWebApplication.Interfaces;

namespace TechTreeWebApplication.Areas.Admin.Pages.MediaType
{
    public class CreateModel : PageModel
    {
        private readonly IMediaTypeRepository mediaTypeRepository;

        public CreateModel(IMediaTypeRepository mediaTypeRepository)
        {
            this.mediaTypeRepository = mediaTypeRepository ?? throw new ArgumentNullException(nameof(mediaTypeRepository));
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MediaTypeCreateModel MediaType { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || MediaType is null)
            {
                return Page();
            }

            await mediaTypeRepository.AddAsync(new MediaTypeEntity
            {
                Title = MediaType.Title,
                Thumbnail = MediaType.Thumbnail,
            });

            await mediaTypeRepository.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
