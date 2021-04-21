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
    public partial class LogServiceInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DDL.Items.Count == 0)
            {

                String sqlQuery = "Select ServiceName FROM Service";
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
        protected void ServiceData_Click(object sender, EventArgs e)
        {
            ServiceInfo.Items.Clear();
            ServiceInfo.Items.Add("Service Name, Customer Name, Service Cost, Origin Address      , Start Date, End Date");


            String sqlQuery = "Select s.ServiceName, c.CustomerName, s.ServiceCost, s.Origin, s.ServiceDate, s.CompletionDate FROM Service s, Customer c WHERE s.ServiceName = @DDL AND s.CustomerID = c.CustomerID";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(DDL.Text));
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();

            //prints values taken from the database
            while (queryResults.Read())
            {
                ServiceInfo.Items.Add(queryResults["ServiceName"].ToString() + " | " + queryResults["CustomerName"].ToString() + " | " + queryResults["ServiceCost"].ToString() + " | " + queryResults["Origin"].ToString() + " | " + queryResults["ServiceDate"].ToString() + " | " + queryResults["CompletionDate"].ToString());
            }





        }
        protected void BtnShowAll_Click(object sender, EventArgs e)
        {
            ServiceInfo.Items.Clear();
            ServiceInfo.Items.Add("Service Name, Customer Name, Service Cost, Origin Address      , Start Date, End Date");

            String sqlQuery = "Select s.ServiceName, c.CustomerName, s.ServiceCost, s.Origin, s.ServiceDate, s.CompletionDate FROM Service s, Customer c WHERE s.CustomerID = c.CustomerID";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();


            while (queryResults.Read())
            {

                ServiceInfo.Items.Add(queryResults["ServiceName"].ToString() + " | " + queryResults["CustomerName"].ToString() + " | " + queryResults["ServiceCost"].ToString() + " | " + queryResults["Origin"].ToString() + " | " + queryResults["ServiceDate"].ToString() + " | " + queryResults["CompletionDate"].ToString());
            }
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }
    }
}