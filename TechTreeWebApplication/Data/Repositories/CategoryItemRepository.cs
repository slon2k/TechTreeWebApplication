using Microsoft.EntityFrameworkCore;
using TechTreeWebApplication.Entities;
using TechTreeWebApplication.Interfaces;

namespace TechTreeWebApplication.Data.Repositories
{
    public class CategoryItemRepository : RepositoryBase<CategoryItemEntity, int>, ICategoryItemRepository
    {
        public CategoryItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CategoryItemEntity>> GetItemsForCategoryAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.CategoryItems
                .Where(x => x.CategoryId == id)
                .Include(x => x.Content)
                .Include(x => x.MediaType)
                .Include(x => x.Category)
                .ToListAsync(cancellationToken);
        }
    }
}
