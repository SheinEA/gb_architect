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

            var providers = providerEntities.Select(i => new DataProvider
            {
                Id = i.Id,
                Name = i.Name,
                FieldAttributes = attributes.Where(i => fieldAttributeEntities.Where(x => x.ProviderId == i.Id).Select(x => x.ProviderId).Contains(i.Id)).ToList(),
                DataSourceAttributes = attributes.Where(i => sourceAttributeEntities.Where(x => x.ProviderId == i.Id).Select(x => x.ProviderId).Contains(i.Id)).ToList(),
            });;

            return providers.ToList();
        }

        public DataProvider GetProvider(int id)
        {
            return GetProviders().FirstOrDefault(i => i.Id == id);
        }
    }
}