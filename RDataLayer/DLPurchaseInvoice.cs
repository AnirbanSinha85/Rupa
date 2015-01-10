using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using LSDataLayer.DLCommon;
using RPropertyLayer;

namespace RDataLayer
{
    public class DLPurchaseInvoice
    {
        public DataTable DLGetPurchaseInvoice(PRPurchaseInvoice objInvoice)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@PurchaseInvoiceID", objInvoice.PurchaseInvoiceID);
                ht.Add("@Status", objInvoice.Status);
                ht.Add("@FromDate", objInvoice.FromDate);
                ht.Add("@ToDate", objInvoice.ToDate);
                dt = DLDBAccess.GetDataTable(DLStoredProcedure.GetPurchaseInvoice, ht);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public int DLInsertUpdatePurchaseInvoice(PRPurchaseInvoice objInvoice)
        {
            int rt = 0;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@TaxInvoiceNo", objInvoice.TaxInvoiceNo);
               // ht.Add("@Qty", objInvoice.Qty);
               // ht.Add("@Unit", objInvoice.Unit);
                //ht.Add("@ProductID", objInvoice.ProductID);
               // ht.Add("@SizeID", objInvoice.SizeID);
               // ht.Add("@Rate", objInvoice.Rate);
                ht.Add("@CreatedBy", objInvoice.CreatedBy);
                ht.Add("@Status", objInvoice.Status);

                ht.Add("@OrderNo", objInvoice.OrderNo);
                ht.Add("@VatNo", objInvoice.VatNo);
                ht.Add("@InvoiceDate", objInvoice.InvoiceDate);
                ht.Add("@ReceiveDate", objInvoice.ReceiveDate);
                ht.Add("@GrandTotal", objInvoice.GrandTotal);
                ht.Add("@TradeDiscount", objInvoice.TradeDiscount);
                ht.Add("@CostCenterDiscount", objInvoice.CostCenterDiscount);
                ht.Add("@QuantityDiscount", objInvoice.QuantityDiscount);
                ht.Add("@Freight", objInvoice.Freight);
                ht.Add("@Vat", objInvoice.Vat);
                ht.Add("@Total", objInvoice.Total);

                ht.Add("@InvoiceDetail", objInvoice.InvoiceDetail);
                //rt = DLDBAccess.ExecuteNonQuerySQL(DLStoredProcedure.InsertUpdatePurchaseInvoice, ht);

                rt = DLDBAccess.ExecuteNonQuerySQL(DLStoredProcedure.SavePurchaseInvoice, ht);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rt;
        }
    }
}
