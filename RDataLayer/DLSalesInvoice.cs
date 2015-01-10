using System;
using RPropertyLayer;
using System.Collections;
using LSDataLayer.DLCommon;
using System.Data;

namespace RDataLayer
{
    public class DLSalesInvoice
    {
        public int DLInsertUpdateSalesInvoice(PRSalesInvoice objInvoice)
        {
            int rt = 0;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@CustomerID", objInvoice.CustomerID);
                ht.Add("@BillDate", objInvoice.BillDate);
                ht.Add("@GrandTotal", objInvoice.GrandTotal);
                ht.Add("@Discount", objInvoice.Discount);
                ht.Add("@Total", objInvoice.Total);
                ht.Add("@PaidAmount", objInvoice.PaidAmount);
                ht.Add("@DueAmount", objInvoice.DueAmount);
                ht.Add("@CreatedBy", objInvoice.CreatedBy);
                ht.Add("@InvoiceDetail", objInvoice.InvoiceDetail);
                rt = DLDBAccess.ExecuteNonQuerySQL(DLStoredProcedure.SaveSalesInvoice, ht);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rt;
        }

        public DataTable DLGetSalesInvoice(PRSalesInvoice objInvoice)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@SalesInvoiceMasterID", objInvoice.SalesInvoiceID);
                ht.Add("@Status", objInvoice.Status);
                ht.Add("@FromDate", objInvoice.FromDate);
                ht.Add("@ToDate", objInvoice.ToDate);
                dt = DLDBAccess.GetDataTable(DLStoredProcedure.GetSalesInvoice, ht);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
