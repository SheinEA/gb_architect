using BUKEP.DIRECTORY.Db.Map;
using Microsoft.EntityFrameworkCore;

namespace BUKEP.DIRECTORY.Db
{
    public class DirectoryDbContext : DbContext
    {
        public DirectoryDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DataSourceAttributeValueEntityMap());
            modelBuilder.ApplyConfiguration(new DataSourceAttribteEntityMap());
            modelBuilder.ApplyConfiguration(new FieldAttributeValueEntityMap());
            modelBuilder.ApplyConfiguration(new FieldAttributeEntityMap());
            modelBuilder.ApplyConfiguration(new DataProviderEntityMap());
            modelBuilder.ApplyConfiguration(new DataSourceEntityMap());
            modelBuilder.ApplyConfiguration(new DirectoryEntityMap());
            modelBuilder.ApplyConfiguration(new AttributeEntityMap());
            modelBuilder.ApplyConfiguration(new FieldEntityMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}