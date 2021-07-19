using System;
using System.Collections.Generic;
using System.Text;

namespace BUKEP.DIRECTORY
{
	/// <summary>
	/// Источник данных
	/// </summary>
	public class DataSource
	{
		/// <summary>
		/// Наименование
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Описание
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Поля справочника
		/// </summary>
		public List<Field> Fields { get; set; }


	}
}
