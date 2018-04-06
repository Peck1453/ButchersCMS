using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.BEANS
{
    public class StockTransactionBEAN
    {
        [Display(Name = "Id")]
        public int TransactionId { get; set; }

        [Display(Name = "Product")]
        public int ProductItemId { get; set; }

        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [Display(Name = "Updated By")]
        public string AddedBy { get; set; }

        [Display(Name = "Quantity Before")]
        public int currentStock { get; set; }

        [Display(Name = "Quantity Changed")]
        public int QtyToAdd { get; set; }

        [Display(Name = "Quantity After")]
        public int UpdatedTotal { get; set; }

        [Display(Name = "Date Added")]
        public  DateTime? DateAdded { get; set; }

        public StockTransactionBEAN() { }
    }
}
