using LSBusinessLayer.BLCommon;
using RBusinessLayer;
using RPropertyLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rupa.MasterEntry
{
    public partial class ProductSize : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductSize();
            }
        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                PRProduct objProduct = new PRProduct();
                objProduct.SizeID = 0;
                objProduct.SizeName = txtProductSize.Text;
                objProduct.CreatedBy = Convert.ToInt32(Session["User_ID"]);
                objProduct.DeleteFlag = 0;
                objProduct.Status = "Add";
                int rt = new RBusinessLayer.BLProduct().BLInsertUpdateSize(objProduct);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Save');", true);
                BindProductSize();
                txtProductSize.Text="";
                txtProductSize.Focus();


                //if (rt == 11)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Save');", true);
                //    BindProductSize();
                //}
                //else
                //{
                //    BindProductSize();
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Duplicate Data');", true);
                //}
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At cmdSave_Click :" + ex.Message);
                BLUtility.ErrorLog("Exception At cmdSave_Click :" + ex.StackTrace);
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
                gvProductSize.DataSource = dt;
                gvProductSize.DataBind();
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At BindProductSize :" + ex.Message);
                BLUtility.ErrorLog("Exception At BindProductSize :" + ex.StackTrace);
            }

        }

        protected void imgbtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                lblID.Text = gvProductSize.DataKeys[gvrow.RowIndex].Value.ToString();
                txtEditProductSize.Text = gvrow.Cells[1].Text;
                this.ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At imgbtnEdit_Click :" + ex.Message);
                BLUtility.ErrorLog("Exception At imgbtnEdit_Click :" + ex.StackTrace);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                PRProduct objProduct = new PRProduct();
                objProduct.SizeID = Convert.ToInt32(lblID.Text);
                objProduct.SizeName = txtEditProductSize.Text;
                objProduct.CreatedBy = Convert.ToInt32(Session["User_ID"]);
                objProduct.Status = "Update";
                int rt = new RBusinessLayer.BLProduct().BLInsertUpdateSize(objProduct);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Update');", true);
                txtEditProductSize.Text = "";
                BindProductSize();
                //if (rt == 88)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Update');", true);
                //    txtEditProductSize.Text = "";
                //    BindProductSize();
                //}
                //else
                //{
                //    BindProductSize();
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Error Update Data');", true);
                //}
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At btnUpdate_Click :" + ex.Message);
                BLUtility.ErrorLog("Exception At btnUpdate_Click :" + ex.StackTrace);
            }
        }

        protected void gvProductSize_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var SizeId = gvProductSize.DataKeys[e.RowIndex].Value.ToString();
            PRProduct objProduct = new PRProduct();
            objProduct.SizeID = Convert.ToInt32(SizeId);
            objProduct.Status = "Delete";
            int rt = new RBusinessLayer.BLProduct().BLInsertUpdateSize(objProduct);
            BindProductSize();
        }
    }
}