using System.ComponentModel.DataAnnotations;

namespace TechTreeWebApplication.Areas.Admin.Models.Category
{
    public record CategoryModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Title { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Thumbnail { get; set; }
    }
}
