using BUKEP.DATA.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUKEP.DIRECTORY
{
    public class AttributeService : IAttributeService
    {
        private readonly IDbRepository<Attribute> _attributeRepo;

        public AttributeService(IDbRepository<Attribute> attributeRepo)
        {
            _attributeRepo = attributeRepo;
        }

        public Attribute Add(Attribute attribute)
        {
            if (_attributeRepo.Add(attribute))
                return attribute;

            return null;
        }

        public void Delete(int Id)
        {
            _attributeRepo.Remove(i => i.Id == Id);
        }

        public IEnumerable<Attribute> Get()
        {
            return _attributeRepo.Get(i => i).ToList();
        }

        public void Update(Attribute attribute)
        {
            throw new NotImplementedException();
        }
    }
}
