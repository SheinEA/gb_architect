using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BUKEP.DIRECTORY.Db.Map
{
    internal class DataSourceAttributeValueEntityMap : IEntityTypeConfiguration<DataSourceAttributeValueEntity>
    {
        public void Configure(EntityTypeBuilder<DataSourceAttributeValueEntity> builder)
        {
			builder.ToTable("DataSourceAttributeValue", "dir");

            builder.HasKey(p => new { AttributeId = p.AttributeId, DataSourceId = p.DataSourceId, DataProviderId = p.ProviderId });
            builder.Property(p => p.AttributeId).HasColumnName("AttributeId");
			builder.Property(p => p.DataSourceId).HasColumnName("DataSourceId");
            builder.Property(p => p.ProviderId).HasColumnName("DataProviderId");
            builder.Property(p => p.Value).HasColumnName("Value");
        }
    }
}