using TechTreeWebApplication.Entities;
using TechTreeWebApplication.Interfaces;

namespace TechTreeWebApplication.Data.Repositories
{
    public class CategoryItemRepository : RepositoryBase<CategoryItemEntity, int>, ICategoryItemRepository
    {
        public CategoryItemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
