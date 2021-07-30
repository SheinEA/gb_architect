using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BUKEP.DIRECTORY.Db.Map
{
    internal class DataProviderEntityMap : IEntityTypeConfiguration<DataProviderEntity>
    {
        public void Configure(EntityTypeBuilder<DataProviderEntity> builder)
        {
			builder.ToTable("DataProvider", "dir");

			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id).HasColumnName("Id");
			builder.Property(p => p.Name).HasColumnName("Name");
		}
    }
}