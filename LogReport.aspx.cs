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
    public partial class LogReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Calendar1.SelectedDate = DateTime.Today;

            String DT = Calendar1.SelectedDate.ToString();

            char[] delimiterChars = { ' ' };
            string[] words1 = DT.Split(delimiterChars);
            String date1 = words1[0].Trim();

            Label1.Text = "Service requests created by Customers on " + date1;
            Label2.Text = "Employee Workflows " + date1;

            //custList.Items.Clear();
            box1.Text = "";

            if (box1.Text == "")
            {
                String sqlQuery = "Select CustomerName, DateOfServiceRequest FROM Customer WHERE descriptionOfNeeds IS NOT Null AND DateOfServiceRequest IS NOT Null ORDER BY DateOfServiceRequest";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    DateTime past = DateTime.Parse(queryResults["DateOfServiceRequest"].ToString());

                    string[] words2 = past.ToString().Split(delimiterChars);
                    String date2 = words2[0].Trim();
                    String time2 = words2[1].Trim();
                    String ampm2 = words2[2].Trim();
                    if (date2 == date1)
                    {
                        //custList.Items.Add(queryResults["CustomerName"].ToString() + " created a service request on " + date2 + "  at " + time2 + " " + ampm2);
                        box1.Text += queryResults["CustomerName"].ToString() + " created a service request on " + date2 + "  at " + time2 + " " + ampm2 + "<br />";
                    }

                }

                queryResults.Close();
                sqlConnect.Close();
            }

            //EmpList.Items.Clear();
            box2.Text = "";

            if (box2.Text == "")
            {
                String sqlQuery = "Select e.EmployeeName, s.ServiceName, e.EmployeeType, w.StartDate, w.EndDate FROM Employee e, Service s, Workflow w WHERE e.EmployeeID = w.EmployeeID AND w.ServiceID = s.ServiceID";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {

                    DateTime past = DateTime.Parse(queryResults["StartDate"].ToString());

                    string[] words2 = past.ToString().Split(delimiterChars);
                    String date2 = words2[0].Trim();
                    String time2 = words2[1].Trim();
                    String ampm2 = words2[2].Trim();

                    DateTime present = DateTime.Parse(queryResults["EndDate"].ToString());

                    string[] words3 = present.ToString().Split(delimiterChars);
                    String date3 = words3[0].Trim();
                    String time3 = words3[1].Trim();
                    String ampm3 = words3[2].Trim();

                    String dates = " from " + date2 + " to " + date3;

                    if (date3 == date1 && queryResults["ServiceName"].ToString() != "New Employee")
                    {
                        //EmpList.Items.Add(queryResults["EmployeeName"].ToString() + " worked on " + queryResults["ServiceName"].ToString() + " as a " + queryResults["EmployeeType"].ToString() + dates);
                        box2.Text += queryResults["EmployeeName"].ToString() + " worked on " + queryResults["ServiceName"].ToString() + " as a " + queryResults["EmployeeType"].ToString() + dates + "<br />";
                    }


                }

                queryResults.Close();
                sqlConnect.Close();
            }

        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }

        protected void Date_SelectedIndexChanged(object sender, EventArgs e)
        {
            //custList.Items.Clear();
            box1.Text = "";
            String DT = Calendar1.SelectedDate.ToString();

            char[] delimiterChars = { ' ' };
            string[] words = DT.Split(delimiterChars);
            String date = words[0].Trim();

            Label1.Text = "Service requests created by Customers on " + date;
            Label2.Text = "Employee Workflows on " + date;

            if (box1.Text == "")
            {
                String sqlQuery = "Select CustomerName, DateOfServiceRequest FROM Customer WHERE descriptionOfNeeds IS NOT Null AND DateOfServiceRequest IS NOT Null ORDER BY DateOfServiceRequest";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    DateTime past = DateTime.Parse(queryResults["DateOfServiceRequest"].ToString());

                    string[] words2 = past.ToString().Split(delimiterChars);
                    String date2 = words2[0].Trim();
                    String time2 = words2[1].Trim();
                    String ampm2 = words2[2].Trim();
                    if (date2 == date)
                    {
                        //custList.Items.Add(queryResults["CustomerName"].ToString() + " created a service request on " + date2 + "  at " + time2 + " " + ampm2);
                        box1.Text += queryResults["CustomerName"].ToString() + " created a service request on " + date2 + "  at " + time2 + " " + ampm2 + "<br />";
                    }

                }

                queryResults.Close();
                sqlConnect.Close();
            }

            //EmpList.Items.Clear();
            box2.Text = "";

            if (box2.Text == "")
            {
                String sqlQuery = "Select e.EmployeeName, s.ServiceName, e.EmployeeType, w.StartDate, w.EndDate FROM Employee e, Service s, Workflow w WHERE e.EmployeeID = w.EmployeeID AND w.ServiceID = s.ServiceID";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {

                    DateTime past = DateTime.Parse(queryResults["StartDate"].ToString());

                    string[] words2 = past.ToString().Split(delimiterChars);
                    String date2 = words2[0].Trim();
                    String time2 = words2[1].Trim();
                    String ampm2 = words2[2].Trim();

                    DateTime present = DateTime.Parse(queryResults["EndDate"].ToString());

                    string[] words3 = present.ToString().Split(delimiterChars);
                    String date3 = words3[0].Trim();
                    String time3 = words3[1].Trim();
                    String ampm3 = words3[2].Trim();

                    String dates = " from " + date2 + " to " + date3;

                    if (date3 == date && queryResults["ServiceName"].ToString() != "New Employee")
                    {
                        //EmpList.Items.Add(queryResults["EmployeeName"].ToString() + " worked on " + queryResults["ServiceName"].ToString() + " as a " + queryResults["EmployeeType"].ToString() + dates);
                        box2.Text += queryResults["EmployeeName"].ToString() + " worked on " + queryResults["ServiceName"].ToString() + " as a " + queryResults["EmployeeType"].ToString() + dates + "<br />";
                    }


                }

                queryResults.Close();
                sqlConnect.Close();
            }

        }

        protected void All_Click(object sender, EventArgs e)
        {
            //custList.Items.Clear();
            box1.Text = "";

            Label1.Text = "Service requests created by Customers";
            Label2.Text = "Employee Workflows";

            if (box1.Text == "")
            {
                String sqlQuery = "Select CustomerName, DateOfServiceRequest FROM Customer WHERE descriptionOfNeeds IS NOT Null AND DateOfServiceRequest IS NOT Null ORDER BY DateOfServiceRequest";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    DateTime past = DateTime.Parse(queryResults["DateOfServiceRequest"].ToString());

                    char[] delimiterChars = { ' ' };
                    string[] words1 = past.ToString().Split(delimiterChars);
                    String date1 = words1[0].Trim();
                    String time1 = words1[1].Trim();
                    String ampm1 = words1[2].Trim();

                    //custList.Items.Add(queryResults["CustomerName"].ToString() + " created a service request on " + date1 + "  at " + time1 + " " + ampm1);
                    box1.Text += queryResults["CustomerName"].ToString() + " created a service request on " + date1 + "  at " + time1 + " " + ampm1 + "<br />";

                }

                queryResults.Close();
                sqlConnect.Close();
            }

            //EmpList.Items.Clear();
            box2.Text = "";

            if (box2.Text == "")
            {
                String sqlQuery = "Select e.EmployeeName, s.ServiceName, e.EmployeeType, w.StartDate, w.EndDate FROM Employee e, Service s, Workflow w WHERE e.EmployeeID = w.EmployeeID AND w.ServiceID = s.ServiceID";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    char[] delimiterChars = { ' ' };

                    DateTime past = DateTime.Parse(queryResults["StartDate"].ToString());

                    string[] words2 = past.ToString().Split(delimiterChars);
                    String date2 = words2[0].Trim();
                    String time2 = words2[1].Trim();
                    String ampm2 = words2[2].Trim();

                    DateTime present = DateTime.Parse(queryResults["EndDate"].ToString());

                    string[] words3 = present.ToString().Split(delimiterChars);
                    String date3 = words3[0].Trim();
                    String time3 = words3[1].Trim();
                    String ampm3 = words3[2].Trim();

                    String dates = " from " + date2 + " to " + date3;

                    if (queryResults["ServiceName"].ToString() != "New Employee")
                    {
                        //EmpList.Items.Add(queryResults["EmployeeName"].ToString() + " worked on " + queryResults["ServiceName"].ToString() + " as a " + queryResults["EmployeeType"].ToString() + dates);
                        box2.Text += queryResults["EmployeeName"].ToString() + " worked on " + queryResults["ServiceName"].ToString() + " as a " + queryResults["EmployeeType"].ToString() + dates + "<br />";
                    }

                }

                queryResults.Close();
                sqlConnect.Close();
            }


        }



    }
}