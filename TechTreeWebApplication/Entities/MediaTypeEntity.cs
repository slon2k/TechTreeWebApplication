namespace TechTreeWebApplication.Entities
{
    public class MediaTypeEntity : Id<int>, IEntity, ITitle, IThumbnail
    {
        public int Id { get; init; }

        public string Title { get; set; }

        public string Thumbnail { get; set; }

        public ICollection<CategoryItemEntity> CategoryItems { get; set; } = new List<CategoryItemEntity>();
    }
}
