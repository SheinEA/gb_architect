using BUKEP.DIRECTORY.Db.Map;
using Microsoft.EntityFrameworkCore;

namespace BUKEP.DIRECTORY.Db
{
    public class DirectoryDbContext : DbContext
    {
        public DirectoryDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DataSourceAttribteEntityMap());
            modelBuilder.ApplyConfiguration(new FieldAttribteEntityMap());
            modelBuilder.ApplyConfiguration(new DataProviderEntityMap());
            modelBuilder.ApplyConfiguration(new AttributeMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}