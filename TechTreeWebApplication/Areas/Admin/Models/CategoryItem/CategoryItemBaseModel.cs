using System.ComponentModel.DataAnnotations;

namespace TechTreeWebApplication.Areas.Admin.Models.CategoryItem
{
    public record CategoryItemBaseModel
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int MediaTypeId { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Title { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateReleased { get; set; } = DateTime.Now;
    }
}
