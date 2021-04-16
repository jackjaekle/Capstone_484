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
    public partial class AddServiceByPhone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String customerName = HttpUtility.HtmlEncode(Request.QueryString["sendName"]);
                custNameLabel.Text = customerName;
                

                String sqlQuery2 = "Select CustomerCurrentAddress FROM Customer WHERE CustomerName = '" + customerName + "'";
                SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand2 = new SqlCommand();
                sqlCommand2.Connection = sqlConnect2;
                sqlCommand2.CommandType = CommandType.Text;
                sqlCommand2.CommandText = sqlQuery2;
                String orgAddress = "";
                sqlConnect2.Open();
                SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();
                while (queryResults2.Read())
                {
                    orgAddress = (queryResults2["CustomerCurrentAddress"].ToString());
                }


                queryResults2.Close();//closes connection
                sqlConnect2.Close();

                originLabel.Text = orgAddress;


            }

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
            //Label4.Text = string.Format("Update Status  ");
            //originLabel.Visible = false;
            //Label4.Visible = false;
            Label5.Visible = false;
            MovingRadio.Checked = false;
            SecondChanged.Visible = false;
            SecondChanged.Text = "null";

            //ServiceName.Text = string.Format("A new Service Event");
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
                String sqlQuery11 = "";

                //inserts values typed by the user into the data base once submit is clicked 
                //inserts values typed by the user into the data base once submit is clicked 
                if (MovingRadio.Checked)
                {
                    sqlQuery1 = "Insert into Service (CustomerID, ServiceName, ServiceDate, ServiceCost, CompletionDate,  UpdateStatus, PaymentStatus, Origin, Destination) Values (@CustomerID, @ServiceName, @ServiceDate, @ServiceCost, @CompletionDate, '" + null + "', '" + null + "',  @FirstChanged, @SecondChanged)";
                    sqlQuery11 = "Update Customer Set MoveCreateYN = '0' WHERE CustomerID = @CustomerID";
                }
                if (!MovingRadio.Checked)
                {
                    sqlQuery1 = "Insert into Service (CustomerID, ServiceName, ServiceDate, ServiceCost, CompletionDate,  UpdateStatus, PaymentStatus, Origin, Destination) Values (@CustomerID, @ServiceName, @ServiceDate, @ServiceCost, @CompletionDate,  '" + null + "', '" + null + "', @FirstChanged,'" + null + "')";
                    sqlQuery11 = "Update Service set AuctionedYN = '0' WHERE ServiceID = @ServiceID";
                }

                SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommand1 = new SqlCommand();
                sqlCommand1.Connection = sqlConnect1;
                sqlCommand1.CommandType = CommandType.Text;
                sqlCommand1.CommandText = sqlQuery1;



                sqlCommand1.Parameters.AddWithValue("CustomerID", userName);
                sqlCommand1.Parameters.AddWithValue("ServiceName", HttpUtility.HtmlEncode(ServiceName.Text));
                sqlCommand1.Parameters.AddWithValue("ServiceDate", startDate.Text);
                sqlCommand1.Parameters.AddWithValue("ServiceCost", HttpUtility.HtmlEncode(ServiceCost.Text));
                sqlCommand1.Parameters.AddWithValue("CompletionDate", HttpUtility.HtmlEncode(CompletionDate.Text));
                sqlCommand1.Parameters.AddWithValue("FirstChanged", HttpUtility.HtmlEncode(originLabel.Text));
                sqlCommand1.Parameters.AddWithValue("SecondChanged", HttpUtility.HtmlEncode(SecondChanged.Text));

                sqlConnect1.Open();
                SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();


                queryResults1.Close();//closes connection
                sqlConnect1.Close();


                String sqlQuery12 = "Select ServiceID FROM Service WHERE ServiceName = @ServiceName";
                SqlConnection sqlConnect12 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand12 = new SqlCommand();
                sqlCommand12.Connection = sqlConnect12;
                sqlCommand12.CommandType = CommandType.Text;
                sqlCommand12.CommandText = sqlQuery12;
                sqlCommand12.Parameters.AddWithValue("ServiceName", HttpUtility.HtmlEncode(ServiceName.Text));

                sqlConnect12.Open();
                SqlDataReader queryResults12 = sqlCommand12.ExecuteReader();

                String ServiceID = "";
                while (queryResults12.Read())
                {
                    ServiceID = queryResults12["ServiceID"].ToString();
                }
                queryResults12.Close();//closes connection
                sqlConnect12.Close();


                SqlConnection sqlConnect11 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommand11 = new SqlCommand();
                sqlCommand11.Connection = sqlConnect11;
                sqlCommand11.CommandType = CommandType.Text;
                sqlCommand11.CommandText = sqlQuery11;



                sqlCommand11.Parameters.AddWithValue("CustomerID", userName);
                sqlCommand11.Parameters.AddWithValue("ServiceID", ServiceID);
                sqlConnect11.Open();
                SqlDataReader queryResults11 = sqlCommand11.ExecuteReader();

                    queryResults11.Close();//closes connection
                    sqlConnect11.Close();


                    //wills code VVVV

                    String sqlQuery4 = "Select EmployeeID FROM Employee WHERE EmployeeEmail = @userName";

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

                String sqlQuery5 = "Insert into Workflow (EmployeeID, ServiceID, StartDate, EndDate, Status) Values ('" + empID + "', '" + servID + "', '" + thisDay + "', '" + thisDay + "', 'Added service to Customer account')";

                SqlConnection sqlConnect5 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand5 = new SqlCommand();
                sqlCommand5.Connection = sqlConnect5;
                sqlCommand5.CommandType = CommandType.Text;
                sqlCommand5.CommandText = sqlQuery5;

                sqlConnect5.Open();
                SqlDataReader queryResults5 = sqlCommand5.ExecuteReader();


                queryResults5.Close();//closes connection
                sqlConnect5.Close();



                //wills part i need to integrate

                string serviceType = "";
                if (MovingRadio.Checked)
                {
                    serviceType = "Moving";
                }
                else
                {
                    serviceType = "Auction";
                }

                String sqlQuery8 = "Update Customer Set typeOfService = @servType,  ServiceDate = @reqDate, DateOfServiceRequest = @SDate WHERE CustomerID = @custID";
                SqlConnection sqlConnect8 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand8 = new SqlCommand();
                sqlCommand8.Parameters.AddWithValue("servType", serviceType);
                sqlCommand8.Parameters.AddWithValue("reqDate", HttpUtility.HtmlEncode(startDate.Text));
                sqlCommand8.Parameters.AddWithValue("SDate", DateTime.UtcNow);
                sqlCommand8.Parameters.AddWithValue("custID", userName);
                sqlCommand8.Connection = sqlConnect8;
                sqlCommand8.CommandType = CommandType.Text;
                sqlCommand8.CommandText = sqlQuery8;

                sqlConnect8.Open();
                SqlDataReader queryResults8 = sqlCommand8.ExecuteReader();



                MissingInput.Text = "Service Request Sent";

                queryResults8.Close();//closes connection
                sqlConnect8.Close();



                TestLabel.Text = string.Format("Successfully inserted into database.");


            }
            else
            {
                TestLabel.Text = string.Format("A Service with this name already exists");
            }



        }
    

}
}