using System;
using System.Collections.Generic;
using System.Text;

namespace BUKEP.DIRECTORY
{
	/// <summary>
	/// Провайдер данных
	/// </summary>
	public class DataProvider
	{
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
