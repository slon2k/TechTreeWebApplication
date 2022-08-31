namespace TechTreeWebApplication.Entities
{
    public class UserCategoryEntity : IEntity
    {
        public int CategoryId { get; set; }
        
        public string UserId { get; set; }

        public CategoryEntity Category { get; set; }

        public ApplicationUser User { get; set; }
    }
}
