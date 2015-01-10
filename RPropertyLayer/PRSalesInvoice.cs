using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPropertyLayer
{
   public class PRSalesInvoice
    {
        public int SalesInvoiceID { get; set; }
        public int CustomerID { get; set; }
        public DateTime BillDate { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }

        public int SalesInvoiceDetailID { get; set; }
        
        public string InvoiceDetail { get; set; }
        public int CreatedBy { get; set; }
        public int DeleteFlag { get; set; }
        public string Status { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
