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
    public partial class LogAvailableAuctions : System.Web.UI.Page
    {

        String auctionName = "";
        String auctionDate = "";



        protected void Page_Load(object sender, EventArgs e)
        {



            if (auctionDDL.Items.Count == 0)
            {
                String customerName = HttpUtility.HtmlEncode(Request.QueryString["SendCustName"]);
                custName.Text = customerName;
                string nothing = "";
                auctionDDL.Items.Add(nothing);
                //This block of code fills a dropdown list with the info it needs
                String sqlQuery = "Select AuctionName, AuctionDate FROM AuctionEvent WHERE ServiceID = @0 AND ItemID = @0";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.AddWithValue("0", '0');
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                string thisdate = DateTime.Now.ToString("yyyy-MM-dd");
                SqlDataReader queryResults = sqlCommand.ExecuteReader();

                while (queryResults.Read())
                {
                    auctionDate = queryResults["AuctionDate"].ToString();
                    String testhold = queryResults["AuctionName"].ToString();
                    if (DateTime.Parse(thisdate) < DateTime.Parse(auctionDate))
                    {
                        auctionName = testhold;
                        auctionDDL.Items.Add(auctionName);
                    }
                }
                queryResults.Close();
                sqlConnect.Close();

                //sql to pull up a list of customer names with the "n" for if they have been serviced
                //make the n be autofilled for new customers

            }
        }


        protected void auctionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {


            String sqlQuery1 = "Select AuctionLocation, AuctionDate FROM AuctionEvent WHERE AuctionName = @aucName AND ServiceID = @0 AND ItemID = @0";
            SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Parameters.AddWithValue("aucName", HttpUtility.HtmlEncode(auctionDDL.SelectedValue));
            sqlCommand1.Parameters.AddWithValue("0", '0');
            sqlCommand1.Connection = sqlConnect1;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQuery1;
            string thisdate = DateTime.Now.ToString("yyyy-MM-dd");
            sqlConnect1.Open();

            SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();
            while (queryResults1.Read())

            {

                String auctionDate = queryResults1["AuctionDate"].ToString();

                if (DateTime.Parse(thisdate) < DateTime.Parse(auctionDate))
                {
                    auctLocation.Text = queryResults1["AuctionLocation"].ToString();
                    AuctionStart.Text = queryResults1["AuctionDate"].ToString();
                }

            }

            queryResults1.Close();
            sqlConnect1.Close();

        }


        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }

        protected void servCust_Click(object sender, EventArgs e)
        {
            String customerName = Request.QueryString["SendCustName"];

            String sqlQuery = "Select AuctionID from AuctionEvent Where AuctionName = @auctionName AND ServiceID = @base AND ItemId = @base";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("auctionName", HttpUtility.HtmlEncode(auctionDDL.SelectedValue));
            sqlCommand.Parameters.AddWithValue("base", 0);
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlConnect.Open();
            String AuctionID = "";
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            while (queryResults.Read())
            {
                AuctionID = queryResults["AuctionID"].ToString();
            }
            queryResults.Close();
            sqlConnect.Close();


            String sqlQuery1 = "Select e.ServiceID, n.ItemID FROM  Service e, Item n, Customer s WHERE s.CustomerName = @custName AND n.ServiceID = e.ServiceID AND s.CustomerID = e.CustomerID";
            SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Parameters.AddWithValue("custName", HttpUtility.HtmlEncode(custName.Text));
            sqlCommand1.Connection = sqlConnect1;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQuery1;
            string thisdate = DateTime.Now.ToString("yyyy-MM-dd");
            sqlConnect1.Open();
            SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();

            try
            {
                while (queryResults1.Read())
                {

                    String sqlQuery2 = "Insert Into AuctionEvent values (@auctionID, @serviceID, @itemID, @auctionName, @auctionDate, @auctionLocation)";
                    SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                    SqlCommand sqlCommand2 = new SqlCommand();
                    sqlCommand2.Parameters.AddWithValue("auctionID", AuctionID);
                    sqlCommand2.Parameters.AddWithValue("serviceID", queryResults1["ServiceID"].ToString());
                    sqlCommand2.Parameters.AddWithValue("itemID", queryResults1["ItemID"].ToString());
                    sqlCommand2.Parameters.AddWithValue("auctionName", HttpUtility.HtmlEncode(auctionDDL.SelectedValue));
                    sqlCommand2.Parameters.AddWithValue("auctionDate", HttpUtility.HtmlEncode(AuctionStart.Text));
                    sqlCommand2.Parameters.AddWithValue("auctionLocation", HttpUtility.HtmlEncode(auctLocation.Text));
                    sqlCommand2.Connection = sqlConnect2;
                    sqlCommand2.CommandType = CommandType.Text;
                    sqlCommand2.CommandText = sqlQuery2;
                    sqlConnect2.Open();

                    SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();


                    queryResults2.Close();
                    sqlConnect2.Close();
                    String sqlQuery4 = "Select e.ServiceID FROM  Service e, Item n, Customer s WHERE s.CustomerName = @custName AND n.ServiceID = e.ServiceID AND s.CustomerID = e.CustomerID";
                    SqlConnection sqlConnect4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


                    SqlCommand sqlCommand4 = new SqlCommand();
                    sqlCommand4.Parameters.AddWithValue("custName", HttpUtility.HtmlEncode(customerName));
                    sqlCommand4.Connection = sqlConnect4;
                    sqlCommand4.CommandType = CommandType.Text;
                    sqlCommand4.CommandText = sqlQuery4;

                    sqlConnect4.Open();
                    SqlDataReader queryResults4 = sqlCommand4.ExecuteReader();
                    String servID = "";
                    while (queryResults4.Read())
                    {
                        servID = queryResults4["ServiceID"].ToString();
                    }
                    queryResults4.Close();
                    sqlConnect4.Close();


                    String sqlQuery5 = "Update Service set AuctionedYN = @y WHERE ServiceID = @servID";
                    SqlConnection sqlConnect5 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                    SqlCommand sqlCommand5 = new SqlCommand();
                    sqlCommand5.Parameters.AddWithValue("y", '1');
                    sqlCommand5.Parameters.AddWithValue("servID", HttpUtility.HtmlEncode(servID));
                    sqlCommand5.Connection = sqlConnect5;
                    sqlCommand5.CommandType = CommandType.Text;
                    sqlCommand5.CommandText = sqlQuery5;
                    sqlConnect5.Open();

                    SqlDataReader queryResults5 = sqlCommand5.ExecuteReader();
                    queryResults5.Close();
                    sqlConnect5.Close();

                    MissingText.Text = customerName + " has been assigned to the " + auctionDDL.SelectedValue + " Auction";
                }

                //MissingText.Text = "hello?";
            }
            catch (Exception)
            { 
                
            }
            if (MissingText.Text == "")
            {
                MissingText.Text = "There are no items in this Customers Service inventory to assign to an auction";
            }



        }
    }
}