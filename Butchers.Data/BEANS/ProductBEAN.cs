﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.BEANS
{
    public class ProductBEAN
    {
        [Display(Name = "Id")]
        public int ProductId { get; set; }

        [Display(Name = "Meat")]
        public int MeatId { get; set; }

        [Display(Name = "Meat")]
        [Required(ErrorMessage = "Please Select the Meat the product contains")]
        public string Meat { get; set; }
        
        [Display(Name = "Product Name")]
        [StringLength(50, ErrorMessage ="Maximum Length 50 characters")]
        [Required(ErrorMessage = "Please Enter the name of the Product")]
        public string Name { get; set; }

        public ProductBEAN() {}

    }
}
