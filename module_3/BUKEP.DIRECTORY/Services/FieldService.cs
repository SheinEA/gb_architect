using BUKEP.DATA.Db;
using BUKEP.DIRECTORY.Db;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUKEP.DIRECTORY
{
    public class FieldService : IFieldService
    {
        private readonly IDbRepository<FieldEntity> _fieldRepo;

        public FieldService(IDbRepository<FieldEntity> fieldRepo)
        {
            _fieldRepo = fieldRepo;
        }

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
    }
}
