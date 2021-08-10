using System.ComponentModel.DataAnnotations;

namespace BUKEP.DIRECTORY.Admin.Models
{
    public class FieldViewModel
    {
		public int Id { get; set; }

		[Required(ErrorMessage = "не указано имя поля данных")]
		public string Name { get; set; }

		public int DataSourceId { get; set; }

		public DataType DataType { get; set; }
	}
}
