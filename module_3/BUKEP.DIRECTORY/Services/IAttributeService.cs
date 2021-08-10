﻿using System.Collections.Generic;

namespace BUKEP.DIRECTORY
{
    public interface IAttributeService
    {
        /// <summary>
        /// Получить все атрибуты
        /// </summary>
        IEnumerable<Attribute> Get();

        /// <summary>
        /// Добавить атрибут
        /// </summary>
        /// <param name="attribute">Атрибут</param>
        Attribute Add(Attribute attribute);

        /// <summary>
        /// Удалить атрибут
        /// </summary>
        /// <param name="Id">Идентификатор атрибута</param>
        void Delete(int Id);

        /// <summary>
        /// Обновить атрибут
        /// </summary>
        /// <param name="attribute">Атрибут</param>
        void Update(Attribute attribute);
    }
}
