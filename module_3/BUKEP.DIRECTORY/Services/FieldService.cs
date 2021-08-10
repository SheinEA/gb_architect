using BUKEP.DATA.Db;
using BUKEP.DIRECTORY.Db;
using System.Collections.Generic;
using System.Linq;

namespace BUKEP.DIRECTORY
{
    public class FieldService : IFieldService
    {
        private readonly IDbRepository<FieldEntity> _fieldRepo;
        private readonly IDbRepository<FieldAttributeValueEntity> _fieldAttributeRepo;

        public FieldService(IDbRepository<FieldEntity> fieldRepo, IDbRepository<FieldAttributeValueEntity> fieldAttributeRepo)
        {
            _fieldRepo = fieldRepo;
            _fieldAttributeRepo = fieldAttributeRepo;
        }

        /// <inheritdoc/>
        public IEnumerable<Field> GetBySourceId(int sourceId)
        {
            var entities = _fieldRepo.Table.Where(i => i.DataSourceId == sourceId).ToList();

            var fields = entities.Select(i => new Field()
            {
                Id = i.Id,
                Name = i.Name,
                DataSourceId = i.DataSourceId,
                DataType = (DataType)i.DataTypeId
            });

            return fields.ToList();
        }

        /// <inheritdoc/>
        public Field Add(Field field)
        {
            var entity = new FieldEntity
            {
                Name = field.Name,
                DataSourceId = field.DataSourceId,
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