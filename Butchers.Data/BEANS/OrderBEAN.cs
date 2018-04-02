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
        [Display(Name = "Order No.")]
        public int OrderNo { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ordered")]
        [Required(ErrorMessage = "Please add the date of the order")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Please Enter the Customer Number")]
        [StringLength(128, ErrorMessage = "Maximum Length for customer number is 128 characters")]
        [Display(Name = "Customer")]
        public string CustomerNo { get; set; }

        [Display(Name = "Promo Code")]
        [StringLength(150, ErrorMessage = "Maximum Length for a Promotional Code is 150 characters")]
        public string PromoCode { get; set; }

        [Display(Name = "Cost")]
        public Decimal TotalCost { get; set; }

        [Display(Name = "Cost (Discount Applied)")]
        public Decimal TotalCostAfterDiscount { get; set; }

        [Display(Name = "Amount Saved")]
        public Decimal AmountSaved { get; set; }

        [Display(Name = "Cart Id")]
        public int CartId { get; set; }

        // Order Details
        [DataType(DataType.Date)]
        [Display(Name = "Collect From")]
        [Required(ErrorMessage = "Please add the earliest collection date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CollectFrom { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please add the lastest collection date")]
        [Display(Name = "Collect By")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CollectBy { get; set; }

        [Display(Name = "Status")]
        public bool Collected { get; set; }
        
        public OrderBEAN() { }
    }
}
