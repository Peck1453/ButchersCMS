//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Butchers.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int OrderNo { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string CustomerNo { get; set; }
        public string PromoCode { get; set; }
        public decimal TotalCost { get; set; }
        public int CartId { get; set; }
        public decimal TotalCostAfterDiscount { get; set; }
    }
}
