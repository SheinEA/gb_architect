using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BUKEP.DIRECTORY.Db.Map
{
    internal class FieldAttributeValueEntityMap : IEntityTypeConfiguration<FieldAttributeValueEntity>
    {
        public void Configure(EntityTypeBuilder<FieldAttributeValueEntity> builder)
        {
			builder.ToTable("FieldAttributeValue", "dir");

            builder.HasKey(p => new { AttributeId = p.AttributeId, DataSourceId = p.FieldId, DataProviderId = p.ProviderId });
            builder.Property(p => p.AttributeId).HasColumnName("AttributeId");
			builder.Property(p => p.FieldId).HasColumnName("FieldId");
            builder.Property(p => p.ProviderId).HasColumnName("DataProviderId");
            builder.Property(p => p.Value).HasColumnName("Value");
        }
    }
}