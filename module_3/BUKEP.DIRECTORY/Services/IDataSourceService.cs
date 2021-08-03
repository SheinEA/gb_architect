using System.Collections.Generic;

namespace BUKEP.DIRECTORY
{
    public interface IDataSourceService
    {
        IEnumerable<DataSource> Get();

        DataSource Add(DataSource dataSource);
    }
}
