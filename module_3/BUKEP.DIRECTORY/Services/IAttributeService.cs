using System;
using System.Collections.Generic;
using System.Text;

namespace BUKEP.DIRECTORY
{
    public interface IAttributeService
    {
        IEnumerable<Attribute> Get();

        Attribute Add(Attribute attribute);

        void Delete(int Id);

        void Update(Attribute attribute);
    }
}
