using BUKEP.DATA.Db;
using BUKEP.DIRECTORY.Db;
using System.Collections.Generic;
using System.Linq;

namespace BUKEP.DIRECTORY
{
    public class DataSourceService : IDataSourceService
    {
        private readonly IDbRepository<DataSourceEntity> _dataSourceRepo;

        public DataSourceService(IDbRepository<DataSourceEntity> dataSourceRepo)
        {
            _dataSourceRepo = dataSourceRepo;
        }

        public DataSource Add(DataSource dataSource)
        {
            var entity = new DataSourceEntity
            {
                Name = dataSource.Name,
                Description = dataSource.Description,
                DataProviderId = dataSource.ProviderId
            };

            _dataSourceRepo.Add(entity);

            dataSource.Id = entity.Id;
            return dataSource;
        }

        public IEnumerable<DataSource> Get()
        {
            var entities = _dataSourceRepo.Table.ToList();

            var dataSources = entities.Select(i => new DataSource
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                ProviderId = i.DataProviderId
            }).ToList();

            return dataSources;
        }
    }
}
