using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BUKEP.DIRECTORY.Db.Map
{
    internal class FieldAttributeEntityMap : IEntityTypeConfiguration<FieldAttributeEntity>
    {
        public void Configure(EntityTypeBuilder<FieldAttributeEntity> builder)
        {
			builder.ToTable("FieldAttribute", "dir");

			builder.HasKey( p => new { p.ProviderId, p.AttributeId });
			builder.Property(p => p.ProviderId).HasColumnName("DataProviderId");
			builder.Property(p => p.AttributeId).HasColumnName("AttributeId");
        }
    }
}