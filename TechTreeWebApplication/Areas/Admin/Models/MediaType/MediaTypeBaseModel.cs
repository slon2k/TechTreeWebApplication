using System.ComponentModel.DataAnnotations;

namespace TechTreeWebApplication.Areas.Admin.Models.MediaType
{
    public record MediaTypeBaseModel
    {
        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Title { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Thumbnail { get; set; }
    }
}
