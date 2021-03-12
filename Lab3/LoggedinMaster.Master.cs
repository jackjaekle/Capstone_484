using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class LoggedinMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserName"] != null)
            {
                UserLoggedIn.Text = Session["UserName"].ToString() + " is Logged in";
            } 
            else
            {
                Response.Redirect("MainPageNoLogin.aspx?InvalidUse=true");
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("MainPageNoLogin.aspx?loggedout=true");
        }


    }
}