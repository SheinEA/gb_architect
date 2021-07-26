using System;
using System.Collections.Generic;
using System.Text;

namespace BUKEP.DIRECTORY
{
	/// <summary>
	/// Поле справочника
	/// </summary>
	public class Field
	{
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
		public int DataSourceId { get; set; }

		/// <summary>
		/// Тип данных
		/// </summary>
		public DataType DataType { get; set; }

	}
}
