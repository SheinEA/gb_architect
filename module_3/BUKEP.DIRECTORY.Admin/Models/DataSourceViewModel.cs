using System.ComponentModel.DataAnnotations;

namespace BUKEP.DIRECTORY.Admin.Models
{
    public class DataSourceViewModel
    {
		public int Id { get; set; }

		[Required(ErrorMessage = "не указано имя источника данных")]
		public string Name { get; set; }

		[Required(ErrorMessage = "не указано описание источника данных")]
		public string Description { get; set; }

		public int ProviderId { get; set; }
	}
}
