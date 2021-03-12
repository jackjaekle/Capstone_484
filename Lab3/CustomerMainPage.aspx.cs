using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class CustomerMainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ServiceRequest_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustServReq.aspx");//links back to main page
        }
    

        }
}