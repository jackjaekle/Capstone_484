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

            Button2.Visible = false;

            String DT = Calendar1.SelectedDate.ToString();
            if (Label1.Text == "")
            {
                char[] delimiterChars = { ' ' };
                char[] delimiterChars2 = { '/' };
                string[] words1 = DT.Split(delimiterChars);
                String date1 = words1[0].Trim();

                Label1.Text = "Service requests created by Customers on " + date1;
                Label2.Text = "Employee Workflows " + date1;

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
                            box1.Text += queryResults["CustomerName"].ToString() + " created a service request on " + date2 + "  at " + time2 + " " + ampm2 + "<br />";
                        }

                    }

                    queryResults.Close();
                    sqlConnect.Close();

                }


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

                        string[] words11 = date1.Split(delimiterChars2);
                        String month1 = words11[0].Trim();
                        String day1 = words11[1].Trim();
                        String year1 = words11[2].Trim();


                        DateTime past = DateTime.Parse(queryResults["StartDate"].ToString());

                        string[] words2 = past.ToString().Split(delimiterChars);
                        String date2 = words2[0].Trim();
                        String time2 = words2[1].Trim();
                        String ampm2 = words2[2].Trim();

                        string[] words22 = date2.Split(delimiterChars2);
                        String month2 = words22[0].Trim();
                        String day2 = words22[1].Trim();
                        String year2 = words22[2].Trim();


                        DateTime present = DateTime.Parse(queryResults["EndDate"].ToString());

                        string[] words3 = present.ToString().Split(delimiterChars);
                        String date3 = words3[0].Trim();
                        String time3 = words3[1].Trim();
                        String ampm3 = words3[2].Trim();

                        string[] words33 = date3.Split(delimiterChars2);
                        String month3 = words33[0].Trim();
                        String day3 = words33[1].Trim();
                        String year3 = words33[2].Trim();

                        String dates = " from " + date2 + " to " + date3;

                        //list employees working today
                        if (month1 == month2 || month1 == month3)
                        {
                            if (year1 == year2 || year1 == year3)
                            {
                                if (int.Parse(day2) <= int.Parse(day1) && int.Parse(day1) < int.Parse(day3))
                                {
                                    box2.Text += queryResults["EmployeeName"].ToString() + " is working on " + queryResults["ServiceName"].ToString() + " as a " + queryResults["EmployeeType"].ToString() + dates + "<br />";
                                }
                                //list workflows that were created today
                                else if (date3 == date1 && queryResults["ServiceName"].ToString() != "New Employee")
                                {
                                    box2.Text += queryResults["EmployeeName"].ToString() + " worked on " + queryResults["ServiceName"].ToString() + " as a " + queryResults["EmployeeType"].ToString() + dates + "<br />";
                                }
                            }

                        }


                    }

                    queryResults.Close();
                    sqlConnect.Close();
                }


            }

        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }

        protected void Date_SelectedIndexChanged(object sender, EventArgs e)
        {
            String DT = Calendar1.SelectedDate.ToString();

            char[] delimiterChars = { ' ' };
            char[] delimiterChars2 = { '/' };
            string[] words = DT.Split(delimiterChars);
            String date = words[0].Trim();

            Label1.Text = "Service requests created by Customers on " + date;
            Label2.Text = "Employee Workflows on " + date;

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
                    if (date2 == date)
                    {
                        box1.Text += queryResults["CustomerName"].ToString() + " created a service request on " + date2 + "  at " + time2 + " " + ampm2 + "<br />";
                    }

                }

                queryResults.Close();
                sqlConnect.Close();
            }

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

                    string[] words1 = date.Split(delimiterChars2);
                    String month1 = words1[0].Trim();
                    String day1 = words1[1].Trim();
                    String year1 = words1[2].Trim();

                    string[] words2 = past.ToString().Split(delimiterChars);
                    String date2 = words2[0].Trim();
                    String time2 = words2[1].Trim();
                    String ampm2 = words2[2].Trim();

                    string[] words22 = date2.Split(delimiterChars2);
                    String month2 = words22[0].Trim();
                    String day2 = words22[1].Trim();
                    String year2 = words22[2].Trim();

                    DateTime present = DateTime.Parse(queryResults["EndDate"].ToString());

                    string[] words3 = present.ToString().Split(delimiterChars);
                    String date3 = words3[0].Trim();
                    String time3 = words3[1].Trim();
                    String ampm3 = words3[2].Trim();

                    string[] words33 = date3.Split(delimiterChars2);
                    String month3 = words33[0].Trim();
                    String day3 = words33[1].Trim();
                    String year3 = words33[2].Trim();

                    String dates = " from " + date2 + " to " + date3;

                    //list employees working today
                    if (month1 == month2 || month1 == month3)
                    {
                        if (year1 == year2 || year1 == year3)
                        {
                            if (int.Parse(day2) <= int.Parse(day1) && int.Parse(day1) < int.Parse(day3))
                            {
                                box2.Text += queryResults["EmployeeName"].ToString() + " is working on " + queryResults["ServiceName"].ToString() + " as a " + queryResults["EmployeeType"].ToString() + dates + "<br />";
                            }
                            //list workflows that were created today
                            else if (date3 == date && queryResults["ServiceName"].ToString() != "New Employee")
                            {
                                box2.Text += queryResults["EmployeeName"].ToString() + " worked on " + queryResults["ServiceName"].ToString() + " as a " + queryResults["EmployeeType"].ToString() + dates + "<br />";
                            }
                        }

                    }


                }

                queryResults.Close();
                sqlConnect.Close();
            }

        }

        protected void All_Click(object sender, EventArgs e)
        {

            Label1.Text = "Service requests created by Customers";
            Label2.Text = "Employee Workflows";

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

                    char[] delimiterChars = { ' ' };
                    string[] words1 = past.ToString().Split(delimiterChars);
                    String date1 = words1[0].Trim();
                    String time1 = words1[1].Trim();
                    String ampm1 = words1[2].Trim();

                    box1.Text += queryResults["CustomerName"].ToString() + " created a service request on " + date1 + "  at " + time1 + " " + ampm1 + "<br />";

                }

                queryResults.Close();
                sqlConnect.Close();
            }

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
                        box2.Text += queryResults["EmployeeName"].ToString() + " was assited to " + queryResults["ServiceName"].ToString() + " as a " + queryResults["EmployeeType"].ToString() + dates + "<br />";
                    }

                }

                queryResults.Close();
                sqlConnect.Close();
            }


        }

        protected void Print_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = false;
            All.Visible = false;
            Button1.Visible = false;
            Button2.Visible = true;
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
            All.Visible = true;
            Button1.Visible = true;
            Button2.Visible = false;
        }



    }
}