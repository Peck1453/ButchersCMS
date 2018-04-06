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
        [Display(Name = "Id")]
        public int ProductItemId { get; set; }

        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [Display(Name = "Product")]
        [Required (ErrorMessage = "Please enter the name of the product")]
        public string Product { get; set; }

        [Display(Name = "Cost")]
        [Required (ErrorMessage = "Please provide the product price")]
        [Range (0.01, 100.00, ErrorMessage = "Product Price needs to be between £0.01 and £100.00")]
        public Decimal Cost { get; set; }

        [Display(Name = "Measured")]
        public int MeasurementId { get; set; }

        [Display(Name = "Measured")]
        public string MeasurementName { get; set; }

        [Display(Name = "Discontinued?")]
        public bool Discontinued { get; set; }

        [Display(Name = "Stock Quantity")]
        public int StockQty { get; set; }

        public ProductItemBEAN() { }
    }
}
