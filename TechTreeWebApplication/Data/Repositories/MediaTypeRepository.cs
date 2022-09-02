using TechTreeWebApplication.Entities;
using TechTreeWebApplication.Interfaces;

namespace TechTreeWebApplication.Data.Repositories
{
    public class MediaTypeRepository : RepositoryBase<MediaTypeEntity, int>, IMediaTypeRepository
    {
        public MediaTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
