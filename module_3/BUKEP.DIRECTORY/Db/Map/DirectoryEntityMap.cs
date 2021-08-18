using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BUKEP.DIRECTORY.Db.Map
{
    internal class DirectoryEntityMap : IEntityTypeConfiguration<DirectoryEntity>
    {
        public void Configure(EntityTypeBuilder<DirectoryEntity> builder)
        {
			builder.ToTable("Directory", "dir");

			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id).HasColumnName("Id");
			builder.Property(p => p.Title).HasColumnName("Title");
            builder.Property(p => p.DataSourceId).HasColumnName("DataSourceId");
            builder.Property(p => p.AccessObjectId).HasColumnName("AccessObjectId");
        }
    }
}