using LSBusinessLayer.BLCommon;
using RBusinessLayer;
using RPropertyLayer;
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;

namespace Rupa.Invoice
{
    public partial class PurchaseInvoice : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        int InvoiceDetailID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProduct();
                BindProductSize();
                InvoiceDetailID = 0;
                ViewState["InvoiceDetailID"] = InvoiceDetailID;
                CreateDataTable();
                BindPurchaseInvoice(dt);
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

            dt.Columns.Add("PurchaseInvoiceID", typeof(Int32));
            dt.Columns.Add("TaxInvoiceNo", typeof(string));
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
                row["PurchaseInvoiceID"] = InvoiceDetailID;
                row["TaxInvoiceNo"] = txtInvoiceNo.Text;
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

            #region MyRegion
            //PRPurchaseInvoice objInvoice = new PRPurchaseInvoice();
            //objInvoice.TaxInvoiceNo = txtInvoiceNo.Text;
            //objInvoice.Qty = Convert.ToInt32(txtQty.Text);
            //objInvoice.Unit = Convert.ToInt32(ddlUnit.SelectedValue);
            //objInvoice.ProductID = Convert.ToInt32(ddlProduct.SelectedValue);
            //objInvoice.SizeID = Convert.ToInt32(ddlSize.SelectedValue);
            //objInvoice.Rate = Convert.ToDecimal(txtRate.Text);
            //objInvoice.InvoiceDate =DateTime.Now;
            //objInvoice.ReceiveDate = DateTime.Now;
            //objInvoice.Status = "Add";
            //BLPurchaseInvoice obj = new BLPurchaseInvoice();
            //obj.BLInsertUpdatePurchaseInvoice(objInvoice);
            //BindPurchaseInvoice();
            #endregion

        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                dt = (DataTable)ViewState["InvoiceDetail"];
                var InvoiceDetail = ConvertDatatableToXML(dt);


                var totalDisc = Convert.ToDecimal(txtTradeDiscount.Text) + Convert.ToDecimal(txtCostcenterDiscount.Text) + Convert.ToDecimal(txtQuantityDiscount.Text) + Convert.ToDecimal(txtFreight.Text);
                var total = Convert.ToDecimal(txtGrandTotal.Text) - totalDisc + Convert.ToDecimal(txtVat.Text);
                txtTotal.Text = total.ToString();
                txtTotal.Enabled = false;

                PRPurchaseInvoice objInvoice = new PRPurchaseInvoice();
                objInvoice.TaxInvoiceNo = txtInvoiceNo.Text;
                objInvoice.OrderNo = txtOrderNo.Text;
                objInvoice.VatNo = txtVatNo.Text;
                objInvoice.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
                objInvoice.ReceiveDate = Convert.ToDateTime(txtReceiveDate.Text);
                objInvoice.GrandTotal = Convert.ToDecimal(txtGrandTotal.Text);
                objInvoice.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
                objInvoice.CostCenterDiscount = Convert.ToDecimal(txtCostcenterDiscount.Text);
                objInvoice.QuantityDiscount = Convert.ToDecimal(txtQuantityDiscount.Text);
                objInvoice.Freight = Convert.ToDecimal(txtFreight.Text);
                objInvoice.Vat = Convert.ToDecimal(txtVat.Text);
                objInvoice.Total = Convert.ToDecimal(total);
                objInvoice.InvoiceDetail = InvoiceDetail;
                objInvoice.Status = "AddMaster";

                BLPurchaseInvoice obj = new BLPurchaseInvoice();
                obj.BLInsertUpdatePurchaseInvoice(objInvoice);
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At cmdSave_Click :" + ex.Message);
                BLUtility.ErrorLog("Exception At cmdSave_Click :" + ex.StackTrace);
            }
            #region MyRegion


            //var totalDisc = Convert.ToDecimal(txtTradeDiscount.Text) + Convert.ToDecimal(txtCostcenterDiscount.Text) + Convert.ToDecimal(txtQuantityDiscount.Text) + Convert.ToDecimal(txtFreight.Text);
            //var total = Convert.ToDecimal(txtGrandTotal.Text) - totalDisc + Convert.ToDecimal(txtVat.Text);
            //txtTotal.Text = total.ToString();
            //txtTotal.Enabled = false;

            //PRPurchaseInvoice objInvoice = new PRPurchaseInvoice();
            //objInvoice.TaxInvoiceNo = txtInvoiceNo.Text;
            //objInvoice.OrderNo = txtOrderNo.Text;
            //objInvoice.VatNo = txtVatNo.Text;
            //objInvoice.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
            //objInvoice.ReceiveDate = Convert.ToDateTime(txtReceiveDate.Text);
            //objInvoice.GrandTotal = Convert.ToDecimal(txtGrandTotal.Text);
            //objInvoice.TradeDiscount = Convert.ToDecimal(txtTradeDiscount.Text);
            //objInvoice.CostCenterDiscount = Convert.ToDecimal(txtCostcenterDiscount.Text);
            //objInvoice.QuantityDiscount = Convert.ToDecimal(txtQuantityDiscount.Text);
            //objInvoice.Freight = Convert.ToDecimal(txtFreight.Text);
            //objInvoice.Vat = Convert.ToDecimal(txtVat.Text);
            //objInvoice.Total = Convert.ToDecimal(total);
            //objInvoice.Status = "AddMaster";

            //BLPurchaseInvoice obj = new BLPurchaseInvoice();
            //obj.BLInsertUpdatePurchaseInvoice(objInvoice);
            //BindPurchaseInvoice();

            #endregion

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
            //else
            //{
            //    dt.Rows.Add(dt.NewRow());
            //    gvPurcase_Invoice.DataSource = dt;
            //    gvPurcase_Invoice.DataBind();
            //    int columncount = gvPurcase_Invoice.Rows[0].Cells.Count;
            //    gvPurcase_Invoice.Rows[0].Cells.Clear();
            //    gvPurcase_Invoice.Rows[0].Cells.Add(new TableCell());
            //    gvPurcase_Invoice.Rows[0].Cells[0].ColumnSpan = columncount;
            //    gvPurcase_Invoice.Rows[0].Cells[0].Text = " ";
            //}
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

        protected void gvPurcase_Invoice_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int PurchaseInvoiceID = Convert.ToInt32(gvPurcase_Invoice.DataKeys[e.RowIndex].Values["PurchaseInvoiceID"].ToString());
            dt = (DataTable)ViewState["InvoiceDetail"];
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                DataRow[] matches = dt.Select("PurchaseInvoiceID='" + PurchaseInvoiceID + "'");
                foreach (DataRow row in matches)
                {
                    dt.Rows.Remove(row);
                }
            }
            BindPurchaseInvoice(dt);
            ViewState.Add("Company", dt);
        }

    }
}