using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechTreeWebApplication.Areas.Admin.Models.MediaType;
using TechTreeWebApplication.Interfaces;

namespace TechTreeWebApplication.Areas.Admin.Pages.MediaType
{
    public class EditModel : PageModel
    {
        private readonly IMediaTypeRepository mediaTypeRepository;

        public EditModel(IMediaTypeRepository mediaTypeRepository)
        {
            this.mediaTypeRepository = mediaTypeRepository ?? throw new ArgumentNullException(nameof(mediaTypeRepository));
        }

        [BindProperty]
        public MediaTypeModel MediaType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var mediaTypeEntity =  await mediaTypeRepository.FindAsync(id);
            
            if (mediaTypeEntity is null)
            {
                return NotFound();
            }
            
            MediaType = new MediaTypeModel
            {
                Id = mediaTypeEntity.Id,
                Thumbnail = mediaTypeEntity.Thumbnail,
                Title = mediaTypeEntity.Title,
            };

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var mediaTypeEntity = await mediaTypeRepository.FindAsync(MediaType.Id);

            if (mediaTypeEntity is null)
            {
                return NotFound();
            }

            mediaTypeEntity.Thumbnail = MediaType.Thumbnail;
            mediaTypeEntity.Title = MediaType.Title;

            try
            {
                await mediaTypeRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await mediaTypeRepository.AnyAsync(MediaType.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
