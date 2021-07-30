using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BUKEP.DIRECTORY.Admin.Models
{
    public class DataProviderViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "не указано имя провайдера")]
        public string Name { get; set; }

        public List<AttributeViewModel> DataSourceAttributes { get; set; }

        public List<AttributeViewModel> FieldAttributes { get; set; }
    }
}
