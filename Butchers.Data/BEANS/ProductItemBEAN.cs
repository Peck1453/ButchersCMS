using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.BEANS
{
    public class ProductItemBEAN
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public Decimal Cost { get; set; }
        public bool PerUnit { get; set; }
        public bool Discontinued { get; set; }
        public ProductItemBEAN() { }
    }
}
