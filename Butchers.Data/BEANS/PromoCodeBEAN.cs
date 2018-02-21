using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.BEANS
{
    public class PromoCodeBEAN
    {
        [Display(Name = "Promo Code")]
        public string Code { get; set; }

        [Display(Name = "Discount")]
        public int Discount { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Expiry Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ValidUntil { get; set; }
    }
}
