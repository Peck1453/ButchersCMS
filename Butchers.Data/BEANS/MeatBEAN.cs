using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.BEANS
{
    public class MeatBEAN
    {
        [Display(Name = "Meat ID")]
        public int Id { get; set; }

        [Display(Name = "Meat Name")]
        [Required (ErrorMessage = "Please supply a meat name")]
        [StringLength (20, ErrorMessage = "Meat Name may contain up to 20 characters")]
        public string Name { get; set; }
    }
}
