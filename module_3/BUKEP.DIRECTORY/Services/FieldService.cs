using BUKEP.DATA.Db;
using BUKEP.DIRECTORY.Db;
using System.Collections.Generic;
using System.Linq;

namespace BUKEP.DIRECTORY
{
    public class FieldService : IFieldService
    {
        private readonly IAttributeService _attributeService;
        private readonly IDbRepository<FieldEntity> _fieldRepo;
        private readonly IDbRepository<FieldAttributeValueEntity> _fieldAttributeRepo;

        public FieldService(IDbRepository<FieldEntity> fieldRepo, IDbRepository<FieldAttributeValueEntity> fieldAttributeRepo, IAttributeService attributeService)
        {
            _fieldRepo = fieldRepo;
            _fieldAttributeRepo = fieldAttributeRepo;
            _attributeService = attributeService;
        }

        /// <inheritdoc/>
        public IEnumerable<Field> Get()
        {
            var attributes = _attributeService.Get();
            var entities = _fieldRepo.Table.ToList();
            var valueEntities = _fieldAttributeRepo.Table.ToList();

            var fields = entities.Select(i => new Field()
            {
                Id = i.Id,
                Name = i.Name,
                SourceId = i.DataSourceId,
                DataType = (DataType)i.DataTypeId,
                Attributes = valueEntities
                    .Where(v => v.FieldId == i.Id).ToList()
                    .Select(v =>
                    {
                        var attribute = attributes.FirstOrDefault(x => x.Id == v.AttributeId);
                        if (attribute != null)
                        {
                            return new Attribute
                            {
                                Id = attribute.Id,
                                Name = attribute.Name,
                                Description = attribute.Description,
                                Value = v.Value
                            };
                        }
                        return null;
                    })
                    .Where(a => a != null).ToList()
            });

            return fields.ToList();
        }

        /// <inheritdoc/>
        public Field Get(int id)
        {
            return Get().FirstOrDefault(i => i.Id == id);
        }

        /// <inheritdoc/>
        public IEnumerable<Field> GetBySourceId(int sourceId)
        {
            return Get().Where(i => i.SourceId == sourceId).ToList();
        }

        /// <inheritdoc/>
        public Field Add(Field field)
        {
            var entity = new FieldEntity
            {
                Name = field.Name,
                DataSourceId = field.SourceId,
                DataTypeId = (int)field.DataType
            };

            _fieldRepo.Add(entity);
            field.Id = entity.Id;

            return field;
        }

        /// <inheritdoc/>
        public void SaveFieldAttribute(int attributeId, int fieldId, int providerId, string value)
        {
            var entity = _fieldAttributeRepo.Table.FirstOrDefault(i => i.AttributeId == attributeId && i.FieldId == fieldId && i.ProviderId == providerId);
            if (entity != null)
            {
                entity.Value = value;
                _fieldAttributeRepo.Update(entity);
            }
            else
            {
                entity = new FieldAttributeValueEntity
                {
                    AttributeId = attributeId,
                    FieldId = fieldId,
                    ProviderId = providerId,
                    Value = value
                };
                _fieldAttributeRepo.Add(entity);
            }
        }
    }
}