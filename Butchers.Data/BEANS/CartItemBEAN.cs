using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.BEANS
{
    public class CartItemBEAN
    {
        [Display(Name = "Id")]
        public int CartItemId { get; set; }

        [Display(Name = "Product Item")]
        public string ProductItem { get; set; }

        [Display(Name = "Product Item Id")]
        public int ProductItemId { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Cart Id")]
        public int CartId { get; set; }

        [Display(Name = "Item Cost (£)")]
        public decimal ItemCostSubtotal { get; set; }

        [Display(Name = "Cart Total (£)")]
        public decimal CartTotal { get; set; }

        public CartItemBEAN() { }
    }
}
