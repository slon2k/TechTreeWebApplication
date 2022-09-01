using System.Threading;
using TechTreeWebApplication.Entities;

namespace TechTreeWebApplication.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity, Id<TKey> where TKey : struct
    {
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<TEntity?> FindAsync(TKey id, CancellationToken cancellationToken = default);

        Task DeleteAsync(TKey id, CancellationToken cancellationToken = default);

        void Delete(TEntity item);

        Task<bool> AnyAsync(TKey id, CancellationToken cancellationToken = default);

        Task AddAsync(TEntity item, CancellationToken cancellationToken = default);

        Task Update(TEntity item);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
