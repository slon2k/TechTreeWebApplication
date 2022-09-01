using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechTreeWebApplication.Entities;
using TechTreeWebApplication.Extensions;

namespace TechTreeWebApplication.EntityConfigurations
{
    public class MediaTypeConfiguration : IEntityTypeConfiguration<MediaTypeEntity>
    {
        public void Configure(EntityTypeBuilder<MediaTypeEntity> builder)
        {
            builder.ToTable("MediaType");

            builder.HasUniqueIdentifier<MediaTypeEntity, int>();

            builder.HasTitle();

            builder.HasThumbnail();

            builder.HasData(new List<MediaTypeEntity>() {
                new MediaTypeEntity { Id = 1, Title = "Article", Thumbnail = "/images/ArticleImage.jpeg" },
                new MediaTypeEntity { Id = 2, Title = "Video", Thumbnail = "/images/VideoImage.jpeg" }
            });
        }
    }
}
