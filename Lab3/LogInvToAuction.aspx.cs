using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab3
{
    public partial class LogInvToAuction : System.Web.UI.Page
    {
        String SendCustName = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (custList.Items.Count == 0)
            {
                //This block of code fills a dropdown list with the info it needs
                String sqlQuery = "Select c.CustomerName FROM Customer c, Service s WHERE s.AuctionedYN = @n AND c.CustomerID = s.CustomerID";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                String n = "0";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.AddWithValue("n", n);
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    custList.Items.Add(queryResults["CustomerName"].ToString());

                }

                queryResults.Close();
                sqlConnect.Close();

                //sql to pull up a list of customer names with the "n" for if they have been serviced
                //make the n be autofilled for new customers

            }
        }
       
        protected void custList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserInput.Text = HttpUtility.HtmlEncode(custList.SelectedValue);
            
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }

        protected void Submit_Click(object sender, EventArgs e)
        {

            String SendCustName = HttpUtility.HtmlEncode(custList.SelectedValue);
            Response.Redirect("LogAvailableAuctions.aspx?SendCustName=" + SendCustName);
            

        }
    }
}