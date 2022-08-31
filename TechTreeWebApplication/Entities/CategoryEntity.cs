namespace TechTreeWebApplication.Entities
{
    public class CategoryEntity : Id<int>, ITitle, IEntity
    {
        public int Id { get; init; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }

        public string Thumbnail { get; set; }
    }
}
