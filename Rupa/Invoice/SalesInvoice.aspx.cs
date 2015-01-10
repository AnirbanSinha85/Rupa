using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RBusinessLayer;
using RPropertyLayer;
using System.Data;
using LSBusinessLayer.BLCommon;
using System.IO;

namespace Rupa.Invoice
{
    public partial class SalesInvoice : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        int InvoiceDetailID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustomer();
                BindProduct();
                BindProductSize();
                InvoiceDetailID = 0;
                ViewState["InvoiceDetailID"] = InvoiceDetailID;
                CreateDataTable();
                //BindPurchaseInvoice(dt);
                ddlClient.Items.Insert(0, new ListItem("Select", "0"));
                ddlProduct.Items.Insert(0, new ListItem("Select", string.Empty));
            }
            txtGrandTotal.Enabled = false;
            txtTotal.Enabled = false;
            txtDueAmount.Enabled = false;
        }

        void BindCustomer()
        {
            try
            {
                BLCustomer obj = new BLCustomer();
                PRCustomer objCustomer = new PRCustomer();
                objCustomer.Status = "Display";
                DataTable dt = obj.BLGetCustomer(objCustomer);

                ddlClient.DataSource = dt;
                ddlClient.DataTextField = "Name";
                ddlClient.DataValueField = "CustomerID";
                ddlClient.DataBind();
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At BindCustomer :" + ex.Message);
                BLUtility.ErrorLog("Exception At BindCustomer :" + ex.StackTrace);
            }

        }

        void BindProduct()
        {
            try
            {
                BLProduct obj = new BLProduct();
                PRProduct objProduct = new PRProduct();
                objProduct.Status = "Display";
                DataTable dt = obj.BLGetProduct(objProduct);
                ddlProduct.DataSource = dt;
                ddlProduct.DataTextField = "ProductName";
                ddlProduct.DataValueField = "ProductID";
                ddlProduct.DataBind();
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At BindProduct :" + ex.Message);
                BLUtility.ErrorLog("Exception At BindProduct :" + ex.StackTrace);
            }

        }

        void BindProductSize()
        {
            try
            {
                BLProduct obj = new BLProduct();
                PRProduct objProduct = new PRProduct();
                objProduct.Status = "Display";
                DataTable dt = obj.BLGetProductSize(objProduct);
                ddlSize.DataSource = dt;
                ddlSize.DataTextField = "SizeName";
                ddlSize.DataValueField = "SizeID";
                ddlSize.DataBind();
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At BindProductSize :" + ex.Message);
                BLUtility.ErrorLog("Exception At BindProductSize :" + ex.StackTrace);
            }

        }

        void CreateDataTable()
        {

            dt.Columns.Add("SalesInvoiceID", typeof(Int32));
            dt.Columns.Add("Qty", typeof(Int32));
            dt.Columns.Add("Unit", typeof(Int32));
            dt.Columns.Add("ProductID", typeof(Int32));
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("SizeID", typeof(Int32));
            dt.Columns.Add("SizeName", typeof(string));
            dt.Columns.Add("Rate", typeof(decimal));
            dt.Columns.Add("Amount", typeof(string));

            ViewState.Add("InvoiceDetail", dt);

        }

        protected void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                InvoiceDetailID = (Int32)ViewState["InvoiceDetailID"];
                InvoiceDetailID = InvoiceDetailID + 1;
                ViewState["InvoiceDetailID"] = InvoiceDetailID;

                DataRow row;
                dt = (DataTable)ViewState["InvoiceDetail"];
                row = dt.NewRow();
                row["SalesInvoiceID"] = InvoiceDetailID;
                row["Qty"] = Convert.ToInt32(txtQty.Text);
                row["Unit"] = Convert.ToInt32(ddlUnit.SelectedValue);
                row["ProductID"] = Convert.ToInt32(ddlProduct.SelectedValue);
                row["ProductName"] = Convert.ToString(ddlProduct.SelectedItem);
                row["SizeID"] = Convert.ToInt32(ddlSize.SelectedValue);
                row["SizeName"] = Convert.ToString(ddlSize.SelectedItem);
                row["Rate"] = Convert.ToDecimal(txtRate.Text);
                row["Amount"] = Convert.ToDecimal(txtRate.Text) * Convert.ToInt32(txtQty.Text);
                dt.Rows.Add(row);

                ViewState.Add("InvoiceDetail", dt);

                BindPurchaseInvoice(dt);
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At cmdAdd_Click :" + ex.Message);
                BLUtility.ErrorLog("Exception At cmdAdd_Click :" + ex.StackTrace);
            }
        }

        void BindPurchaseInvoice(DataTable dt)
        {
            decimal grandTotal = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    grandTotal = grandTotal + Convert.ToDecimal(dt.Rows[i]["Amount"]);
                }
                txtGrandTotal.Text = grandTotal.ToString();
                gvPurcase_Invoice.DataSource = dt;
                gvPurcase_Invoice.DataBind();
            }
        }

        protected void gvPurcase_Invoice_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                dt = (DataTable)ViewState["InvoiceDetail"];
                var InvoiceDetail = ConvertDatatableToXML(dt);

                var total = Convert.ToDecimal(txtGrandTotal.Text) - Convert.ToDecimal(txtDiscount.Text);
                txtTotal.Text = total.ToString();
                txtDueAmount.Text = Convert.ToString(Convert.ToDecimal(total) - Convert.ToDecimal(txtPaidAmount.Text));

                //var totalDisc = Convert.ToDecimal(txtTradeDiscount.Text) + Convert.ToDecimal(txtCostcenterDiscount.Text) + Convert.ToDecimal(txtQuantityDiscount.Text) + Convert.ToDecimal(txtFreight.Text);
                //var total = Convert.ToDecimal(txtGrandTotal.Text) - totalDisc + Convert.ToDecimal(txtVat.Text);
                //txtTotal.Text = total.ToString();
                //txtTotal.Enabled = false;

                PRSalesInvoice objInvoice = new PRSalesInvoice();
                objInvoice.CustomerID = Convert.ToInt32(ddlClient.SelectedValue);
                objInvoice.BillDate = Convert.ToDateTime(txtBillDate.Text);
                objInvoice.GrandTotal = Convert.ToDecimal(txtGrandTotal.Text);
                objInvoice.Discount = Convert.ToDecimal(txtDiscount.Text);
                objInvoice.Total = Convert.ToDecimal(total);
                objInvoice.PaidAmount = Convert.ToDecimal(txtPaidAmount.Text);
                objInvoice.DueAmount = Convert.ToDecimal(txtDueAmount.Text);
                objInvoice.InvoiceDetail = InvoiceDetail;


                BLSalesInvoice obj = new BLSalesInvoice();
                obj.BLInsertUpdateSalesInvoice(objInvoice);
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At cmdSave_Click :" + ex.Message);
                BLUtility.ErrorLog("Exception At cmdSave_Click :" + ex.StackTrace);
            }
        }

        public string ConvertDatatableToXML(DataTable dt)
        {
            string xmlstr = string.Empty;
            if (dt.Rows.Count > 0)
            {
                MemoryStream str = new MemoryStream();
                dt.WriteXml(str, true);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(str);
                xmlstr = sr.ReadToEnd();
            }
            return (xmlstr);
        }

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BLCustomer obj = new BLCustomer();
                PRCustomer objCustomer = new PRCustomer();
                objCustomer.CustomerID = Convert.ToInt32(ddlClient.SelectedValue);
                objCustomer.Status = "DisplayByID";

                DataTable dt = obj.BLGetCustomer(objCustomer);
                if (dt.Rows.Count > 0)
                {
                    lblAddress.Text = dt.Rows[0]["Address"].ToString();
                    lblPhNo.Text = dt.Rows[0]["ContactNo"].ToString();
                }

            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At BindCustomer :" + ex.Message);
                BLUtility.ErrorLog("Exception At BindCustomer :" + ex.StackTrace);
            }
        }
    }
}