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
        public int ProductItemId { get; set; }

        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        [Required (ErrorMessage = "Please enter the name of the product")]
        public string Product { get; set; }

        [Display(Name = "Cost")]
        [Required (ErrorMessage = "Please provide the product price")]
        [Range (0.01, 100.00, ErrorMessage = "Product Price needs to be between £0.01 and £100.00")]
        public Decimal Cost { get; set; }

        [Display(Name = "Kg or Per Unit?")]
        public bool PerUnit { get; set; }

        [Display(Name = "Discontinued?")]
        public bool Discontinued { get; set; }

        public ProductItemBEAN() { }
    }
}
