using System;
using System.Text;
using System.Data;
using RBusinessLayer;
using RPropertyLayer;
using LSBusinessLayer.BLCommon;

namespace Rupa.Report
{
    public partial class PurchaseInvoicePrint : System.Web.UI.Page
    {
        StringBuilder rpt = new StringBuilder();
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                PRPurchaseInvoice objInvoice = new PRPurchaseInvoice();
                objInvoice.PurchaseInvoiceID = Convert.ToInt32(Request.QueryString["pID"]);
                objInvoice.Status = "ByPurchaseInvoiceID";
                objInvoice.FromDate = DateTime.Now;
                objInvoice.ToDate = DateTime.Now;
                dt = new BLPurchaseInvoice().BLGetPurchaseInvoice(objInvoice);

                ShowReport(dt);

                view_Claim_print.Text = rpt.ToString();
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At Page_Load :" + ex.Message);
                BLUtility.ErrorLog("Exception At Page_Load :" + ex.StackTrace);
            }
        }

        private void ShowReport(DataTable dt)
        {
            try
            {
                rpt.Append("<table width='100%' class='gridtable' cellspacing='3' cellpadding='4' >");

                #region Table Master Detail

                rpt.Append("<tr>");
                rpt.Append("<td  colspan='6' >");
                rpt.Append("<table width='100%' class='gridtable' cellspacing='3' cellpadding='4' >");

                rpt.Append("<tr>");
                rpt.AppendFormat("<td align='left'>Tax Invoice No </td>");
                rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["TaxInvoiceNo"]);
                rpt.AppendFormat("<td align='left'>Invoice Date </td>");
                rpt.AppendFormat("<td align='left'>{0}</td>", Convert.ToDateTime(dt.Rows[0]["InvoiceDate"]).ToString("dd/MM/yyyy"));
                rpt.Append("</tr>");

                rpt.Append("<tr>");
                rpt.AppendFormat("<td align='left'>Order NO </td>");
                rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["OrderNo"]);
                rpt.AppendFormat("<td align='left'> Receive Date </td>");
                rpt.AppendFormat("<td align='left'>{0}</td>", Convert.ToDateTime(dt.Rows[0]["ReceiveDate"]).ToString("dd/MM/yyyy"));
                rpt.Append("</tr>");

                rpt.Append("<tr>");
                rpt.AppendFormat("<td align='left'>Transporter </td>");
                rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["TaxInvoiceNo"]);
                rpt.AppendFormat("<td align='left'>  Vat No: </td>");
                rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[0]["VatNo"]);
                rpt.Append("</tr>");


                rpt.Append("</table>");
                rpt.Append("</td>");
                rpt.Append("</tr>");

                #endregion

                #region Table Detail Section



                rpt.Append("<tr>");
                rpt.AppendFormat("<td align='left'>Qty</td>");
                rpt.AppendFormat("<td align='left'>Unit</td>");
                rpt.AppendFormat("<td align='left'>Product Name</td>");
                rpt.AppendFormat("<td align='left'>Size Name</td>");
                rpt.AppendFormat("<td align='right'>Rate</td>");
                rpt.AppendFormat("<td align='right'>Amount</td>");
                rpt.Append("</tr>");

                DateTime Claim_date = DateTime.Now.Date;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rpt.Append("<tr>");

                    rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[i]["Qty"]);
                    rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[i]["Unit"]);

                    rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[i]["ProductName"]);
                    rpt.AppendFormat("<td align='left'>{0}</td>", dt.Rows[i]["SizeName"]);
                    //Claim_date = Convert.ToDateTime(dt.Rows[i]["Claim_Date"]);
                    //rpt.AppendFormat("<td align='left'>{0}</td>", Claim_date.ToString("MM/dd/yyyy"));
                    rpt.AppendFormat("<td align='right'>{0}</td>", dt.Rows[i]["Rate"]);
                    rpt.AppendFormat("<td align='right'>{0}</td>", dt.Rows[i]["Amount"]);

                    rpt.Append("</tr>");
                }

                #endregion

                #region Table Footer Section


                rpt.Append("<tr>");
                rpt.AppendFormat("<td colspan='4' align='left'> </td>");
                rpt.AppendFormat("<td align='left'>Grand Total </td>");
                rpt.AppendFormat("<td align='right'>{0}</td>", dt.Rows[0]["GrandTotal"]);
                rpt.Append("</tr>");

                rpt.Append("<tr>");
                rpt.AppendFormat("<td colspan='4' align='left'> </td>");
                rpt.AppendFormat("<td align='left'>Trade Discount </td>");
                rpt.AppendFormat("<td align='right'>{0}</td>", dt.Rows[0]["TradeDiscount"]);
                rpt.Append("</tr>");


                rpt.Append("<tr>");
                rpt.AppendFormat("<td colspan='4' align='left'> </td>");
                rpt.AppendFormat("<td align='left'>Costcenter Discount </td>");
                rpt.AppendFormat("<td align='right'>{0}</td>", dt.Rows[0]["CostCenterDiscount"]);
                rpt.Append("</tr>");

                rpt.Append("<tr>");
                rpt.AppendFormat("<td colspan='4' align='left'> </td>");
                rpt.AppendFormat("<td align='left'>Quantity Discount </td>");
                rpt.AppendFormat("<td align='right'>{0}</td>", dt.Rows[0]["QuantityDiscount"]);
                rpt.Append("</tr>");

                rpt.Append("<tr>");
                rpt.AppendFormat("<td colspan='4' align='left'> </td>");
                rpt.AppendFormat("<td align='left'> Freight</td>");
                rpt.AppendFormat("<td align='right'>{0}</td>", dt.Rows[0]["Freight"]);
                rpt.Append("</tr>");

                rpt.Append("<tr>");
                rpt.AppendFormat("<td colspan='4' align='left'> </td>");
                rpt.AppendFormat("<td align='left'>Grand Total </td>");
                rpt.AppendFormat("<td align='right'>{0}</td>", dt.Rows[0]["Vat"]);
                rpt.Append("</tr>");

                rpt.Append("<tr>");
                rpt.AppendFormat("<td colspan='4' align='left'> </td>");
                rpt.AppendFormat("<td align='left'>Vat </td>");
                rpt.AppendFormat("<td align='right'>{0}</td>", dt.Rows[0]["Total"]);
                rpt.Append("</tr>");

                rpt.Append("<tr>");
                rpt.AppendFormat("<td colspan='4' align='left'> </td>");
                rpt.AppendFormat("<td align='left'>Total</td>");
                rpt.AppendFormat("<td align='right'>{0}</td>", dt.Rows[0]["VatNo"]);
                rpt.Append("</tr>");

                #endregion

                rpt.Append("</table>");
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At ShowReport :" + ex.Message);
                BLUtility.ErrorLog("Exception At ShowReport :" + ex.StackTrace);
            }
        }
    }
}