using Microsoft.EntityFrameworkCore;
using TechTreeWebApplication.Entities;
using TechTreeWebApplication.Interfaces;

namespace TechTreeWebApplication.Data.Repositories
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity, Id<TKey> where TKey : struct
    {
        protected readonly ApplicationDbContext context;

        protected RepositoryBase(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            
            this.context = context;
        }

        public async Task AddAsync(TEntity item, CancellationToken cancellationToken = default)
        {
            await context.Set<TEntity>().AddAsync(item, cancellationToken);
        }

        public async Task<bool> AnyAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return await context.Set<TEntity>().AnyAsync(x => id.Equals(x.Id), cancellationToken);
        }

        public void Delete(TEntity item)
        {
            if (item is not null)
            {
                context.Set<TEntity>().Remove(item);
            }        
        }

        public async Task DeleteAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var item = await FindAsync(id, cancellationToken);

            if (item is not null)
            {
                Delete(item);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await context.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> FindAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return await context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await context.SaveChangesAsync(cancellationToken);
        }

        public void Update(TEntity item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
