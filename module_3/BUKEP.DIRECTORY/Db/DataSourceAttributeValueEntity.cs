namespace BUKEP.DIRECTORY.Db
{
    public class DataSourceAttributeValueEntity
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
        /// Идентификатор источника данных
        /// </summary>
        public int DataSourceId { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; set; }
    }
}
