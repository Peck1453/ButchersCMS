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
    
    public partial class ProductItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Cost { get; set; }
        public bool PerUnit { get; set; }
        public bool Discontinued { get; set; }
    }
}
