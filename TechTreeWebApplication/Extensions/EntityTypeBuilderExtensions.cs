using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechTreeWebApplication.Entities;

namespace TechTreeWebApplication.Extensions
{
    internal static class EntityTypeBuilderExtensions
    {
        internal static PropertyBuilder HasUniqueIdentifier<TEntity, TKey>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, IEntity, Id<TKey> where TKey : struct
        {
            builder.HasKey(e => e.Id);
            
            return builder.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();
        }

        internal static PropertyBuilder HasTitle<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, IEntity, ITitle
        {
            return builder.Property(e => e.Title)
                .HasColumnName("Title")
                .IsRequired()
                .HasMaxLength(255);
        }

        internal static PropertyBuilder HasThumbnail<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, IEntity, IThumbnail
        {
            return builder.Property(e => e.Thumbnail)
                .HasColumnName("Thumbnail")
                .IsRequired()
                .HasMaxLength(255);
        }

        internal static PropertyBuilder HasDescription<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, IEntity, IDescription
        {
            return builder.Property(e => e.Description)
                .HasColumnName("Description")
                .IsRequired(false)
                .HasMaxLength(4000);
        }
    }
}
