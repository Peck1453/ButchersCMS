using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Butchers.Data.BEANS
{
    class CartBEAN
    {
        [Display(Name = "Cart Id")]
        public int CartId { get; set; }
        public CartBEAN() { }
    }
}
