using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LSBusinessLayer.BLCommon;
using RPropertyLayer;
using RBusinessLayer;
using System.Data;

namespace Rupa.Report
{
    public partial class SalesInvoiceSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindSalesInvoice();
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At cmdSearch_Click :" + ex.Message);
                BLUtility.ErrorLog("Exception At cmdSearch_Click :" + ex.StackTrace);
            }
        }

        void BindSalesInvoice()
        {
            try
            {
                PRSalesInvoice objInvoice = new PRSalesInvoice();

                objInvoice.FromDate = Convert.ToDateTime(txtFromDate.Text);
                objInvoice.ToDate = Convert.ToDateTime(txtToDate.Text);
                objInvoice.Status = "ByDate";

                DataTable dt = new BLSalesInvoice().BLGetSalesInvoice(objInvoice);

                if (dt.Rows.Count > 0)
                {
                    gvSalesInvoice.DataSource = dt;
                    gvSalesInvoice.DataBind();
                }
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At BindSalesInvoice :" + ex.Message);
                BLUtility.ErrorLog("Exception At BindSalesInvoice :" + ex.StackTrace);
            }
        }

        protected void gvSalesInvoice_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvSalesInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSalesInvoice.PageIndex = e.NewPageIndex;
            BindSalesInvoice();
        }
    }
}