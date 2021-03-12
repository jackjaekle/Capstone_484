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
    public partial class LogServiceRequest : System.Web.UI.Page
    {
        String SendCustName = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (custList.Items.Count == 0 && MovingRadio.Checked == true)
            {
                //This block of code fills a dropdown list with the info it needs
                String sqlQuery = "Select CustomerName FROM Customer WHERE ServicedYN = @n AND descriptionOfNeeds IS NOT Null AND typeOfService = @Moving";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                String n = "0";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.AddWithValue("n", n);
                sqlCommand.Parameters.AddWithValue("Moving", "Moving");
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
        protected void MovingRadio_CheckedChanged(object sender, EventArgs e)
        {
            custList.Items.Clear();
            AuctionRadio.Checked = false;
            String sqlQuery = "Select CustomerName FROM Customer WHERE ServicedYN = @n AND descriptionOfNeeds IS NOT Null AND typeOfService = @Moving";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            String n = "0";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("n", n);
            sqlCommand.Parameters.AddWithValue("Moving", "Moving");
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


        }

        protected void AuctionRadio_CheckedChanged(object sender, EventArgs e)
        {
            custList.Items.Clear();
            MovingRadio.Checked = false;
            String sqlQuery = "Select CustomerName FROM Customer WHERE ServicedYN = @n AND descriptionOfNeeds IS NOT Null AND typeOfService = @Auction";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            String n = "0";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("n", n);
            sqlCommand.Parameters.AddWithValue("Auction", "Auction");
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

        }



        protected void custList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserInput.Text = HttpUtility.HtmlEncode(custList.SelectedValue);
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }

        protected void servCust_Click(object sender, EventArgs e)
        {
            String servType = "";
            String sqlQuery1 = "Select typeOfService FROM Customer WHERE CustomerName = @cName";
            SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            
            SqlCommand sqlCommand1 = new SqlCommand();
            
            sqlCommand1.Parameters.AddWithValue("cName", HttpUtility.HtmlEncode(UserInput.Text));
            sqlCommand1.Connection = sqlConnect1;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQuery1;
            sqlConnect1.Open();
            SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();
            while (queryResults1.Read())
            {
                servType = queryResults1["typeOfService"].ToString();

            }

            queryResults1.Close();
            sqlConnect1.Close();




            String sqlQuery = "Select CustomerName FROM Customer WHERE ServicedYN = @n AND descriptionOfNeeds IS NOT Null";//how to count the number of customers waiting on service

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            String n = "0";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("n", n);
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            int i = 0;
            String userInput = HttpUtility.HtmlEncode(UserInput.Text);
            Boolean match = false;
            while (queryResults.Read())
            {
                String customerName = "";
                customerName = (queryResults["CustomerName"].ToString());
                if (customerName == userInput)
                {
                    match = true;

                }
            }
            queryResults.Close();//closes connection
            sqlConnect.Close();

            if (match == true && servType == "Moving")
            {
                Response.Redirect("LogCustServCreation.aspx?SendCustName=" + userInput);
            }
            else if (match == true && servType == "Auction")
            {
                Response.Redirect("LogCustServAuction.aspx?SendCustName=" + userInput);
            }
            else
            {
                matchCheck.Text = "This customer either does not exist, or does not request a new service. Please select one from the list.";
            }



            //need to verify that the customer name is in the list. can use same code that pulled the customer name from before
            //throw an error if not the same
            //if its a real customer that need service link to the service ticket creation, import the data needed
        }
    }
}