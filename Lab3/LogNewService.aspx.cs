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
    public partial class LogNewService : System.Web.UI.Page
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

            originLabel.Text = string.Format("2139");
            SecondChanged.Text = string.Format("l32432");
            ServiceCost.Text = string.Format("200");
            CompletionDate.Text = string.Format("1/1/21");
            ServiceName.Text = string.Format("A new Service Event");
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {

            originLabel.Text = string.Format("");
            SecondChanged.Text = string.Format("");
            ServiceCost.Text = string.Format("");
            CompletionDate.Text = string.Format("");
            ServiceName.Text = string.Format("");


        }

        protected void MovingRadio_CheckedChanged(object sender, EventArgs e)
        {
            Label4.Text = string.Format("Origin Address");
            Label5.Text = string.Format("Destination Address");
            AuctionRadio.Checked = false;

            ServiceName.Text = string.Format("A new Service Event");
        }

        protected void AuctionRadio_CheckedChanged(object sender, EventArgs e)
        {
            Label4.Text = string.Format("Update Status  ");
            Label5.Text = string.Format("Payment Status      ");
            MovingRadio.Checked = false;

            ServiceName.Text = string.Format("A new Service Event");
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



            String sqlQuery2 = "Select CustomerID FROM Customer WHERE CustomerName = @CustomerName";
            SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Parameters.AddWithValue("CustomerName", HttpUtility.HtmlEncode(custNameLabel.Text));
            sqlCommand2.Connection = sqlConnect2;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuery2;
            String userName = "";
            sqlConnect2.Open();
            SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();
            while (queryResults2.Read())
            {
                userName = (queryResults2["CustomerID"].ToString());
            }
            
                
            queryResults2.Close();//closes connection
            sqlConnect2.Close();


            if (duplicate == false)
            {

                MissingInput.Text = string.Format("");

                DateTime thisDay = DateTime.Today;
                String sqlQuery1 = "";

                //inserts values typed by the user into the data base once submit is clicked 
                //inserts values typed by the user into the data base once submit is clicked 
                if (MovingRadio.Checked)
                {
                    sqlQuery1 = "Insert into Service (CustomerID, ServiceName, ServiceDate, ServiceCost, CompletionDate,  UpdateStatus, PaymentStatus, Origin, Destination) Values (@CustomerID, @ServiceName, @ServiceDate, @ServiceCost, @CompletionDate, '" + null + "', '" + null + "',  @FirstChanged, @SecondChanged)";
                }
                if (!MovingRadio.Checked)
                {
                    sqlQuery1 = "Insert into Service (CustomerID, ServiceName, ServiceDate, ServiceCost, CompletionDate,  UpdateStatus, PaymentStatus, Origin, Destination) Values (@CustomerID, @ServiceName, @ServiceDate, @ServiceCost, @CompletionDate, @FirstChanged.Text,  @SecondChanged.Text, + ', '" + null + "', '" + null + "')";
                }

                SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommand1 = new SqlCommand();
                sqlCommand1.Connection = sqlConnect1;
                sqlCommand1.CommandType = CommandType.Text;
                sqlCommand1.CommandText = sqlQuery1;

              
                
                sqlCommand1.Parameters.AddWithValue("CustomerID", 1);
                sqlCommand1.Parameters.AddWithValue("ServiceName", HttpUtility.HtmlEncode(ServiceName.Text));
                sqlCommand1.Parameters.AddWithValue("ServiceDate", thisDay);
                sqlCommand1.Parameters.AddWithValue("ServiceCost", HttpUtility.HtmlEncode(ServiceCost.Text));
                sqlCommand1.Parameters.AddWithValue("CompletionDate", HttpUtility.HtmlEncode(CompletionDate.Text));
                sqlCommand1.Parameters.AddWithValue("FirstChanged", HttpUtility.HtmlEncode(originLabel.Text));
                sqlCommand1.Parameters.AddWithValue("SecondChanged", HttpUtility.HtmlEncode(SecondChanged.Text));

                sqlConnect1.Open();
                SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();


                queryResults1.Close();//closes connection
                sqlConnect1.Close();






                //wills code VVVV

                String sqlQuery4 = "Select EmployeeID FROM Employee WHERE EmployeeName = UserName";

                SqlConnection sqlConnect4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand4 = new SqlCommand();
                sqlCommand4.Parameters.AddWithValue("userName", HttpUtility.HtmlEncode(Session["UserName"].ToString()));
                sqlCommand4.Connection = sqlConnect4;
                sqlCommand4.CommandType = CommandType.Text;
                sqlCommand4.CommandText = sqlQuery4;


                sqlConnect4.Open();

                SqlDataReader queryResults4 = sqlCommand4.ExecuteReader();
                String empID = "";
                //retrieve values taken from the database
                while (queryResults4.Read())
                {
                    empID = queryResults4["EmployeeID"].ToString();
                }

                queryResults4.Close();//closes connection
                sqlConnect4.Close();



                String sqlQuery3 = "Select ServiceID FROM service WHERE ServiceName = @serviceName";

                SqlConnection sqlConnect3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand3 = new SqlCommand();
                sqlCommand3.Parameters.AddWithValue("serviceName", HttpUtility.HtmlEncode(ServiceName.Text));
                sqlCommand3.Connection = sqlConnect3;
                sqlCommand3.CommandType = CommandType.Text;
                sqlCommand3.CommandText = sqlQuery3;


                sqlConnect3.Open();

                SqlDataReader queryResults3 = sqlCommand3.ExecuteReader();

                //retrieve values taken from the database
                String servID = "";
                while (queryResults3.Read())
                {
                    servID = queryResults3["ServiceID"].ToString();
                }

                queryResults3.Close();//closes connection
                sqlConnect3.Close();

                String sqlQuery5 = "Insert into Workflow (EmployeeID, ServiceID, StartDate, EndDate, Status) Values ('" + empID + "', '" + servID + "', '" + thisDay + "', '" + thisDay + "', 'Customer Service')";

                SqlConnection sqlConnect5 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand5 = new SqlCommand();
                sqlCommand5.Connection = sqlConnect5;
                sqlCommand5.CommandType = CommandType.Text;
                sqlCommand5.CommandText = sqlQuery5;

                sqlConnect5.Open();
                SqlDataReader queryResults5 = sqlCommand5.ExecuteReader();


                queryResults5.Close();//closes connection
                sqlConnect5.Close();



                TestLabel.Text = string.Format("Successfully inserted into database.");


            }
            else
            {
                TestLabel.Text = string.Format("A Service with this name already exists");
            }



            }
        }

    }

