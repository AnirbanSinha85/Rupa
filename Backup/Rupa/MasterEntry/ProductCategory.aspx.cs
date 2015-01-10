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

        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                PRProduct objProduct = new PRProduct();
                objProduct.CategoryID = 0;
                objProduct.CategoryName = txtBrandName.Text;
                objProduct.CreatedBy = Convert.ToInt32(Session["User_ID"]);
                objProduct.DeleteFlag = 0;
                int rt = new RBusinessLayer.BLProduct().BLInsertUpdateCategory(objProduct);
                if (rt == 11)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Save');", true);
                    BindProductCategory();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Duplicate Data');", true);
                }
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
                //DataTable dt = obj.BLGetBrand();
                //gvBrand.DataSource = dt;
                //gvBrand.DataBind();
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
                lblID.Text = gvBrand.DataKeys[gvrow.RowIndex].Value.ToString();
                txtName.Text = gvrow.Cells[1].Text;
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
                objProduct.CategoryName = txtName.Text;
                objProduct.CreatedBy = Convert.ToInt32(Session["User_ID"]);
                int rt = new RBusinessLayer.BLProduct().BLInsertUpdateCategory(objProduct);
                if (rt == 88)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Update');", true);
                    txtBrandName.Text = "";
                    BindProductCategory();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Error Update Data');", true);
                }
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At btnUpdate_Click :" + ex.Message);
                BLUtility.ErrorLog("Exception At btnUpdate_Click :" + ex.StackTrace);
            }
        }
    }
}