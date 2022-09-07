using Microsoft.AspNetCore.Mvc.RazorPages;
using TechTreeWebApplication.Areas.Admin.Models.MediaType;
using TechTreeWebApplication.Interfaces;

namespace TechTreeWebApplication.Areas.Admin.Pages.MediaType
{
    public class IndexModel : PageModel
    {
        private readonly IMediaTypeRepository mediaTypeRepository;

        public IndexModel(IMediaTypeRepository mediaTypeRepository)
        {
            this.mediaTypeRepository = mediaTypeRepository ?? throw new ArgumentNullException(nameof(mediaTypeRepository));
        }

        public IList<MediaTypeModel> MediaTypes { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var mediaTypeList = await mediaTypeRepository.GetAllAsync();

            MediaTypes = mediaTypeList.Select(x => new MediaTypeModel
            {
                Id = x.Id,
                Title = x.Title,
                Thumbnail = x.Thumbnail,
            }).ToList();
        }
    }
}
