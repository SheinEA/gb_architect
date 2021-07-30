using System.Collections.Generic;

namespace BUKEP.DIRECTORY
{
    /// <summary>
    /// Провайдер данных
    /// </summary>
    public class DataProvider
    {
        public DataProvider()
        {
            DataSourceAttributes = new List<Attribute>();
            FieldAttributes = new List<Attribute>();
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Атрибуты источника данных
        /// </summary>
        public List<Attribute> DataSourceAttributes { get; set; }

        /// <summary>
        /// Атрибуты поля
        /// </summary>
        public List<Attribute> FieldAttributes { get; set; }
    }
}
