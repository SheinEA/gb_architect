using BUKEP.DATA.Db;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUKEP.DIRECTORY
{
    public class AttributeService : IAttributeService
    {
        private readonly IDbRepository<AttributeEntity> _attributeRepo;

        public AttributeService(IDbRepository<AttributeEntity> attributeRepo)
        {
            _attributeRepo = attributeRepo;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public void Delete(int Id)
        {
            _attributeRepo.Remove(i => i.Id == Id);
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public void Update(Attribute attribute)
        {
            throw new NotImplementedException();
        }
    }
}