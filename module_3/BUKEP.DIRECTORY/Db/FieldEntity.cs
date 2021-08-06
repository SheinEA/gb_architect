namespace BUKEP.DIRECTORY.Db
{
    public class FieldEntity
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
		public int DataTypeId { get; set; }
	}
}
