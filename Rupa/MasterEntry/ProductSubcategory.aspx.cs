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
    public partial class ProductSubcategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindProductSubCategory();
            }
        }

        protected void gvSubCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                PRProduct objProduct = new PRProduct();
                objProduct.SubCategoryID = Convert.ToInt32(lblID.Text);
                objProduct.SubCategoryName = txtEditProductSubCategory.Text;
                objProduct.CreatedBy = Convert.ToInt32(Session["User_ID"]);
                objProduct.Status = "Update";
                int rt = new RBusinessLayer.BLProduct().BLInsertUpdateSubCategory(objProduct);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Update');", true);
                txtEditProductSubCategory.Text = ""; 
                txtSubCategory.Text = "";
                txtSubCategory.Focus();
                BindProductSubCategory();

                //if (rt == 88)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Update');", true);
                //    txtEditProductSubCategory.Text = "";
                //    BindProductSubCategory();
                //}
                //else
                //{
                //    BindProductSubCategory();
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Error Update Data');", true);
                //}
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At btnUpdate_Click :" + ex.Message);
                BLUtility.ErrorLog("Exception At btnUpdate_Click :" + ex.StackTrace);
            }
        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                PRProduct objProduct = new PRProduct();
                objProduct.SubCategoryID = 0;
                objProduct.SubCategoryName = txtSubCategory.Text;
                objProduct.CreatedBy = Convert.ToInt32(Session["User_ID"]);
                objProduct.DeleteFlag = 0;
                objProduct.Status = "Add";
                int rt = new RBusinessLayer.BLProduct().BLInsertUpdateSubCategory(objProduct);
                BindProductSubCategory();
                //if (rt == 11)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Save');", true);
                //    BindProductSubCategory();
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

        protected void imgbtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                lblID.Text = gvSubCategory.DataKeys[gvrow.RowIndex].Value.ToString();
                txtEditProductSubCategory.Text = gvrow.Cells[1].Text;
                this.ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At imgbtnEdit_Click :" + ex.Message);
                BLUtility.ErrorLog("Exception At imgbtnEdit_Click :" + ex.StackTrace);
            }
        }

        void BindProductSubCategory()
        {
            try
            {
                BLProduct obj = new BLProduct();
                PRProduct objProduct = new PRProduct();
                objProduct.Status = "Display";
                DataTable dt = obj.BLGetProductSubCategory(objProduct);
                gvSubCategory.DataSource = dt;
                gvSubCategory.DataBind();
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At BindProductCategory :" + ex.Message);
                BLUtility.ErrorLog("Exception At BindProductCategory :" + ex.StackTrace);
            }

        }

        protected void gvSubCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSubCategory.PageIndex = e.NewPageIndex;
            BindProductSubCategory();
        }

        
    }
}