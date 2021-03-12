using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab2
{
    public partial class LogServiceTicketEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DDL.Items.Count == 0)
            { 
            noteStatus.Text = "";
            String sqlQuery = "Select ServiceName from Service WHERE ServiceID = ServiceID";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            while (queryResults.Read())
            {
                DDL.Items.Add(queryResults["ServiceName"].ToString());

            }

            queryResults.Close();
            sqlConnect.Close();
        }
    }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }

        protected void DDL_SelectedIndexChanged(object sender, EventArgs e)
        {


            String sqlQuery = "Select ServiceName, ServiceCost, CompletionDate, UpdateStatus, PaymentStatus, Origin, Destination FROM Service WHERE ServiceName = @DDL";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(DDL.Text));

            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            while (queryResults.Read())
            {
                serviceName.Text = queryResults["ServiceName"].ToString();
                serviceCost.Text = queryResults["ServiceCost"].ToString();
                completionDate.Text = queryResults["CompletionDate"].ToString();
                updateStatus.Text = queryResults["UpdateStatus"].ToString();
                paymentStatus.Text = queryResults["PaymentStatus"].ToString();
                origin.Text = queryResults["Origin"].ToString();
                destination.Text = queryResults["Destination"].ToString();

            }
            queryResults.Close();
            sqlConnect.Close();
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            String sqlQuery = "Update Service Set ServiceName = @serviceName , ServiceCost = @serviceCost, CompletionDate = @completionDate, UpdateStatus = @updateStatus, PaymentStatus = @paymentStatus, Origin = @origin , Destination = @destination WHERE ServiceName = @DDL";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(DDL.Text));
            sqlCommand.Parameters.AddWithValue("serviceName", HttpUtility.HtmlEncode(serviceName.Text));
            sqlCommand.Parameters.AddWithValue("serviceCost", HttpUtility.HtmlEncode(serviceCost.Text));
            sqlCommand.Parameters.AddWithValue("completionDate", HttpUtility.HtmlEncode(completionDate.Text));
            sqlCommand.Parameters.AddWithValue("updateStatus", HttpUtility.HtmlEncode(updateStatus.Text));
            sqlCommand.Parameters.AddWithValue("paymentStatus", HttpUtility.HtmlEncode(paymentStatus.Text));
            sqlCommand.Parameters.AddWithValue("origin", HttpUtility.HtmlEncode(origin.Text));
            sqlCommand.Parameters.AddWithValue("destination", HttpUtility.HtmlEncode(destination.Text));
           


            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            queryResults.Close();
            sqlConnect.Close();
            noteStatus.Text = "Record Updated";
        }
    }
}


