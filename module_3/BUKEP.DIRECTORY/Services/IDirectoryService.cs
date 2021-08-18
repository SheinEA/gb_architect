using System;
using System.Collections.Generic;
using System.Text;

namespace BUKEP.DIRECTORY
{
    public interface IDirectoryService
    {
        /// <summary>
        /// Получить все справочники
        /// </summary>
        /// <returns></returns>
        IEnumerable<Directory> Get();

        /// <summary>
        /// Получить справочник
        /// </summary>
        /// <param name="id">Идентификатор справочника</param>
        /// <returns></returns>
        Directory Get(int id);

        /// <summary>
        /// Добавить справочник
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <param name="sourceId">Источник данных</param>
        /// <param name="accessObjectId">Объект доступа</param>
        /// <returns></returns>
        Directory Add(string title, int sourceId, long accessObjectId);
    }
}
