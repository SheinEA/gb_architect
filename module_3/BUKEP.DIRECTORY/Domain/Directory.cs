namespace BUKEP.DIRECTORY
{
	/// <summary>
	/// Справочник
	/// </summary>
	public class Directory
	{
		/// <summary>
		/// Идентификатор справочника
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Заголовок справочника
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Идентификатор объекта доступа
		/// </summary>
		public long AccessObjectId { get; set; }

		/// <summary>
		/// Источник данных
		/// </summary>
		public DataSource Source { get; set; }
	}
}
