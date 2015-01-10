using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RBusinessLayer;
using RPropertyLayer;
using LSBusinessLayer.BLCommon;

namespace Rupa.MasterEntry
{
    public partial class Supplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSupplier();
            }
        }

        void BindSupplier()
        {
            try
            {
                BLSupplier obj = new BLSupplier();
                PRSupplier objSupplier = new PRSupplier();
                objSupplier.Status = "Display";
                DataTable dt = obj.BLGetSupplier(objSupplier);
                gvSupplier.DataSource = dt;
                gvSupplier.DataBind();
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At BindSupplier :" + ex.Message);
                BLUtility.ErrorLog("Exception At BindSupplier :" + ex.StackTrace);
            }

        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                PRSupplier objSupplier = new PRSupplier();
                objSupplier.SupplierID = 0;
                objSupplier.Name = txtName.Text;
                objSupplier.Address = txtAddress.Text;
                objSupplier.ContactNo = txtMobileNo.Text;
                objSupplier.CreatedBy = Convert.ToInt32(Session["User_ID"]);
                objSupplier.DeleteFlag = 0;
                objSupplier.Status = "Add";
                int rt = new RBusinessLayer.BLSupplier().BLInsertUpdateSupplier(objSupplier);
                BindSupplier();
                //if (rt == 11)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Save');", true);
                //    BindSupplier();
                //}
                //else
                //{
                //    BindSupplier();
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
                lblID.Text = gvSupplier.DataKeys[gvrow.RowIndex].Value.ToString();
                txtEditName.Text = gvrow.Cells[1].Text;
                txtEditAddress.Text = gvrow.Cells[3].Text;
                txtEditMobileNo.Text = gvrow.Cells[2].Text;
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
                PRSupplier objSupplier = new PRSupplier();
                objSupplier.SupplierID = Convert.ToInt32(lblID.Text);
                objSupplier.Name = txtEditName.Text;
                objSupplier.Address = txtEditAddress.Text;
                objSupplier.ContactNo = txtEditMobileNo.Text;
                objSupplier.CreatedBy = Convert.ToInt32(Session["User_ID"]);
                objSupplier.Status = "Update";
                int rt = new RBusinessLayer.BLSupplier().BLInsertUpdateSupplier(objSupplier);
                BindSupplier();
                //if (rt == 88)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Update');", true);
                //    txtEditSupplier.Text = "";
                //    BindSupplier();
                //}
                //else
                //{
                //    BindSupplier();
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Error Update Data');", true);
                //}
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At btnUpdate_Click :" + ex.Message);
                BLUtility.ErrorLog("Exception At btnUpdate_Click :" + ex.StackTrace);
            }
        }

        protected void gvSupplier_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var Id = gvSupplier.DataKeys[e.RowIndex].Value.ToString();
            PRSupplier objSupplier = new PRSupplier();
            objSupplier.SupplierID = Convert.ToInt32(Id);
            objSupplier.Status = "Delete";
            int rt = new RBusinessLayer.BLSupplier().BLInsertUpdateSupplier(objSupplier);
            BindSupplier();
        }
    }
}