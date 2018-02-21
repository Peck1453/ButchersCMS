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
        [Display(Name = "Item Id")]
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        public string ProductItem { get; set; }

        [Display(Name = "Quantity")]
        public Decimal Quantity { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }
        public CartItemBEAN() { }
    }
}
