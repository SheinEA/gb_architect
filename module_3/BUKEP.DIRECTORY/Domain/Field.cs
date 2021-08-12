using System.Collections.Generic;

namespace BUKEP.DIRECTORY
{
	/// <summary>
	/// Поле справочника
	/// </summary>
	public class Field
	{
        public Field()
        {
			Attributes = new List<Attribute>();
        }

        /// <summary>
        /// Идентификатор поля справочника
        /// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Наименование поля
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Источник данных
		/// </summary>
		public int SourceId { get; set; }

		/// <summary>
		/// Тип данных
		/// </summary>
		public DataType DataType { get; set; }

		/// <summary>
		/// Атрибуты поля данных
		/// </summary>
		public List<Attribute> Attributes { get; set; }
	}
}
