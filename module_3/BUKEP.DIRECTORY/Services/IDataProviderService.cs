using System.Collections.Generic;

namespace BUKEP.DIRECTORY
{
    public interface IDataProviderService
    {
        DataProvider GetProvider(int id);

        IEnumerable<DataProvider> GetProviders();

        DataProvider Add(string name);

        void AddDataSourceAttribute(int providerId, int attributeId);

        void AddFieldAttribute(int providerId, int attributeId);
    }
}
