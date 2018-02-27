using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.BEANS
{
    public class OrderBEAN
    {
        [Display(Name = "Order Id")]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ordered")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Collect From")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CollectFrom { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Collect By")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CollectBy { get; set; }

        [Display(Name = "Customer")]
        public int Customer { get; set; }

        [Display(Name = "Collected?")]
        public bool Collected { get; set; }

        [Display(Name = "Promo Code")]
        public string PromoCode { get; set; }

        [Display(Name = "Total Cost")]
        public Decimal TotalCost { get; set; }
        public OrderBEAN() { }
    }
}
