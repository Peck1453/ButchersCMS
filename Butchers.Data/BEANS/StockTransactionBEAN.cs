using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.BEANS
{
    public class StockTransactionBEAN
    {
        public int TransactionId { get; set; }
        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string AddedBy { get; set; }
        public int currentStock { get; set; }
        public int QtyToAdd { get; set; }
        public int UpdatedTotal { get; set; }
        public  DateTime? DateAdded { get; set; }
        public StockTransactionBEAN() { }
    }
}
