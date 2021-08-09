using System.Collections.Generic;

namespace BUKEP.DIRECTORY
{
    public interface IDataSourceService
    {
        IEnumerable<DataSource> Get();

        DataSource Get(int id);

        DataSource Add(DataSource dataSource);

        void SaveSourceAttribute(int attributeId, int sourceId, int providerId, string value);

        void SaveFieldAttribute(int fieldId, int sourceId, int providerId, string value);
    }
}