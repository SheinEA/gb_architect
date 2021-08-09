using BUKEP.DATA.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUKEP.DIRECTORY
{
    public class AttributeService : IAttributeService
    {
        private readonly IDbRepository<AttributeEntity> _attributeRepo;

        public AttributeService(IDbRepository<AttributeEntity> attributeRepo)
        {
            _attributeRepo = attributeRepo;
        }

        public Attribute Add(Attribute attribute)
        {
            var entity = new AttributeEntity
            {
                Name = attribute.Name,
                Description = attribute.Description
            };

            if (_attributeRepo.Add(entity))
            {
                attribute.Id = entity.Id;
                return attribute;
            }

            return null;
        }

        public void Delete(int Id)
        {
            _attributeRepo.Remove(i => i.Id == Id);
        }

        public IEnumerable<Attribute> Get()
        {
            var entities = _attributeRepo.Get(i => i).ToList();
            var attributes = entities.Select(i => new Attribute
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description
            }).ToList();

            return attributes;
        }

        public void Update(Attribute attribute)
        {
            throw new NotImplementedException();
        }
    }
}