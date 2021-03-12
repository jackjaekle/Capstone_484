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
    public partial class LogNewEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx");//links back to main page
        }
        protected void PopulateButton_Click(object sender, EventArgs e)
        {

            EmployeeFirstName.Text = string.Format("Employee");//populates a textbox
            EmployeePhone.Text = string.Format("8754853");
            EmployeeEmail.Text = string.Format("notalegitemail@gmail.com");
            Password.Text = string.Format("111");
            EmployeeAddress.Text = string.Format("1234 mainstreet USA");
            EmployeeLastName.Text = string.Format("McEmployeeFace");
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            EmployeeFirstName.Text = string.Format("");//clears a textbox
            EmployeePhone.Text = string.Format("");
            EmployeeEmail.Text = string.Format("");
            Password.Text = string.Format("");
            EmployeeAddress.Text = string.Format("");
            EmployeeLastName.Text = string.Format("");

        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(EmployeeFirstName.Text) || String.IsNullOrEmpty(EmployeeLastName.Text) || String.IsNullOrEmpty(EmployeePhone.Text) || String.IsNullOrEmpty(EmployeeEmail.Text) || String.IsNullOrEmpty(EmployeeAddress.Text))
            {
                //do nothing
                MissingInput.Text = string.Format("You are missing an input");//notifies user that there is missing info
            }
            else
            {

                MissingInput.Text = string.Format("");


                String sqlQuery = "Select * from Employee";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;

                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                string FirstLast = HttpUtility.HtmlEncode(EmployeeFirstName.Text) + " " + HttpUtility.HtmlEncode(EmployeeLastName.Text);
                String userInput = FirstLast;
                String userEmailInput = EmployeeEmail.Text;
                String dbNames = "";
                String dbEmails = "";
                Boolean duplicate = false;

                    while (queryResults.Read())
                {
                    dbNames = (queryResults["EmployeeName"].ToString());
                    dbEmails = (queryResults["EmployeeEmail"].ToString());
                        if (dbNames == userInput || dbEmails == userEmailInput)
                    {
                        duplicate = true;

                    }
                }

                queryResults.Close();//closes connection
                sqlConnect.Close();


                if (duplicate == false)
                {
                    String sqlQuery1 = "Insert into Employee (EmployeeName, EmployeePhone, EmployeeEmail, EmployeeAddress) Values (@EmployeeName, @EmployeePhone, @EmployeeEmail, @EmployeeAddress)";
                    SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand1 = new SqlCommand();
                    sqlCommand1.Parameters.AddWithValue("EmployeeName", FirstLast);
                    sqlCommand1.Parameters.AddWithValue("EmployeePhone", HttpUtility.HtmlEncode(EmployeePhone.Text));
                    sqlCommand1.Parameters.AddWithValue("EmployeeEmail", HttpUtility.HtmlEncode(EmployeeEmail.Text));
                    sqlCommand1.Parameters.AddWithValue("EmployeeAddress", HttpUtility.HtmlEncode(EmployeeAddress.Text));



                    sqlCommand1.Connection = sqlConnect1;
                    sqlCommand1.CommandType = CommandType.Text;
                    sqlCommand1.CommandText = sqlQuery1;

                    sqlConnect1.Open();
                    SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();



                    queryResults1.Close();//closes connection
                    sqlConnect1.Close();




                    String sqlQuery2 = "Insert into ELogin(UserName, Password) Values (@EmployeeEmail, @CPassword)";

                    SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);

                    SqlCommand sqlCommand2 = new SqlCommand();

                    String HashPass = PasswordHash.HashPassword(Password.Text);

                    sqlCommand2.Parameters.AddWithValue("EmployeeEmail", HttpUtility.HtmlEncode(EmployeeEmail.Text));
                    sqlCommand2.Parameters.AddWithValue("CPassword", HashPass);



                    sqlCommand2.Connection = sqlConnect2;
                    sqlCommand2.CommandType = CommandType.Text;
                    sqlCommand2.CommandText = sqlQuery2;

                    sqlConnect2.Open();
                    SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();



                    queryResults2.Close();//closes connection
                    sqlConnect2.Close();


                    Session["UserName"] = EmployeeEmail.Text;

                    TestLabel.Text = string.Format("New Employee Added");


                }
                else
                {
                    TestLabel.Text = string.Format("A User with this name and/or email already exists.");
                }





            }
        }
    }
}