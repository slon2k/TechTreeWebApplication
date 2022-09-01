using System.ComponentModel.DataAnnotations;

namespace TechTreeWebApplication.Areas.Admin.Models.CategoryItem
{
    public class CategoryItemModel
    {
        [Required]
        public int Id { get; init; }

        [Required]
        public int CategoryId { get; init; }

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

        public string Category { get; set; }
    }
}
