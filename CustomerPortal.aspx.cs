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
    public partial class CustomerPortal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DDL2.Items.Add("In Person");
            DDL2.Items.Add("By Phone");
            DDL2.Items.Add("Email");
            DDL2.Items.Add("Text");
            DDL2.Items.Add("Other");
            DDL3.Items.Add("Home");
            DDL3.Items.Add("Cell");
            DDL3.Items.Add("Business");

            if (DDL2.Text != "Other")
            {
                otherBox.Visible = false;
                otherBox.Text = "0";
            }
            else
            {
                otherBox.Visible = true;
            }



        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPageNoLogin.aspx");//links back to main page
        }

        protected void PopulateButton_Click(object sender, EventArgs e)
        {
            CustomerFirstName.Text = string.Format("John");//populates a textbox
            CustomerLastName.Text = string.Format("Jameson");
            CustomerPhone.Text = string.Format("8675309");
            CustomerEmail.Text = string.Format("userlegitemail@gmail.com");
            Password.Text = string.Format("Password");
            customerHear.Text = string.Format("Friend");
            Address.Text = string.Format("123 Apple dr.");




        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            CustomerFirstName.Text = string.Format("");//clears a textbox
            CustomerPhone.Text = string.Format("");
            Password.Text = string.Format("");
            CustomerEmail.Text = string.Format("");
            CustomerLastName.Text = string.Format("");
            customerHear.Text = string.Format("");
            Address.Text = string.Format("");



        }
        protected void Submit_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(CustomerFirstName.Text) || String.IsNullOrEmpty(CustomerLastName.Text) || String.IsNullOrEmpty(CustomerPhone.Text) || String.IsNullOrEmpty(CustomerEmail.Text))
            {
                //do nothing
                MissingInput.Text = string.Format("You are missing an input");//notifies user that there is missing info
            }
            else
            {
                MissingInput.Text = string.Format("");


                String sqlQuery = "Select * from Customer";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;

                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                string FirstLast = HttpUtility.HtmlEncode(CustomerFirstName.Text) + " " + HttpUtility.HtmlEncode(CustomerLastName.Text);
                String userInput = FirstLast;
                String userEmailInput = HttpUtility.HtmlEncode(CustomerEmail.Text);
                String dbNames = "";
                String dbEmails = "";
                Boolean duplicate = false;

                while (queryResults.Read())
                {
                    dbNames = (queryResults["CustomerName"].ToString());
                    dbEmails = (queryResults["CustomerEmail"].ToString());
                    if (dbNames == userInput || dbEmails == userEmailInput)
                    {
                        duplicate = true;

                    }
                }

                queryResults.Close();//closes connection
                sqlConnect.Close();



                if (duplicate == false)
                {


                    String contactType = HttpUtility.HtmlEncode(DDL2.Text);
                    //inserts values typed by the user into the data base once submit is clicked 
                    if (DDL2.Text == "Other")
                    {
                        contactType = HttpUtility.HtmlEncode(otherBox.Text);
                    }

                    String sqlQuery1 = "Insert into Customer (CustomerName, CustomerPhone, CustomerEmail, CustomerPhoneType, CustomerFoundUsBy, CustomerContactType, ServicedYN) Values (@CustomerName, @CustomerPhone, @CustomerEmail" + ", '" + DDL3.Text + "'," + "@CustomerHear, @ContactType, @n)";
                    SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand1 = new SqlCommand();
                    sqlCommand1.Parameters.AddWithValue("CustomerName", FirstLast);
                    sqlCommand1.Parameters.AddWithValue("CustomerPhone", HttpUtility.HtmlEncode(CustomerPhone.Text));
                    sqlCommand1.Parameters.AddWithValue("CustomerEmail", HttpUtility.HtmlEncode(CustomerEmail.Text));
                    sqlCommand1.Parameters.AddWithValue("CustomerHear", HttpUtility.HtmlEncode(customerHear.Text));
                    sqlCommand1.Parameters.AddWithValue("ContactType", contactType);
                    sqlCommand1.Parameters.AddWithValue("n", '0');



                    sqlCommand1.Connection = sqlConnect1;
                    sqlCommand1.CommandType = CommandType.Text;
                    sqlCommand1.CommandText = sqlQuery1;

                    sqlConnect1.Open();
                    SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();



                    queryResults1.Close();//closes connection
                    sqlConnect1.Close();



                    String sqlQuery2 = "Insert into Login(UserName, Password) Values (@CustomerEmail, @CPassword)";

                    SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);

                    SqlCommand sqlCommand2 = new SqlCommand();

                    String HashPass = PasswordHash.HashPassword(HttpUtility.HtmlEncode(Password.Text));

                    sqlCommand2.Parameters.AddWithValue("CustomerEmail", HttpUtility.HtmlEncode(CustomerEmail.Text));
                    sqlCommand2.Parameters.AddWithValue("CPassword", HashPass);



                    sqlCommand2.Connection = sqlConnect2;
                    sqlCommand2.CommandType = CommandType.Text;
                    sqlCommand2.CommandText = sqlQuery2;

                    sqlConnect2.Open();
                    SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();



                    queryResults2.Close();//closes connection
                    sqlConnect2.Close();


                    Session["UserName"] = HttpUtility.HtmlEncode(CustomerEmail.Text);
                    Response.Redirect("CustomerMainPage.aspx");

                }
                else
                {
                    TestLabel.Text = string.Format("A User with this name and/or Email already exists.");
                }



            }
        }
    }
}