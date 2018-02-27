using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.BEANS
{
    public class ProductBEAN
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Meat")]
        public string Meat { get; set; }

        [Display(Name = "Meat")]
        public int MeatId { get; set; }

        [Display(Name = "Product")]
        public string Name { get; set; }

        public ProductBEAN() {}

    }
}
