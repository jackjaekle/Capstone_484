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
    public partial class LogEmployeeInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DDL.Items.Count == 0)// only loads the emp info once
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
                    DDL.Items.Add(queryResults["EmployeeName"].ToString()); //puts it in a ddl 

                }

                queryResults.Close();
                sqlConnect.Close();
            }
        }
        protected void btnLoadEmployeeData_Click(object sender, EventArgs e)
        {
            EmployeeInformation.Items.Clear();
            EmployeeInformation.Items.Add("Employee Name, Employee Address, Employee Phone, Employee Email"); //makes a header for the display box

            String ChosenName = HttpUtility.HtmlEncode(DDL.SelectedValue);

            String sqlQuery = "Select EmployeeName, EmployeeAddress, EmployeePhone, EmployeeEmail FROM Employee WHERE EmployeeName = @DDL";
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

                EmployeeInformation.Items.Add(queryResults["EmployeeName"].ToString() + " | " + queryResults["EmployeeAddress"].ToString() + " | " + queryResults["EmployeePhone"].ToString() + " | " + queryResults["EmployeeEmail"].ToString());
            }





        }
        protected void BtnShowAll_Click(object sender, EventArgs e) //is used to show every customers info
        {
            EmployeeInformation.Items.Clear();
            EmployeeInformation.Items.Add("Employee Name, Employee Address, Employee Phone, Employee Email");

            String sqlQuery = "Select EmployeeName, EmployeeAddress, EmployeePhone, EmployeeEmail FROM Employee WHERE EmployeeName = EmployeeName";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();


            while (queryResults.Read())
            {

                EmployeeInformation.Items.Add(queryResults["EmployeeName"].ToString() + " | " + queryResults["EmployeeAddress"].ToString() + " | " + queryResults["EmployeePhone"].ToString() + " | " + queryResults["EmployeeEmail"].ToString());
            }
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }
    }
}