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
        public DataSource()
        {
			Fields = new List<Field>();
        }

        /// <summary>
        /// Идентификатор провайдера данных
        /// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Наименование
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Описание
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Идентификатор провайдера данных
		/// </summary>
		public int ProviderId { get; set;  }

		/// <summary>
		/// Поля справочника
		/// </summary>
		public List<Field> Fields { get; set; }
	}
}
