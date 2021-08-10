using System.Collections.Generic;

namespace BUKEP.DIRECTORY
{
    public interface IFieldService
    {
        /// <summary>
        /// Получить поля по идентификатору источника
        /// </summary>
        /// <param name="sourceId">Идентификатор источника</param>
        IEnumerable<Field> GetBySourceId(int sourceId);

        /// <summary>
        /// Добавить новое поле
        /// </summary>
        /// <param name="field">Поле</param>
        Field Add(Field field);
    }
}
