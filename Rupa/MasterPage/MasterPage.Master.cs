﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LiquorShop3Tire
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["First_Name"]) == "")
            {
              //  Response.Redirect("Login.aspx");
            }
        }
        protected void cmdLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            //Response.Redirect("LogIn.aspx");
        }
    }
}