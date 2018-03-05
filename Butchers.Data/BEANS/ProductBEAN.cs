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
        [Display(Name = "Product Id")]
        public int Id { get; set; }

        [Display(Name = "Meat Type")]
        public string Meat { get; set; }
        [Display(Name = "Item Id")]
        public string Name { get; set; }

        public int MeatId { get; set; }

        public ProductBEAN() {}

    }
}
