using System.Collections.Generic;

namespace BUKEP.DIRECTORY
{
    public interface IFieldService
    {
        /// <summary>
        /// Получить все поля
        /// </summary>
        /// <returns></returns>
        IEnumerable<Field> Get();

        /// <summary>
        /// Получить поле по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор поля</param>
        Field Get(int id);

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

        /// <summary>
        /// Сохранить значение атрибута для поля данных
        /// </summary>
        /// <param name="attributeId">Идентификатор атрибута</param>
        /// <param name="fieldId">Идентификатор источника</param>
        /// <param name="providerId">Идентификатор провайдера</param>
        /// <param name="value">Значение</param>
        void SaveFieldAttribute(int attributeId, int fieldId, int providerId, string value);
    }
}
