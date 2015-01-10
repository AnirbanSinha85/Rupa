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
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProduct();
                BindProductCategory();
                BindProductSubCategory();
                ddlCategory.Items.Insert(0, new ListItem("Select", string.Empty));
                ddlSubCategory.Items.Insert(0, new ListItem("Select", string.Empty));
            }
        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                PRProduct objProduct = new PRProduct();
                objProduct.ProductID = 0;
                objProduct.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                objProduct.SubCategoryID = Convert.ToInt32(ddlSubCategory.SelectedValue);
                objProduct.ProductName = txtProduct.Text;
                objProduct.CreatedBy = Convert.ToInt32(Session["User_ID"]);
                objProduct.DeleteFlag = 0;
                objProduct.QtyInBox = Convert.ToInt32(txtQtyInBox.Text);
                objProduct.AvailableQty = Convert.ToInt32(txtAvailableQty.Text);
                objProduct.Status = "Add";
                int rt = new RBusinessLayer.BLProduct().BLInsertUpdateProduct(objProduct);
                BindProduct();
                //if (rt == 11)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Save');", true);
                //    BindProduct();
                //}
                //else
                //{
                //    BindProduct();
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Duplicate Data');", true);
                //}
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At cmdSave_Click :" + ex.Message);
                BLUtility.ErrorLog("Exception At cmdSave_Click :" + ex.StackTrace);
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
                gvProduct.DataSource = dt;
                gvProduct.DataBind();
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At BindProduct :" + ex.Message);
                BLUtility.ErrorLog("Exception At BindProduct :" + ex.StackTrace);
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
                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();

                ddlEditCategory.DataSource = dt;
                ddlEditCategory.DataTextField = "CategoryName";
                ddlEditCategory.DataValueField = "CategoryID";
                ddlEditCategory.DataBind();
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At BindProductCategory :" + ex.Message);
                BLUtility.ErrorLog("Exception At BindProductCategory :" + ex.StackTrace);
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
                ddlSubCategory.DataSource = dt;
                ddlSubCategory.DataTextField = "SubCategoryName";
                ddlSubCategory.DataValueField = "SubCategoryID";
                ddlSubCategory.DataBind();

                ddlEditSubCategory.DataSource = dt;
                ddlEditSubCategory.DataTextField = "SubCategoryName";
                ddlEditSubCategory.DataValueField = "SubCategoryID";
                ddlEditSubCategory.DataBind();
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
                lblID.Text = gvProduct.DataKeys[gvrow.RowIndex].Value.ToString();
                ddlEditSubCategory.SelectedIndex = ddlEditSubCategory.Items.IndexOf(ddlEditSubCategory.Items.FindByText(gvrow.Cells[1].Text.ToString()));
                ddlEditCategory.SelectedIndex = ddlEditCategory.Items.IndexOf(ddlEditCategory.Items.FindByText(gvrow.Cells[2].Text.ToString()));
                txtEditProduct.Text = gvrow.Cells[3].Text;
                txtEditQtyInBox.Text = gvrow.Cells[4].Text;
                txtEditAvailableQty.Text = gvrow.Cells[5].Text;

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
                objProduct.ProductID = Convert.ToInt32(lblID.Text);
                objProduct.CategoryID = Convert.ToInt32(ddlEditCategory.SelectedValue);
                objProduct.SubCategoryID = Convert.ToInt32(ddlEditSubCategory.SelectedValue);
                objProduct.ProductName = txtEditProduct.Text;
                objProduct.CreatedBy = Convert.ToInt32(Session["User_ID"]);

                objProduct.QtyInBox = Convert.ToInt32(txtEditQtyInBox.Text);
                objProduct.AvailableQty = Convert.ToInt32(txtEditAvailableQty.Text);
                objProduct.Status = "Update";

                int rt = new RBusinessLayer.BLProduct().BLInsertUpdateProduct(objProduct);
                BindProduct();
                //if (rt == 88)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Update');", true);
                //    txtEditProduct.Text = "";
                //    BindProduct();
                //}
                //else
                //{
                //    BindProduct();
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Error Update Data');", true);
                //}
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At btnUpdate_Click :" + ex.Message);
                BLUtility.ErrorLog("Exception At btnUpdate_Click :" + ex.StackTrace);
            }
        }

        protected void gvProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var Id = gvProduct.DataKeys[e.RowIndex].Value.ToString();
            PRProduct objProduct = new PRProduct();
            objProduct.ProductID = Convert.ToInt32(Id);
            objProduct.Status = "Delete";
            int rt = new RBusinessLayer.BLProduct().BLInsertUpdateProduct(objProduct);
            BindProduct();
        }

        protected void gvProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProduct.PageIndex = e.NewPageIndex;
            BindProduct();
        }
    }
}