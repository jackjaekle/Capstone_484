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
    public partial class LogCreateNewAuction : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            MissingInput.Text = "";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            String sqlQuery2 = "Select * from AuctionEvent WHERE AuctionID = AuctionID;";
            SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect2;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuery2;

            sqlConnect2.Open();
            SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();
            string date = HttpUtility.HtmlEncode(auctionDate.Text);
            String auctName = HttpUtility.HtmlEncode(auctionName.Text);
            String dbAucName = "";
            String dbAucDate = "";
            Boolean duplicate = false;

            while (queryResults2.Read())
            {
                dbAucName = (queryResults2["AuctionName"].ToString());
                dbAucDate = (queryResults2["AuctionDate"].ToString());
                if (dbAucName == auctName && dbAucDate == date)
                {
                    duplicate = true;

                }
            }
            queryResults2.Close();//closes connection
            sqlConnect2.Close();





            if (duplicate == false)
            {

                String sqlQuery = "Select AuctionID from AuctionEvent"; //going to make it select the highest auction id num
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                int currentAuctionID = 0;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    int x = int.Parse(queryResults["AuctionID"].ToString()); //puts it in a ddl 
                    if (x > currentAuctionID)
                    {
                        currentAuctionID = x;
                    }
                }


                queryResults.Close();//closes connection
                sqlConnect.Close();


                int newAucID = currentAuctionID++;
                String sqlQuery1 = "Insert into AuctionEvent values (@aucID, @servID,@itemID, @auctionName, @auctionDate, @auctionLocation)";
                SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand1 = new SqlCommand();
                sqlCommand1.Parameters.AddWithValue("aucID", currentAuctionID);
                sqlCommand1.Parameters.AddWithValue("servID", "0");
                sqlCommand1.Parameters.AddWithValue("itemID", "0");
                sqlCommand1.Parameters.AddWithValue("auctionName", HttpUtility.HtmlEncode(auctionName.Text));
                sqlCommand1.Parameters.AddWithValue("auctionDate", HttpUtility.HtmlEncode(auctionDate.Text));
                sqlCommand1.Parameters.AddWithValue("auctionLocation", HttpUtility.HtmlEncode(auctionLocation.Text));




                sqlCommand1.Connection = sqlConnect1;
                sqlCommand1.CommandType = CommandType.Text;
                sqlCommand1.CommandText = sqlQuery1;

                sqlConnect1.Open();
                SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();



                queryResults1.Close();//closes connection
                sqlConnect1.Close();
                MissingInput.Text = string.Format("Successfully created Auction Event.");



            }
            else
            {
                MissingInput.Text = string.Format("There is already an auction with the same name and date");
            }
        }
        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx");
        }
    }
}