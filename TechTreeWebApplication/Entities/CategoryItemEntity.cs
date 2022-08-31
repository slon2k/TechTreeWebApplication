namespace TechTreeWebApplication.Entities
{
    public class CategoryItemEntity : IEntity, Id<int>, ITitle, IDescription
    {
        public int Id { get; init; }

        public int CategoryId { get; init; }

        public int MediaTypeId { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }

        public DateOnly DateReleased { get; set; } = DateOnly.MinValue;

        public CategoryEntity Category { get; set; }

        public MediaTypeEntity MediaType { get; set; }

        public ContentEntity Content { get; set; }
    }
}
