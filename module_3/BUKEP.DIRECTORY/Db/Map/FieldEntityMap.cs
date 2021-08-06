using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BUKEP.DIRECTORY.Db.Map
{
    internal class FieldEntityMap : IEntityTypeConfiguration<FieldEntity>
    {
        public void Configure(EntityTypeBuilder<FieldEntity> builder)
        {
			builder.ToTable("Field", "dir");

			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id).HasColumnName("Id");
			builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.DataSourceId).HasColumnName("DataSourceId");
            builder.Property(p => p.DataTypeId).HasColumnName("DataTypeId");
        }
    }
}