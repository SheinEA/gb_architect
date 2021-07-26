using System.Collections.Generic;

namespace BUKEP.DIRECTORY
{
    public interface IDirectoryDataGateway
    {
        List<DataRow> Get();

        List<DataRow> Get(List<DataField> dataFields);

        void Add(DataRow dataRow);

        void Update(DataRow dataRow);

        void Delete(DataRow dataRow);
    }
}
