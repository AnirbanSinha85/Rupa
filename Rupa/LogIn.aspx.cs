using System;
using System.Web.UI;
using System.Data;
using RBusinessLayer;
using RPropertyLayer;
using LSBusinessLayer.BLCommon;

namespace Rupa
{
    public partial class LogIn : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Write(Server.MapPath("/Log"));
            }
            catch (Exception ex)
            {
            }

        }

        protected void cmdLogIn_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                PRLogIn objLogIn = new PRLogIn();
                objLogIn.Password = txtPassword.Text;
                objLogIn.UserName = txtUserName.Text;
                DataTable dt = new BLLogIn().BLCheckLogIn(objLogIn);
                if (dt.Rows.Count > 0)
                {
                    Session["User_Id"] = dt.Rows[0]["UserID"];
                    Session["User_Name"] = dt.Rows[0]["UserName"];
                    Session["First_Name"] = dt.Rows[0]["FirstName"];
                    Session["AcessLevel"] = dt.Rows[0]["AcessLevel"];
                    Response.Redirect("~/MasterEntry/ProductCategory.aspx",false);
                }
                else
                {
                    // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(In valid);", true);

                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + "----" + ex.StackTrace;
                //BLUtility.ErrorLog("cmdLogIn_Click :" + ex.Message);
                //BLUtility.ErrorLog("cmdLogIn_Click :" + ex.StackTrace);
            }
        }

    }
}