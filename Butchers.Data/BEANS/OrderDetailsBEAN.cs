using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.BEANS
{
    public class OrderDetailsBEAN
    {
        [Display(Name = "Id")]
        public int OrderDetailsId { get; set; }

        [Display(Name = "Order No.")]
        public int OrderNo { get; set; }

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

        [Display(Name = "Collected?")]
        public bool Collected { get; set; }

        public OrderDetailsBEAN() { }
    }
}
