using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class EquipmentManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void EquipmentStatus_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogEquipmentStatus.aspx");
        }

        protected void NewEquipment_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogNewEquipment.aspx");
        }
        protected void EquipmentRent_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogEquipmentRent.aspx");
        }
        protected void EquipmentRentInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogEquipmentRentInfo.aspx");
        }
        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }
    }
}