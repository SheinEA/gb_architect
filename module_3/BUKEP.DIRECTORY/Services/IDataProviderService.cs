using System.Collections.Generic;

namespace BUKEP.DIRECTORY
{
    public interface IDataProviderService
    {
        /// <summary>
        /// Получить все провайдеры
        /// </summary>
        IEnumerable<DataProvider> Get();

        /// <summary>
        /// Получить провайдер по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор провайдера</param>
        DataProvider Get(int id);

        /// <summary>
        /// Добавить провайдер
        /// </summary>
        /// <param name="name">Имя</param>
        DataProvider Add(string name);

        /// <summary>
        /// Добавить атрибут к источнику
        /// </summary>
        /// <param name="providerId">Идентификатор провайдера</param>
        /// <param name="attributeId">Идентификатор атрибута</param>
        void AddSourceAttribute(int providerId, int attributeId);

        /// <summary>
        /// Добавить атрибут к полю
        /// </summary>
        /// <param name="providerId">Идентификатор провайдера</param>
        /// <param name="attributeId">Идентификатор атрибута</param>
        void AddFieldAttribute(int providerId, int attributeId);
    }
}