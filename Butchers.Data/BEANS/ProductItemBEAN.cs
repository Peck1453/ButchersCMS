using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.BEANS
{
    public class ProductItemBEAN
    {
        [Display(Name = "Item Id")]
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        public string Product { get; set; }

        [Display(Name = "Cost")]
        public Decimal Cost { get; set; }

        [Display(Name = "Kg or Per Unit?")]
        public bool PerUnit { get; set; }

        [Display(Name = "Discontinued?")]
        public bool Discontinued { get; set; }

        public ProductItemBEAN() { }
    }
}
