using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BUKEP.DIRECTORY.Admin.Models
{
    public class AttributeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "не указано имя атрибута")]
        public string Name { get; set; }

        [Required(ErrorMessage = "не указан описание атрибута")]
        public string Description { get; set; }
    }
}
