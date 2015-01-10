using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPropertyLayer;
using RBusinessLayer;
using System.Data;
using LSBusinessLayer.BLCommon;

namespace Rupa.Report
{
    public partial class PurchaseInvoiceSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindPurchaseInvoice();
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At cmdSearch_Click :" + ex.Message);
                BLUtility.ErrorLog("Exception At cmdSearch_Click :" + ex.StackTrace);
            }
        }

        void BindPurchaseInvoice()
        {
            try
            {
                PRPurchaseInvoice objInvoice = new PRPurchaseInvoice();

                objInvoice.FromDate = Convert.ToDateTime(txtFromDate.Text);
                objInvoice.ToDate = Convert.ToDateTime(txtToDate.Text);
                objInvoice.Status = "ByDate";

                DataTable dt = new BLPurchaseInvoice().BLGetPurchaseInvoice(objInvoice);

                if (dt.Rows.Count > 0)
                {
                    gvPurchaseInvoice.DataSource = dt;
                    gvPurchaseInvoice.DataBind();
                }
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At BindPurchaseInvoice :" + ex.Message);
                BLUtility.ErrorLog("Exception At BindPurchaseInvoice :" + ex.StackTrace);
            }
        }

        protected void gvPurchaseInvoice_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvPurchaseInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPurchaseInvoice.PageIndex = e.NewPageIndex;
            BindPurchaseInvoice();
        }
    }
}