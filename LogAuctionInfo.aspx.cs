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
    public partial class LogAuctionInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DDL.Items.Count == 0)// only loads the emp info once
            {

                String sqlQuery = "Select AuctionName FROM AuctionEvent GROUP BY AuctionName";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.AddWithValue("0", '0');
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                        DDL.Items.Add(queryResults["AuctionName"].ToString()); //puts it in a ddl 
                }

                queryResults.Close();
                sqlConnect.Close();
            }
        }
        protected void btnLoadEmployeeData_Click(object sender, EventArgs e)
        {
            AuctionInformation.Items.Clear();
            AuctionInformation.Items.Add("Customers attending auction"); //makes a header for the display box

            String ChosenName = HttpUtility.HtmlEncode(DDL.SelectedValue);

            String sqlQuery = "Select c.CustomerName FROM AuctionEvent a, Service s, Customer c WHERE s.ServiceID = a.ServiceID and c.CustomerID = s.CustomerID and a.AuctionName = @DDL";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(DDL.Text));
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();

            //prints values taken from the database
            while (queryResults.Read()) //outpurs the stuff from the db into the display box
            {
                string CustName = queryResults["CustomerName"].ToString();
                if (AuctionInformation.Items.Contains(new ListItem(CustName))) //this makes sure it doesnt display the customer name multiple times
                {
                    //do nothing
                }
                else
                {
                    AuctionInformation.Items.Add(CustName);
                }
            }

        }
        protected void BtnShowAll_Click(object sender, EventArgs e) //is used to show every customers info
        {
            AuctionInformation.Items.Clear();
            AuctionInformation.Items.Add("Customer Name | Auction Name "); //makes a header for the display box
            String sqlQuery = "Select s.AuctionName, c.CustomerName FROM AuctionEvent s, Service e,  Customer c WHERE e.ServiceID = s.ServiceID and c.CustomerID = e.CustomerID ORDER BY s.AuctionName";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(DDL.Text));
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();

            //prints values taken from the database
            while (queryResults.Read()) //outpurs the stuff from the db into the display box
            {

                string CustName = queryResults["CustomerName"].ToString() + " | " + queryResults["AuctionName"].ToString();
                if (AuctionInformation.Items.Contains(new ListItem(CustName))) //this makes sure it doesnt display the customer name multiple times
                {
                    //do nothing
                }
                else
                {
                    AuctionInformation.Items.Add(CustName);
                }
            }

        }
        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }
    }
}