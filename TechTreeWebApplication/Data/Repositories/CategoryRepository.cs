using TechTreeWebApplication.Entities;
using TechTreeWebApplication.Interfaces;

namespace TechTreeWebApplication.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<CategoryEntity, int>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
