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
    public partial class LogNewCustomer : System.Web.UI.Page
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
            Response.Redirect("LoggedinMainPage.aspx");//links back to main page
        }

        protected void PopulateButton_Click(object sender, EventArgs e)
        {
            CustomerFirstName.Text = string.Format("John");//populates a textbox
            CustomerLastName.Text = string.Format("Jameson");
            CustomerPhone.Text = string.Format("8675309");
            CustomerEmail.Text = string.Format("legitemail@gmail.com");
            customerHear.Text = string.Format("Friend");
            CustomerAddress.Text = string.Format("1875 Main street");
            custNeeds.Text = string.Format("Generic Cust Needs");




        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            CustomerFirstName.Text = string.Format("");//clears a textbox
            CustomerPhone.Text = string.Format("");
            CustomerEmail.Text = string.Format("");
            CustomerLastName.Text = string.Format("");

            customerHear.Text = string.Format("");
            CustomerAddress.Text = string.Format("");
            custNeeds.Text = string.Format("");



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


                String sqlQuery3 = "Select * from Customer";
                SqlConnection sqlConnect3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand3 = new SqlCommand();
                sqlCommand3.Connection = sqlConnect3;
                sqlCommand3.CommandType = CommandType.Text;
                sqlCommand3.CommandText = sqlQuery3;

                sqlConnect3.Open();
                SqlDataReader queryResults3 = sqlCommand3.ExecuteReader();
                string FirstLast = HttpUtility.HtmlEncode(CustomerFirstName.Text) + " " + HttpUtility.HtmlEncode(CustomerLastName.Text);
                String userInput = FirstLast;
                String dbNames = "";
                Boolean duplicate = false;

                while (queryResults3.Read())
                {
                    dbNames = (queryResults3["CustomerName"].ToString());
                    if (dbNames == userInput)
                    {
                        duplicate = true;

                    }
                }

                queryResults3.Close();//closes connection
                sqlConnect3.Close();



                if (duplicate == false)
                {



                    String serviceType2 = "TestFailed";

                    if (MovingRadio.Checked)
                    {
                        serviceType2 = "Moving";
                    }
                    if (!MovingRadio.Checked)
                    {
                        serviceType2 = "Auction";
                    }


                    String contactType = HttpUtility.HtmlEncode(DDL2.Text);
                    //inserts values typed by the user into the data base once submit is clicked 
                    if (DDL2.Text == "Other")
                    {
                        contactType = HttpUtility.HtmlEncode(otherBox.Text);
                    }
                    
                    String sqlQuery11 = "Insert into Customer (CustomerName, CustomerPhone, CustomerEmail, CustomerPhoneType, CustomerFoundUsBy, CustomerContactType, ServicedYN, CustomerCurrentAddress, descriptionOfNeeds, typeOfService, DateOfServiceRequest, Servicedate ) Values (@CustomerName, @CustomerPhone, @CustomerEmail" + ", '" + DDL3.Text + "'," + "@CustomerHear, @ContactType, @n, @cAddress, @Needs, @servType, @SDate, @reqDate)";
                    SqlConnection sqlConnect11 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand11 = new SqlCommand();
                    sqlCommand11.Parameters.AddWithValue("CustomerName",FirstLast);
                    sqlCommand11.Parameters.AddWithValue("CustomerPhone", HttpUtility.HtmlEncode(CustomerPhone.Text));
                    sqlCommand11.Parameters.AddWithValue("CustomerEmail", HttpUtility.HtmlEncode(CustomerEmail.Text));
                    sqlCommand11.Parameters.AddWithValue("CustomerHear", HttpUtility.HtmlEncode(customerHear.Text));
                    sqlCommand11.Parameters.AddWithValue("ContactType", contactType);
                    sqlCommand11.Parameters.AddWithValue("n", "0");
                    sqlCommand11.Parameters.AddWithValue("cAddress", HttpUtility.HtmlEncode(CustomerAddress.Text));
                    sqlCommand11.Parameters.AddWithValue("Needs", HttpUtility.HtmlEncode(custNeeds.Text));

                    sqlCommand11.Parameters.AddWithValue("SDate", DateTime.UtcNow);
                    sqlCommand11.Parameters.AddWithValue("reqDate", HttpUtility.HtmlEncode(reqDate.Text));
                    sqlCommand11.Parameters.AddWithValue("servType", serviceType2);





                    sqlCommand11.Connection = sqlConnect11;
                    sqlCommand11.CommandType = CommandType.Text;
                    sqlCommand11.CommandText = sqlQuery11;

                    sqlConnect11.Open();
                    SqlDataReader queryResults11 = sqlCommand11.ExecuteReader();



                    queryResults11.Close();//closes connection
                    sqlConnect11.Close();
                    TestLabel1.Text = string.Format("Successfully inserted into database.");
                }
                else
                {
                    TestLabel1.Text = string.Format("A User with this name already exists.");
                }



            }

            String customerEmail = HttpUtility.HtmlEncode(Session["UserName"].ToString());
            String CustomerID = "";

            String sqlQuery1 = "Select CustomerID FROM Customer WHERE CustomerEmail = @email";
            SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Parameters.AddWithValue("email", customerEmail);
            sqlCommand1.Connection = sqlConnect1;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQuery1;
            sqlConnect1.Open();
            SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();
            while (queryResults1.Read())
            {
                CustomerID = (queryResults1["CustomerID"].ToString());
            }




            queryResults1.Close();
            sqlConnect1.Close();


            String serviceType = "TestFailed";

            if (MovingRadio.Checked)
            {
                serviceType = "Moving";
            }
            if (!MovingRadio.Checked)
            {
                serviceType = "Auction";
            }
            String sqlQuery = "Update Customer Set typeOfService = @servType,  ServiceDate = @reqDate,  descriptionOfNeeds = @descNeeds, CustomerCurrentAddress = @servAdd, DateOfServiceRequest = @SDate, ServicedYN = @0 WHERE CustomerID = @custID";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("servType", serviceType);
            sqlCommand.Parameters.AddWithValue("reqDate", HttpUtility.HtmlEncode(reqDate.Text));
            sqlCommand.Parameters.AddWithValue("descNeeds", HttpUtility.HtmlEncode(descOfNeeds.Text));
            sqlCommand.Parameters.AddWithValue("custID", CustomerID);
            sqlCommand.Parameters.AddWithValue("servAdd", HttpUtility.HtmlEncode(servAddress.Text));
            sqlCommand.Parameters.AddWithValue("SDate", DateTime.UtcNow);
            sqlCommand.Parameters.AddWithValue("0", '0');
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();



            MissingInput.Text = "Service Request Sent";

            queryResults.Close();//closes connection
            sqlConnect.Close();
        }
        protected void MovingRadio_CheckedChanged(object sender, EventArgs e)
        {
            AuctionRadio.Checked = false;
        }

        protected void AuctionRadio_CheckedChanged(object sender, EventArgs e)
        {

            MovingRadio.Checked = false;

        }
     

        protected void Upload_Click(object sender, EventArgs e)
        {

            String customerEmail = HttpUtility.HtmlEncode(Session["UserName"].ToString());
            String CustomerID = "";

            String sqlQuery1 = "Select CustomerID FROM Customer WHERE CustomerEmail = @email";
            SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Parameters.AddWithValue("email", customerEmail);
            sqlCommand1.Connection = sqlConnect1;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQuery1;
            sqlConnect1.Open();
            SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();
            while (queryResults1.Read())
            {
                CustomerID = (queryResults1["CustomerID"].ToString());
            }
            queryResults1.Close();





            if (uploadFiles.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in uploadFiles.PostedFiles)
                {
                    uploadedFile.SaveAs(Server.MapPath("/images/" + uploadedFile.FileName));


                    String sqlQuery = "Insert into Images values(@imgName, @custID)";
                    SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Parameters.AddWithValue("imgName", uploadedFile.FileName);
                    sqlCommand.Parameters.AddWithValue("custID", CustomerID);

                    sqlCommand.Connection = sqlConnect;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = sqlQuery;
                    sqlConnect.Open();
                    SqlDataReader queryResults = sqlCommand.ExecuteReader();
                    queryResults.Close();
                    sqlConnect.Close();

                }
            }

        }

    }
    }
