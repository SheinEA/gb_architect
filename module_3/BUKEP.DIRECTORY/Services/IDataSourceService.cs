using System.Collections.Generic;

namespace BUKEP.DIRECTORY
{
    public interface IDataSourceService
    {
        /// <summary>
        /// Получить все источники
        /// </summary>
        /// <returns></returns>
        IEnumerable<DataSource> Get();

        /// <summary>
        /// Получить источник по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор источника</param>
        /// <returns></returns>
        DataSource Get(int id);

        /// <summary>
        /// Добавить источник
        /// </summary>
        /// <param name="dataSource">Источник</param>
        /// <returns></returns>
        DataSource Add(DataSource dataSource);

        /// <summary>
        /// Сохранить значение атрибута для источника данных
        /// </summary>
        /// <param name="attributeId">Идентификатор атрибута</param>
        /// <param name="sourceId">Идентификатор источника</param>
        /// <param name="providerId">Идентификатор провайдера</param>
        /// <param name="value">Значение</param>
        void SaveSourceAttribute(int attributeId, int sourceId, int providerId, string value);
    }
}