using System;

namespace RPropertyLayer
{
    public class PRPurchaseInvoice
    {
        public int PurchaseInvoiceID { get; set; }
        public string TaxInvoiceNo { get; set; }
        public string OrderNo { get; set; }
        public string VatNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime ReceiveDate { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal TradeDiscount { get; set; }
        public decimal CostCenterDiscount { get; set; }
        public decimal QuantityDiscount { get; set; }
        public decimal Freight { get; set; }
        public decimal Vat { get; set; }
        public decimal Total { get; set; }

        public int PurchaseInvoiceDetailID { get; set; }
        public int Qty { get; set; }
        public int Unit { get; set; }
        public int ProductID { get; set; }
        public int SizeID { get; set; }
        public decimal Rate { get; set; }

        public string InvoiceDetail { get; set; }

        public int CreatedBy { get; set; }
        public int DeleteFlag { get; set; }
        public string Status { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
