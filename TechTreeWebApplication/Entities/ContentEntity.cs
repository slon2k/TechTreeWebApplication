namespace TechTreeWebApplication.Entities
{
    public class ContentEntity : Id<int>, IEntity, ITitle
    {
        public int Id { get; init; }

        public int CategoryItemId { get; set; }

        public string Title { get; set; }

        public string HTMLContent { get; set; }

        public string VideoLink { get; set; }

        public CategoryItemEntity CategoryItem { get; set; }
    }
}
