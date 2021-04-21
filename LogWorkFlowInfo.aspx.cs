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
    public partial class LogWorkFlowInfo : System.Web.UI.Page
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
        protected void btnLoadWorkFlowData_Click(object sender, EventArgs e)
        {
            CustomerInformation.Items.Clear();
            CustomerInformation.Items.Add("Employee Name, ServiceName, Start Date, End Date, Employee Role");

            String ChosenName = HttpUtility.HtmlEncode(DDL.SelectedValue); //need to get the service name from service by suing service id as the linking factor. mix of the workflow and service tables


            String sqlQuery = "Select t.EmployeeName, e.ServiceName, s.StartDate, s.EndDate, s.Status FROM WorkFlow s, Service e, Employee t WHERE e.ServiceID = s.ServiceID AND t.EmployeeID = s.EmployeeID AND e.ServiceName = @DDL";
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

                CustomerInformation.Items.Add(queryResults["EmployeeName"].ToString() + " | " + queryResults["ServiceName"].ToString() + " | " + queryResults["StartDate"].ToString() + " | " + queryResults["EndDate"].ToString() + " | " + queryResults["Status"].ToString());
            }





        }
        protected void BtnShowAll_Click(object sender, EventArgs e)
        {
            CustomerInformation.Items.Clear();
            CustomerInformation.Items.Add("Employee Name, ServiceName, Start Date, End Date, Employee Role");

            String sqlQuery = "Select t.EmployeeName,e.ServiceName, s.StartDate, s.EndDate, s.Status FROM WorkFlow s, Service e, Employee t WHERE e.ServiceID = s.ServiceID AND t.EmployeeID = s.EmployeeID";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();


            while (queryResults.Read())
            {

                CustomerInformation.Items.Add(queryResults["EmployeeName"].ToString() + " | " + queryResults["ServiceName"].ToString() + " | " + queryResults["StartDate"].ToString() + " | " + queryResults["EndDate"].ToString() + " | " + queryResults["Status"].ToString());
            }
        }


        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }
    }
}