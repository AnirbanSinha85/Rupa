using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using RBusinessLayer;
using RPropertyLayer;
using System.Data;
using LSBusinessLayer.BLCommon;

namespace Rupa.MasterEntry
{
    public partial class Customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustomer();
            }
        }

        void BindCustomer()
        {
            try
            {
                BLCustomer obj = new BLCustomer();
                PRCustomer objCustomer = new PRCustomer();
                objCustomer.Status = "Display";
                DataTable dt = obj.BLGetCustomer(objCustomer);
                gvCustomer.DataSource = dt;
                gvCustomer.DataBind();
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At BindCustomer :" + ex.Message);
                BLUtility.ErrorLog("Exception At BindCustomer :" + ex.StackTrace);
            }

        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                PRCustomer objCustomer = new PRCustomer();
                objCustomer.CustomerID = 0;
                objCustomer.Name = txtName.Text;
                objCustomer.Address = txtAddress.Text;
                objCustomer.ContactNo = txtMobileNo.Text;
                objCustomer.CreatedBy = Convert.ToInt32(Session["User_ID"]);
                objCustomer.DeleteFlag = 0;
                objCustomer.Status = "Add";
                int rt = new RBusinessLayer.BLCustomer().BLInsertUpdateCustomer(objCustomer);
                BindCustomer();
                //if (rt == 11)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Save');", true);
                //    BindCustomer();
                //}
                //else
                //{
                //    BindCustomer();
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
                lblID.Text = gvCustomer.DataKeys[gvrow.RowIndex].Value.ToString();
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
                PRCustomer objCustomer = new PRCustomer();
                objCustomer.CustomerID = Convert.ToInt32(lblID.Text);
                objCustomer.Name = txtEditName.Text;
                objCustomer.Address = txtEditAddress.Text;
                objCustomer.ContactNo = txtEditMobileNo.Text;
                objCustomer.CreatedBy = Convert.ToInt32(Session["User_ID"]);
                objCustomer.Status = "Update";
                int rt = new RBusinessLayer.BLCustomer().BLInsertUpdateCustomer(objCustomer);
                BindCustomer();
                //if (rt == 88)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Sucessfully Update');", true);
                //    txtEditCustomer.Text = "";
                //    BindCustomer();
                //}
                //else
                //{
                //    BindCustomer();
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Error Update Data');", true);
                //}
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("Exception At btnUpdate_Click :" + ex.Message);
                BLUtility.ErrorLog("Exception At btnUpdate_Click :" + ex.StackTrace);
            }
        }

        protected void gvCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var Id = gvCustomer.DataKeys[e.RowIndex].Value.ToString();
            PRCustomer objCustomer = new PRCustomer();
            objCustomer.CustomerID = Convert.ToInt32(Id);
            objCustomer.Status = "Delete";
            int rt = new RBusinessLayer.BLCustomer().BLInsertUpdateCustomer(objCustomer);
            BindCustomer();
        }
    }
}