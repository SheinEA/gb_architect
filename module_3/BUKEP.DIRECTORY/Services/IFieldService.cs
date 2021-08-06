using System;
using System.Collections.Generic;
using System.Text;

namespace BUKEP.DIRECTORY
{
    public interface IFieldService
    {
        IEnumerable<Field> GetBySourceId(int sourceId);

        Field Add(Field field);
    }
}
