using System.ComponentModel.DataAnnotations;

namespace TechTreeWebApplication.Areas.Admin.Models.CategoryItem
{
    public class CategoryItemCreate
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
        public DateOnly DateReleased { get; set; } = DateOnly.MinValue;
    }
}
