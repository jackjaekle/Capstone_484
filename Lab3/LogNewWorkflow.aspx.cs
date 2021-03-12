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
    public partial class LogNewWorkflow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (empDDL.Items.Count == 0)
            {

                String sqlQuery = "Select EmployeeName FROM Employee";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    empDDL.Items.Add(queryResults["EmployeeName"].ToString());

                }
                queryResults.Close();
                sqlConnect.Close();
            }
            if (serviceDDL.Items.Count == 0)
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
                    serviceDDL.Items.Add(queryResults["ServiceName"].ToString());

                }
                queryResults.Close();
                sqlConnect.Close();
            }
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }
        protected void PopulateButton_Click(object sender, EventArgs e)
        {
            
            StartDate.Text = string.Format("1-1-21");
            EndDate.Text = string.Format("1-10-21");
            Status.Text = string.Format("in progress");

        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            
            StartDate.Text = string.Format("");
            EndDate.Text = string.Format("");
            Status.Text = string.Format("");


        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(StartDate.Text) || String.IsNullOrEmpty(EndDate.Text) || String.IsNullOrEmpty(Status.Text))
            {
                //do nothing
                MissingInput.Text = string.Format("You are missing an input");//notifies user that there is missing info
            }
            else
            {


                String empName = HttpUtility.HtmlEncode(empDDL.Text);
                String empID= "";
                String sqlQuery2 = "Select EmployeeID FROM Employee WHERE @EmployeeName = EmployeeName";
                SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);



                SqlCommand sqlCommand2 = new SqlCommand();
                sqlCommand2.Parameters.AddWithValue("EmployeeName", empName);

                sqlCommand2.Connection = sqlConnect2;
                sqlCommand2.CommandType = CommandType.Text;
                sqlCommand2.CommandText = sqlQuery2;


                sqlConnect2.Open();

                SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();

                //prints values taken from the database
                while (queryResults2.Read())
                {
                    empID = (queryResults2["EmployeeID"].ToString());
                }
                queryResults2.Close();//closes connection
                sqlConnect2.Close();



                String serviceName = HttpUtility.HtmlEncode(serviceDDL.Text);
                String serviceID = "";
                String sqlQuery3 = "Select ServiceID FROM Service WHERE @ServiceName = ServiceName";
                SqlConnection sqlConnect3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommand3 = new SqlCommand();
                sqlCommand3.Parameters.AddWithValue("ServiceName", serviceName);
                sqlCommand3.Connection = sqlConnect3;
                sqlCommand3.CommandType = CommandType.Text;
                sqlCommand3.CommandText = sqlQuery3;


                sqlConnect3.Open();

                SqlDataReader queryResults3 = sqlCommand3.ExecuteReader();

                //prints values taken from the database
                while (queryResults3.Read())
                {
                    serviceID = (queryResults3["ServiceID"].ToString());
                }
                queryResults3.Close();//closes connection
                sqlConnect3.Close();




                MissingInput.Text = string.Format("");


                String sqlQuery1 = "Insert into Workflow (EmployeeID, ServiceID, StartDate, EndDate, Status) Values (@EmployeeID, @ServiceID, @StartDate, @EndDate, @Status)";
                    SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand1 = new SqlCommand();
                    sqlCommand1.Parameters.AddWithValue("EmployeeID", empID);
                    sqlCommand1.Parameters.AddWithValue("ServiceID", serviceID);
                    sqlCommand1.Parameters.AddWithValue("StartDate", HttpUtility.HtmlEncode(StartDate.Text));
                    sqlCommand1.Parameters.AddWithValue("EndDate", HttpUtility.HtmlEncode(EndDate.Text));
                    sqlCommand1.Parameters.AddWithValue("Status", HttpUtility.HtmlEncode(Status.Text));



                sqlCommand1.Connection = sqlConnect1;
                    sqlCommand1.CommandType = CommandType.Text;
                    sqlCommand1.CommandText = sqlQuery1;

                    sqlConnect1.Open();
                    SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();



                    queryResults1.Close();//closes connection
                    sqlConnect1.Close();
                    TestLabel.Text = string.Format("Successfully inserted into database.");



            }
        }
    }
}