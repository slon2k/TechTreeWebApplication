using System.ComponentModel.DataAnnotations;

namespace TechTreeWebApplication.Areas.Admin.Models.Category
{
    public abstract record CategoryBaseModel
    {
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
