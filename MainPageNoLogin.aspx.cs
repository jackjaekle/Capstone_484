using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;

namespace Lab1
{
    public partial class MainPageNoLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("loggedout") == "true")
            {
                MissingInput.ForeColor = Color.Green;
                MissingInput.Font.Bold = true;
                MissingInput.Text = string.Format("User has successfully logged out!");
            }

            if (Request.QueryString.Get("InvalidUse") == "true")
            {
                MissingInput.ForeColor = Color.Red;
                MissingInput.Font.Bold = true;
                MissingInput.Text = "You must first login to access the application page!";
            }
        }

        protected void CLogin_Click(object sender, EventArgs e)
        {
          
                Session["UserName"] = UserName.Value;




            if (String.IsNullOrEmpty(UserName.Value.ToString()) || String.IsNullOrEmpty(Password.Value.ToString()))
            {
                MissingInput.ForeColor = Color.Red;
                MissingInput.Font.Bold = true;
                MissingInput.Text = string.Format("You are missing an input");//notifies user that there is missing info
            }
            else
            {
                MissingInput.Text = string.Format("");
                //selects the values needed from the database to print
                String sqlQuery = "Select UserName, Password FROM Login";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;


                sqlConnect.Open();

                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                //prints values taken from the database

                while (queryResults.Read())
                {
                    if (String.Equals(queryResults["UserName"].ToString(), UserName.Value.ToString()) && PasswordHash.ValidatePassword(Password.Value.ToString(), queryResults["Password"].ToString()))
                    {
                        Session["UserName"] = UserName.Value.ToString();
                        Response.Redirect("CustomerMainPage.aspx");
                    }
                }

                queryResults.Close(); //closes connection
                sqlConnect.Close();



                 sqlQuery = "Select Password FROM ELogin";
                SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);

                SqlCommand sqlCommand1 = new SqlCommand();
                sqlCommand1.Connection = sqlConnect1;
                sqlCommand1.CommandType = CommandType.Text;
                sqlCommand1.CommandText = sqlQuery;


                sqlConnect1.Open();

                SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();
                while (queryResults1.Read())
                {
                    if (PasswordHash.ValidatePassword(Password.Value.ToString(), queryResults1["Password"].ToString()))
                    {
                        //String HashPass = PasswordHash.HashPassword(EPassword.Text);
                      sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);

                      sqlCommand = new SqlCommand();
                        sqlCommand.Connection = sqlConnect;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandText = "JeremyEzellLab3";

                        sqlCommand.Parameters.AddWithValue("@Username", UserName.Value.ToString());

                        sqlConnect.Open();

                        queryResults = sqlCommand.ExecuteReader();
                        //prints values taken from the database
                        if (queryResults.Read())
                        {
                            Session["UserName"] = UserName.Value.ToString();
                            Response.Redirect("LoggedinMainPage.aspx");


                        }

                        queryResults.Close(); //closes connection
                        sqlConnect.Close();
                    }
                }
                queryResults1.Close(); //closes connection
                sqlConnect1.Close();





                MissingInput.ForeColor = Color.Red;
                MissingInput.Font.Bold = true;
                MissingInput.Text = string.Format("Invalid Username and/or password");
            }
        }

        protected void NewCustomer_Click(object sender, EventArgs e)
        {
            //copy text in textbox over to LogNewCustomer for user to make a new customer account
            Response.Redirect("CustomerPortal.aspx");
        }
    }
}