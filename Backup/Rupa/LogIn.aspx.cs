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
                Response.Redirect("~/MasterEntry/ProductCategory.aspx",false);
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
                    Session["User_Id"] = dt.Rows[0]["User_ID"];
                    Session["User_Name"] = dt.Rows[0]["User_Name"];
                    Session["First_Name"] = dt.Rows[0]["First_Name"];
                    Session["AcessLevel"] = dt.Rows[0]["AcessLevel"];
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(In valid);", true);

                }
            }
            catch (Exception ex)
            {
                BLUtility.ErrorLog("cmdLogIn_Click :" + ex.Message);
                BLUtility.ErrorLog("cmdLogIn_Click :" + ex.StackTrace);
            }
        }

    }
}