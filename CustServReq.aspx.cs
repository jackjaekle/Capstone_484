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
    public partial class CustServReq : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void MovingRadio_CheckedChanged(object sender, EventArgs e)
        {
            AuctionRadio.Checked = false;
        }

        protected void AuctionRadio_CheckedChanged(object sender, EventArgs e)
        {

            MovingRadio.Checked = false;

        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerMainPage.aspx");//links back to main page
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            String customerEmail = HttpUtility.HtmlEncode(Session["UserName"].ToString());
            String CustomerID = "";

            String sqlQuery1 = "Select CustomerID FROM Customer WHERE CustomerEmail = @email";
            SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Parameters.AddWithValue("email", customerEmail);
            sqlCommand1.Connection = sqlConnect1;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQuery1;
            sqlConnect1.Open();
            SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();
            while (queryResults1.Read())
            {
                CustomerID = (queryResults1["CustomerID"].ToString());
            }




            queryResults1.Close();
            sqlConnect1.Close();


            String serviceType = "";

            if (MovingRadio.Checked)
            {
                serviceType = "Moving";
            }
            if (!MovingRadio.Checked)
            {
                serviceType = "Auction";
            }
            String sqlQuery = "Update Customer Set typeOfService = @servType,  ServiceDate = @reqDate,  descriptionOfNeeds = @descNeeds, CustomerCurrentAddress = @servAdd, DateOfServiceRequest = @SDate, ServicedYN = @0 WHERE CustomerID = @custID";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("servType", serviceType);
            sqlCommand.Parameters.AddWithValue("reqDate", HttpUtility.HtmlEncode(reqDate.Text));
            sqlCommand.Parameters.AddWithValue("descNeeds", HttpUtility.HtmlEncode(descOfNeeds.Text));
            sqlCommand.Parameters.AddWithValue("custID", CustomerID);
            sqlCommand.Parameters.AddWithValue("servAdd", HttpUtility.HtmlEncode(servAddress.Text));
            sqlCommand.Parameters.AddWithValue("SDate", DateTime.UtcNow);
            sqlCommand.Parameters.AddWithValue("0", '0');
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();



            MissingInput.Text = "Service Request Sent";

            queryResults.Close();//closes connection
            sqlConnect.Close();
        }

        protected void Upload_Click(object sender, EventArgs e)
        {

            String customerEmail = HttpUtility.HtmlEncode(Session["UserName"].ToString());
            String CustomerID = "";

            String sqlQuery1 = "Select CustomerID FROM Customer WHERE CustomerEmail = @email";
            SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Parameters.AddWithValue("email", customerEmail);
            sqlCommand1.Connection = sqlConnect1;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQuery1;
            sqlConnect1.Open();
            SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();
            while (queryResults1.Read())
            {
                CustomerID = (queryResults1["CustomerID"].ToString());
            }
            queryResults1.Close();


          


            if (uploadFiles.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in uploadFiles.PostedFiles)
                {
                    uploadedFile.SaveAs(Server.MapPath("/images/" + uploadedFile.FileName));


                    String sqlQuery = "Insert into Images values(@imgName, @custID)";
                    SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Parameters.AddWithValue("imgName", uploadedFile.FileName);
                    sqlCommand.Parameters.AddWithValue("custID", CustomerID);

                    sqlCommand.Connection = sqlConnect;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = sqlQuery;
                    sqlConnect.Open();
                    SqlDataReader queryResults = sqlCommand.ExecuteReader();
                    queryResults.Close();
                    sqlConnect.Close();

                }
            }

        }
    }
}