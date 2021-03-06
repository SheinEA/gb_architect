using BUKEP.DATA.Db;
using BUKEP.DIRECTORY.Db;
using System.Collections.Generic;
using System.Linq;

namespace BUKEP.DIRECTORY
{
    public class DataProviderService : IDataProviderService
    {
        private readonly IDbRepository<DataProviderEntity> _providerRepo;
        private readonly IDbRepository<FieldAttributeEntity> _fieldAttributeRepo;
        private readonly IDbRepository<DataSourceAttribteEntity> _sourceAttributeRepo;
        private readonly IAttributeService _attributeService;

        public DataProviderService(
            IDbRepository<DataProviderEntity> providerRepo,
            IDbRepository<FieldAttributeEntity> fieldAttributeRepo,
            IDbRepository<DataSourceAttribteEntity> sourceAttributeRepo,
            IAttributeService attributeService)
        {
            _providerRepo = providerRepo;
            _fieldAttributeRepo = fieldAttributeRepo;
            _sourceAttributeRepo = sourceAttributeRepo;
            _attributeService = attributeService;
        }

        /// <inheritdoc/>
        public IEnumerable<DataProvider> Get()
        {
            var providerEntities = _providerRepo.Table.ToList();
            var attributes = _attributeService.Get();
            var sourceAttributeEntities = _sourceAttributeRepo.Table.ToList();
            var fieldAttributeEntities = _fieldAttributeRepo.Table.ToList();

            var providers = providerEntities.Select(i => new DataProvider { Id = i.Id, Name = i.Name, }).ToList();

            foreach (var provider in providers)
            {
                provider.FieldAttributes = attributes.Where(i => fieldAttributeEntities.Where(x => x.ProviderId == provider.Id).Select(x => x.AttributeId).Contains(i.Id)).ToList();
                provider.SourceAttributes = attributes.Where(i => sourceAttributeEntities.Where(x => x.ProviderId == provider.Id).Select(x => x.AttributeId).Contains(i.Id)).ToList();
            }

            return providers;
        }

        /// <inheritdoc/>
        public DataProvider Get(int id)
        {
            return Get().FirstOrDefault(i => i.Id == id);
        }

        /// <inheritdoc/>
        public DataProvider Add(string name)
        {
            var data = new DataProviderEntity { Name = name };
            _providerRepo.Add(data);

            return new DataProvider { Id = data.Id, Name = data.Name };
        }

        /// <inheritdoc/>
        public void AddSourceAttribute(int providerId, int attributeId)
        {
            _sourceAttributeRepo.Add(new DataSourceAttribteEntity { ProviderId = providerId, AttributeId = attributeId });
        }

        /// <inheritdoc/>
        public void AddFieldAttribute(int providerId, int attributeId)
        {
            _fieldAttributeRepo.Add(new FieldAttributeEntity { ProviderId = providerId, AttributeId = attributeId });
        }
    }
}