using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BUKEP.DIRECTORY.Db.Map
{
    internal class DataSourceEntityMap : IEntityTypeConfiguration<DataSourceEntity>
    {
        public void Configure(EntityTypeBuilder<DataSourceEntity> builder)
        {
			builder.ToTable("DataSource", "dir");

			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id).HasColumnName("Id");
			builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.Description).HasColumnName("Description");
            builder.Property(p => p.DataProviderId).HasColumnName("DataProviderId");
        }
    }
}