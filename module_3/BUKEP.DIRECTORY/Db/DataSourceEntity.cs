namespace BUKEP.DIRECTORY.Db
{
    public class DataSourceEntity
    {
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
        /// Идентификато провайдера данных
        /// </summary>
        public int DataProviderId { get; set; }
    }
}
