using BUKEP.DATA.Db;
using BUKEP.DIRECTORY.Db;
using System.Collections.Generic;
using System.Linq;

namespace BUKEP.DIRECTORY
{
    public class DataProviderService : IDataProviderService
    {
        private readonly IDbRepository<DataProviderEntity> _providerRepo;
        private readonly IDbRepository<FieldAttribteEntity> _fieldAttributeRepo;
        private readonly IDbRepository<DataSourceAttribteEntity> _sourceAttributeRepo;
        private readonly IAttributeService _attributeService;

        public DataProviderService(
            IDbRepository<DataProviderEntity> providerRepo,
            IDbRepository<FieldAttribteEntity> fieldAttributeRepo,
            IDbRepository<DataSourceAttribteEntity> sourceAttributeRepo,
            IAttributeService attributeService)
        {
            _providerRepo = providerRepo;
            _fieldAttributeRepo = fieldAttributeRepo;
            _sourceAttributeRepo = sourceAttributeRepo;
            _attributeService = attributeService;
        }

        public DataProvider Add(string name)
        {
            var data = new DataProviderEntity { Name = name };
            _providerRepo.Add(data);

            return new DataProvider { Id = data.Id, Name = data.Name };
        }

        public IEnumerable<DataProvider> GetProviders()
        {
            var providerEntities = _providerRepo.Table.ToList();
            var attributes = _attributeService.Get();
            var sourceAttributeEntities = _sourceAttributeRepo.Table.ToList();
            var fieldAttributeEntities = _fieldAttributeRepo.Table.ToList();

            var providers = providerEntities.Select(i => new DataProvider { Id = i.Id, Name = i.Name, }).ToList();

            foreach (var provider in providers)
            {
                provider.FieldAttributes = attributes.Where(i => fieldAttributeEntities.Where(x => x.ProviderId == provider.Id).Select(x => x.AttributeId).Contains(i.Id)).ToList();
                provider.DataSourceAttributes = attributes.Where(i => sourceAttributeEntities.Where(x => x.ProviderId == provider.Id).Select(x => x.AttributeId).Contains(i.Id)).ToList();
            }

            return providers;
        }

        public DataProvider GetProvider(int id)
        {
            return GetProviders().FirstOrDefault(i => i.Id == id);
        }

        public void AddDataSourceAttribute(int providerId, int attributeId)
        {
            _sourceAttributeRepo.Add(new DataSourceAttribteEntity { ProviderId = providerId, AttributeId = attributeId });
        }

        public void AddFieldAttribute(int providerId, int attributeId)
        {
            _fieldAttributeRepo.Add(new FieldAttribteEntity { ProviderId = providerId, AttributeId = attributeId });
        }
    }
}