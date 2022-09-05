using System.ComponentModel.DataAnnotations;

namespace TechTreeWebApplication.Areas.Admin.Models.CategoryItem
{
    public record CategoryItemModel : CategoryItemBaseModel
    {
        [Required]
        public int Id { get; init; }

        public int ContentId { get; set; }
    }
}
