using System;
using System.Collections.Generic;
using System.Text;

namespace BUKEP.DIRECTORY.Db
{
    public class FieldAttributeValueEntity
    {
        /// <summary>
        /// Идентификатор провайдера
        /// </summary>
        public int ProviderId { get; set; }

        /// <summary>
        /// Идентификатор атрибута
        /// </summary>
        public int AttributeId { get; set; }

        /// <summary>
        /// Идентификатор поля данных
        /// </summary>
        public int FieldId { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; set; }
    }
}
