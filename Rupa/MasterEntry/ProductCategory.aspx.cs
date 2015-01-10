using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPropertyLayer;
using LSBusinessLayer.BLCommon;
using RBusinessLayer;
using System.Data;

namespace Rupa.MasterEntry
{
    public partial class ProductCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindProductCategory();
            }
        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                PRProduct objProduct = new PRProduct();
                objProduct.CategoryID = 0;
                objProduct.CategoryName = txtProductCategory.Text;
                objProduct.CreatedBy = Convert.ToInt32(Session["User_ID"]);
                objProduct.DeleteFlag = 0;
                objProduct.Status = "Add";
                int rt = new RBusinessLayer.BLProduct().BLInsertUpdateCategory(objProduct);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Save');", true);
                BindProductCategory();
                txtProductCategory.Text = "";
                txtProductCategory.Focus();

                //if (rt == 11)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Save');", true);
                //    BindProductCategory();
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Duplicate Data');", true);
                //}
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At cmdSave_Click :" + ex.Message);
                BLUtility.ErrorLog("Exception At cmdSave_Click :" + ex.StackTrace);
            }
        }

        void BindProductCategory()
        {
            try
            {
                BLProduct obj = new BLProduct();
                PRProduct objProduct = new PRProduct();
                objProduct.Status = "Display";
                DataTable dt = obj.BLGetProductCategory(objProduct);
                gvProductCategory.DataSource = dt;
                gvProductCategory.DataBind();
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At BindProductCategory :" + ex.Message);
                BLUtility.ErrorLog("Exception At BindProductCategory :" + ex.StackTrace);
            }

        }

        protected void imgbtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                lblID.Text = gvProductCategory.DataKeys[gvrow.RowIndex].Value.ToString();
                txtEditProductCategory.Text = gvrow.Cells[1].Text;
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
                objProduct.CategoryID = Convert.ToInt32(lblID.Text);
                objProduct.CategoryName = txtEditProductCategory.Text;
                objProduct.CreatedBy = Convert.ToInt32(Session["User_ID"]);
                objProduct.Status = "Update";
                int rt = new RBusinessLayer.BLProduct().BLInsertUpdateCategory(objProduct);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Update');", true);
                txtEditProductCategory.Text = "";
                BindProductCategory();
                //if (rt == 88)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Update');", true);
                //    txtEditProductCategory.Text = "";
                //    BindProductCategory();
                //}
                //else
                //{
                //    BindProductCategory();
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Error Update Data');", true);
                //}
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At btnUpdate_Click :" + ex.Message);
                BLUtility.ErrorLog("Exception At btnUpdate_Click :" + ex.StackTrace);
            }
        }

        protected void gvProductCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var CategoryId  = gvProductCategory.DataKeys[e.RowIndex].Value.ToString();
            PRProduct objProduct = new PRProduct();
            objProduct.CategoryID = Convert.ToInt32(CategoryId);
            objProduct.Status = "Delete";
            int rt = new RBusinessLayer.BLProduct().BLInsertUpdateCategory(objProduct);
            BindProductCategory();
        }
    }
}