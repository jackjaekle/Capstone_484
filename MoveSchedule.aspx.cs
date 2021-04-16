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
    public partial class MoveSchedule : System.Web.UI.Page
    {
        String sendName = "";
        DateTime now = DateTime.UtcNow;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CustomerInfo.Items.Count == 0)// only loads the emp info once
            {


                String sqlQuery2 = "Select CustomerName, DateOfServiceRequest FROM Customer WHERE ServicedYN = @n AND descriptionOfNeeds IS NOT Null AND DateOfServiceRequest IS NOT Null AND MoveCreateYN ='0' ORDER BY DateOfServiceRequest";
                SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand2 = new SqlCommand();
                sqlCommand2.Parameters.AddWithValue("n", '1');
                sqlCommand2.Connection = sqlConnect2;
                sqlCommand2.CommandType = CommandType.Text;
                sqlCommand2.CommandText = sqlQuery2;

                sqlConnect2.Open();
                SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();
                while (queryResults2.Read())
                {
                    DateTime past = DateTime.Parse(queryResults2["DateOfServiceRequest"].ToString());
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

                    CustomerInfo.Items.Add(queryResults2["CustomerName"].ToString() + " |  days: " + days);
                }

                queryResults2.Close();
                sqlConnect2.Close();
            }
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }


        protected void EstimateSheet_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { '|' };
            string[] words = HttpUtility.HtmlEncode(CustomerInfo.SelectedValue).Split(delimiterChars);
            String test2 = words[0].Trim();
            String CustName = words[0].Trim();

            String ChosenName = HttpUtility.HtmlEncode(CustName);

            if (ChosenName != "")
            {
                Response.Redirect("EstimateWorkSheet.aspx?sendName=" + ChosenName);
            }
            else
            {
                Label3.Text = "You need to select a customer before going to the next screen";
            }
            
        }
    }
}