using TechTreeWebApplication.Entities;

namespace TechTreeWebApplication.Interfaces
{
    public interface ICategoryItemRepository : IRepository<CategoryItemEntity, int>
    {
        Task<IEnumerable<CategoryItemEntity>> GetItemsForCategoryAsync(int id, CancellationToken cancellationToken = default);

        Task<CategoryItemEntity> GetItemByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
