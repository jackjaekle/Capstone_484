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
        DateTime now = DateTime.UtcNow;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (custList.Items.Count == 0)
            {
                //This block of code fills a dropdown list with the info it needs
                String sqlQuery = "Select c.CustomerName, c.DateOfServiceRequest FROM Customer c, Service s WHERE s.AuctionedYN = @n AND DateOfServiceRequest IS NOT Null AND c.CustomerID = s.CustomerID ORDER BY DateOfServiceRequest";
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
                    DateTime past = DateTime.Parse(queryResults["DateOfServiceRequest"].ToString());
                    TimeSpan duration = now - past;

                    char[] delimiterChars = { '.' };
                    string[] words = duration.ToString().Split(delimiterChars);
                    String days = words[0].Trim();
                    String hours = words[1].Trim();
                    if (words.Length <= 2)
                    {
                        days = "0";
                        hours = words[0].Trim();
                    }

                    custList.Items.Add(queryResults["CustomerName"].ToString() + " |  days: " + days);

                }

                queryResults.Close();
                sqlConnect.Close();

                //sql to pull up a list of customer names with the "n" for if they have been serviced
                //make the n be autofilled for new customers

            }
        }
       
        protected void custList_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] delimiterChars = { '|' };
            string[] words = HttpUtility.HtmlEncode(custList.SelectedValue).Split(delimiterChars);
            String test2 = words[0].Trim();
            String CustName = words[0].Trim();
            UserInput.Text = HttpUtility.HtmlEncode(CustName);

        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }

        protected void Submit_Click(object sender, EventArgs e)
        {

            String SendCustName = HttpUtility.HtmlEncode(UserInput.Text);



            if (SendCustName != "")
            {
                Response.Redirect("LogAvailableAuctions.aspx?SendCustName=" + SendCustName);
            }
            else
            {
                Label1.Text = "You need to select a customer before going to the next screen";
            }

           
            

        }
    }
}