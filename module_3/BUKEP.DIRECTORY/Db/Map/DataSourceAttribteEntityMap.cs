using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BUKEP.DIRECTORY.Db.Map
{
    internal class DataSourceAttribteEntityMap : IEntityTypeConfiguration<DataSourceAttribteEntity>
    {
        public void Configure(EntityTypeBuilder<DataSourceAttribteEntity> builder)
        {
			builder.ToTable("DataSourceAttribute", "dir");

			builder.HasKey( p => new { p.ProviderId, p.AttributeId });
			builder.Property(p => p.ProviderId).HasColumnName("DataProviderId");
			builder.Property(p => p.AttributeId).HasColumnName("AttributeId");
        }
    }
}