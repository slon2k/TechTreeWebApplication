using System.ComponentModel.DataAnnotations;

namespace TechTreeWebApplication.Areas.Admin.Models.Content
{
    public abstract record ContentBaseModel
    {
        public int CategoryItemId { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Title { get; set; }

        public string HTMLContent { get; set; }

        public string VideoLink { get; set; }
    }
}
