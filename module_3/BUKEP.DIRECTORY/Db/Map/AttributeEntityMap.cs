using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BUKEP.DIRECTORY.Db.Map
{
    internal class AttributeEntityMap : IEntityTypeConfiguration<AttributeEntity>
    {
        public void Configure(EntityTypeBuilder<AttributeEntity> builder)
        {
			builder.ToTable("Attribute", "dir");

			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id).HasColumnName("Id");
			builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.Description).HasColumnName("Description");
        }
    }
}