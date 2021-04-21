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
    public partial class LoggedCustServAuction : System.Web.UI.Page
    {

        String CustomerAddress = "";
        String CustomerPhone = "";
        String StartingDate = "";

        protected void Page_Load(object sender, EventArgs e)
        {



            if (custRequest.Items.Count == 0)
            {
                String customerName = HttpUtility.HtmlEncode(Request.QueryString["SendCustName"]);
                custNameLabel.Text = customerName;

                //orgin, phone, cust request need to autofill

                String sqlQuery = "Select CustomerPhone, descriptionOfNeeds, CustomerCurrentAddress,  Servicedate FROM Customer WHERE CustomerName = @CustomerName";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                String n = "0";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.AddWithValue("CustomerName", customerName);
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    custRequest.Items.Add(queryResults["descriptionOfNeeds"].ToString());
                    CustomerAddress = (queryResults["CustomerCurrentAddress"].ToString());
                    CustomerPhone = (queryResults["CustomerPhone"].ToString());
                    StartingDate = (queryResults["Servicedate"].ToString());

                }



                queryResults.Close();
                sqlConnect.Close();


                custPhone.Text = CustomerPhone;
                originLabel.Text = CustomerAddress;
                startDate.Text = StartingDate;

            }
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx");//links back to main page
        }


        protected void Submit_Click(object sender, EventArgs e)
        {
            String sqlQuery = "Select ServiceName FROM Service WHERE ServiceID = ServiceID";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            String userInput = HttpUtility.HtmlEncode(ServiceName.Text);
            String dbNames = "";
            Boolean duplicate = false;

            while (queryResults.Read())
            {
                dbNames = (queryResults["ServiceName"].ToString());
                if (dbNames == userInput)
                {
                    duplicate = true;
                }
            }

            queryResults.Close();//closes connection
            sqlConnect.Close();



            String sqlQuery2 = "Select CustomerID FROM Customer WHERE CustomerName = @cName";
            SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            String customerName = HttpUtility.HtmlEncode(custNameLabel.Text);

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Parameters.AddWithValue("cName", customerName);
            sqlCommand2.Connection = sqlConnect2;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuery2;

            sqlConnect2.Open();
            SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();
            while (queryResults2.Read())
            {
                String customerID = (queryResults2["CustomerID"].ToString());
            }


            queryResults2.Close();//closes connection
            sqlConnect2.Close();


            if (duplicate == false)
            {
                String sqlQuery3 = "Select CustomerID FROM Customer WHERE CustomerName = @cName";
                SqlConnection sqlConnect3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                String customerName1 = HttpUtility.HtmlEncode(custNameLabel.Text);

                SqlCommand sqlCommand3 = new SqlCommand();
                sqlCommand3.Parameters.AddWithValue("cName", customerName1);
                sqlCommand3.Connection = sqlConnect3;
                sqlCommand3.CommandType = CommandType.Text;
                sqlCommand3.CommandText = sqlQuery3;
                int customerID;
                sqlConnect3.Open();

                customerID = Convert.ToInt32(sqlCommand3.ExecuteScalar());



                sqlConnect3.Close();

                MissingInput.Text = string.Format("");

                DateTime thisDay = DateTime.Today;
                String sqlQuery1 = "";

                //inserts values typed by the user into the data base once submit is clicked 

                sqlQuery1 = "Insert into Service (CustomerID, ServiceName, ServiceDate, ServiceCost, CompletionDate,  UpdateStatus, PaymentStatus, Origin, AuctionedYN, Destination) Values (@customerID, @ServiceName, @ServiceDate, @ServiceCost, @CompletionDate, @null, @null,  @FirstChanged, @n ,'" + null  + "')";



                SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand1 = new SqlCommand();
                sqlCommand1.Connection = sqlConnect1;
                sqlCommand1.CommandType = CommandType.Text;
                sqlCommand1.CommandText = sqlQuery1;




                sqlCommand1.Parameters.AddWithValue("customerID", customerID);
                sqlCommand1.Parameters.AddWithValue("ServiceName", HttpUtility.HtmlEncode(ServiceName.Text));
                sqlCommand1.Parameters.AddWithValue("ServiceDate", HttpUtility.HtmlEncode(startDate.Text));
                sqlCommand1.Parameters.AddWithValue("ServiceCost", HttpUtility.HtmlEncode(ServiceCost.Text));
                sqlCommand1.Parameters.AddWithValue("CompletionDate", HttpUtility.HtmlEncode(CompletionDate.Text));
                sqlCommand1.Parameters.AddWithValue("FirstChanged", HttpUtility.HtmlEncode(originLabel.Text));
                sqlCommand1.Parameters.AddWithValue("n", "0");
                sqlCommand1.Parameters.AddWithValue("null", "");




                sqlCommand1.Connection = sqlConnect1;
                sqlCommand1.CommandType = CommandType.Text;
                sqlCommand1.CommandText = sqlQuery1;

                sqlConnect1.Open();
                SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();


                queryResults1.Close();//closes connection
                sqlConnect1.Close();



                String sqlQuery10 = "Update Customer set Servicedate = @servDate WHERE CustomerID = @CustomerID";

                SqlConnection sqlConnect10 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand10 = new SqlCommand();
                sqlCommand10.Parameters.AddWithValue("servDate", HttpUtility.HtmlEncode(startDate.Text));
                sqlCommand10.Parameters.AddWithValue("CustomerID", customerID);
                sqlCommand10.Connection = sqlConnect10;
                sqlCommand10.CommandType = CommandType.Text;
                sqlCommand10.CommandText = sqlQuery10;


                sqlConnect10.Open();

                SqlDataReader queryResults10 = sqlCommand10.ExecuteReader();

                queryResults10.Close();//closes connection
                sqlConnect10.Close();

                //wills code VVVV

                String sqlQuery4 = "Select EmployeeID FROM Employee WHERE EmployeeEmail = @userName";

                SqlConnection sqlConnect4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand4 = new SqlCommand();
                sqlCommand4.Parameters.AddWithValue("userName", Session["UserName"].ToString());
                sqlCommand4.Connection = sqlConnect4;
                sqlCommand4.CommandType = CommandType.Text;
                sqlCommand4.CommandText = sqlQuery4;


                sqlConnect4.Open();

                int empID;


                empID = Convert.ToInt32(sqlCommand4.ExecuteScalar());

                sqlConnect4.Close();



                String sqlQuery9 = "Select ServiceID FROM service WHERE ServiceName = @ServiceName";

                SqlConnection sqlConnect9 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommand9 = new SqlCommand();
                sqlCommand9.Parameters.AddWithValue("ServiceName", HttpUtility.HtmlEncode(ServiceName.Text));
                sqlCommand9.Connection = sqlConnect9;
                sqlCommand9.CommandType = CommandType.Text;
                sqlCommand9.CommandText = sqlQuery9;


                sqlConnect9.Open();
                int servID;

                servID = Convert.ToInt32(sqlCommand9.ExecuteScalar());

                sqlConnect9.Close();

                String sqlQuery5 = "Insert into Workflow (EmployeeID, ServiceID, StartDate, EndDate, Status) Values (@empID, @servID, @thisDay, @compDay, 'Customer Service')";

                SqlConnection sqlConnect5 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand5 = new SqlCommand();
                sqlCommand5.Parameters.AddWithValue("empID", empID);
                sqlCommand5.Parameters.AddWithValue("servID", servID);
                sqlCommand5.Parameters.AddWithValue("thisDay", thisDay);
                sqlCommand5.Parameters.AddWithValue("compDay", HttpUtility.HtmlEncode(CompletionDate.Text));
                sqlCommand5.Connection = sqlConnect5;
                sqlCommand5.CommandType = CommandType.Text;
                sqlCommand5.CommandText = sqlQuery5;

                sqlConnect5.Open();
                SqlDataReader queryResults5 = sqlCommand5.ExecuteReader();


                queryResults5.Close();//closes connection
                sqlConnect5.Close();


                String sqlQuery6 = "Update Customer Set ServicedYN = @y WHERE CustomerID = @custID";

                SqlConnection sqlConnect6 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand6 = new SqlCommand();
                sqlCommand6.Parameters.AddWithValue("y", 1);
                sqlCommand6.Parameters.AddWithValue("custID", customerID);

                sqlCommand6.Connection = sqlConnect6;
                sqlCommand6.CommandType = CommandType.Text;
                sqlCommand6.CommandText = sqlQuery6;

                sqlConnect6.Open();
                SqlDataReader queryResults6 = sqlCommand6.ExecuteReader();


                queryResults6.Close();//closes connection
                sqlConnect6.Close();



                TestLabel.Text = string.Format("Successfully inserted into database.");


            }
            else
            {
                TestLabel.Text = string.Format("A Service with this name already exists");
            }



        }
    }

}

