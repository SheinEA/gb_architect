using BUKEP.DATA.Db;
using BUKEP.DIRECTORY.Db;
using System.Collections.Generic;
using System.Linq;

namespace BUKEP.DIRECTORY
{
    public class DataSourceService : IDataSourceService
    {
        private readonly IFieldService _fieldService;
        private readonly IAttributeService _attributeService;
        private readonly IDbRepository<DataSourceEntity> _sourceRepo;
        private readonly IDbRepository<DataSourceAttributeValueEntity> _sourceAttributeRepo;

        public DataSourceService(IDbRepository<DataSourceEntity> sourceRepo, IDbRepository<DataSourceAttributeValueEntity> sourceAttributeRepo,
            IAttributeService attributeService, IFieldService fieldService)
        {
            _sourceRepo = sourceRepo;
            _sourceAttributeRepo = sourceAttributeRepo;
            _attributeService = attributeService;
            _fieldService = fieldService;
        }

        /// <inheritdoc/>
        public IEnumerable<DataSource> Get()
        {
            var fields = _fieldService.Get();
            var attributes = _attributeService.Get();
            var sourceEntities = _sourceRepo.Table.ToList();
            var valueEntities = _sourceAttributeRepo.Table.ToList();

            var dataSources = sourceEntities.Select(i => new DataSource
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                ProviderId = i.DataProviderId,
                Attributes = valueEntities
                    .Where(v => v.DataSourceId == i.Id && v.ProviderId == i.DataProviderId).ToList()
                    .Select(v =>
                    {
                        var attribute = attributes.FirstOrDefault(x => x.Id == v.AttributeId);
                        if (attribute != null)
                        {
                            return new Attribute
                            {
                                Id = attribute.Id,
                                Name = attribute.Name,
                                Description = attribute.Description,
                                Value = v.Value
                            };
                        }
                        return null;
                    })
                    .Where(a => a != null).ToList(),
                Fields = fields.Where(f => f.SourceId == i.Id).ToList()
            }).ToList();

            return dataSources;
        }

        /// <inheritdoc/>
        public DataSource Get(int id)
        {
            return Get().FirstOrDefault(i => i.Id == id);
        }

        /// <inheritdoc/>
        public DataSource Add(DataSource dataSource)
        {
            var entity = new DataSourceEntity
            {
                Name = dataSource.Name,
                Description = dataSource.Description,
                DataProviderId = dataSource.ProviderId
            };

            _sourceRepo.Add(entity);

            dataSource.Id = entity.Id;
            return dataSource;
        }

        /// <inheritdoc/>
        public void SaveSourceAttribute(int attributeId, int sourceId, int providerId, string value)
        {
            var entity = _sourceAttributeRepo.Table.FirstOrDefault(i => i.AttributeId == attributeId && i.DataSourceId == sourceId && i.ProviderId == providerId);
            if (entity != null)
            {
                entity.Value = value;
                _sourceAttributeRepo.Update(entity);
            }
            else
            {
                entity = new DataSourceAttributeValueEntity
                {
                    AttributeId = attributeId,
                    DataSourceId = sourceId,
                    ProviderId = providerId,
                    Value = value
                };
                _sourceAttributeRepo.Add(entity);
            }
        }
    }
}
