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
        [Required (ErrorMessage = "Please add the date of the order")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

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

        [Required(ErrorMessage = "Please Enter the Customer Name")]
        [StringLength(128, ErrorMessage = "Maximum Length for customer's 128 characters")]
        [Display(Name = "Customer")]
        public string Customer { get; set; }

        [Display(Name = "Collected?")]
        public bool Collected { get; set; }

        [Display(Name = "Promo Code")]
        [StringLength (150, ErrorMessage = "Maximum Length for a Promotional Code is 150 characters") ]
        public string PromoCode { get; set; }

        [Display(Name = "Total Cost")]
        [Range (0.01, 1000.00, ErrorMessage = "Total Cost must be between £0.01 and £1000")]
        public Decimal TotalCost { get; set; }
        public OrderBEAN() { }
    }
}
