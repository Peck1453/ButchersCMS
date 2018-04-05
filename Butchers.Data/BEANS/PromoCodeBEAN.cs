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
        [Required (ErrorMessage = "Please provide a promotional code to apply a discount to")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed")]
        public string Code { get; set; }

        [Display(Name = "Discount")]
        [Required (ErrorMessage = "Please provide the percentage discount this Promotional code will apply")]
        [Range (0.1,100.00, ErrorMessage = "Discount needs to be between 0.1% and 100%")]
        public int Discount { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Expiry Date")]
        [Required (ErrorMessage = "Please enter a date the promotional code will expire")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ValidUntil { get; set; }
    }
}
