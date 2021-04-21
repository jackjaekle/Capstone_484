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
    public partial class LogAvailableAuctions : System.Web.UI.Page
    {

        String auctionName = "";
        String auctionDate = "";



        protected void Page_Load(object sender, EventArgs e)
        {
            MissingText.Visible = false;


            if (auctionDDL.Items.Count == 0)
            {
                String customerName = HttpUtility.HtmlEncode(Request.QueryString["SendCustName"]);
                custName.Value = customerName;
                string nothing = "";
                auctionDDL.Items.Add(nothing);
                //This block of code fills a dropdown list with the info it needs
                String sqlQuery = "Select AuctionName, AuctionDate FROM AuctionEvent WHERE ServiceID = @0 AND ItemID = @0";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.AddWithValue("0", '0');
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                string thisdate = DateTime.Now.ToString("yyyy-MM-dd");
                SqlDataReader queryResults = sqlCommand.ExecuteReader();

                while (queryResults.Read())
                {
                    auctionDate = queryResults["AuctionDate"].ToString();
                    String testhold = queryResults["AuctionName"].ToString();
                    if (DateTime.Parse(thisdate) < DateTime.Parse(auctionDate))
                    {
                        auctionName = testhold;
                        auctionDDL.Items.Add(auctionName);
                    }
                }
                queryResults.Close();
                sqlConnect.Close();

                //sql to pull up a list of customer names with the "n" for if they have been serviced
                //make the n be autofilled for new customers



                //populates the equip and emp pages.

                //need to import the start and end dates for the service selected. need to select the auction service for the specific customer


                String sqlQuery2 = "Select s.ServiceDate, s.CompletionDate from Service s, Customer c WHERE s.CustomerID = c.CustomerID AND c.CustomerName = @customer AND AuctionedYN =0 ";
                SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand2 = new SqlCommand();
                sqlCommand2.Parameters.AddWithValue("customer", custName.Value);
                sqlCommand2.Connection = sqlConnect2;
                sqlCommand2.CommandType = CommandType.Text;
                sqlCommand2.CommandText = sqlQuery2;
                sqlConnect2.Open();
                SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();
                string startDate = "";
                string endDate = "";

                while (queryResults2.Read())
                {
                    startDate = queryResults2["ServiceDate"].ToString();
                    endDate = queryResults2["CompletionDate"].ToString();

                }

                DateTime.Now.ToString("yyyyMMdd");
                DateTime serviceStart = DateTime.Parse(startDate);
                DateTime serviceEnd = DateTime.Parse(endDate);



                String sqlQuery3 = "Select w.EmployeeID from Workflow w, Employee e WHERE e.EmployeeStatus Like @hired and w.EmployeeID = e.EmployeeID ";
                SqlConnection sqlConnect3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand3 = new SqlCommand();
                sqlCommand3.Parameters.AddWithValue("hired", "Hired");
                sqlCommand3.Connection = sqlConnect3;
                sqlCommand3.CommandType = CommandType.Text;
                sqlCommand3.CommandText = sqlQuery3;
                sqlConnect3.Open();
                SqlDataReader queryResults3 = sqlCommand3.ExecuteReader();
                int i = 0; //is the max employee id
                while (queryResults3.Read())
                {
                    string holder = queryResults3["EmployeeID"].ToString();
                    int x = int.Parse(holder);
                    if (x > i)
                    {
                        i = x;
                    }
                }



                empAvail.Items.Clear();
                for (int f = 1; f <= i; f++) //make it so that it goes by specific employee numbers
                {

                    Boolean dateTest = false;
                    //make a query that pulls every single date and time that the employee is associated with from the workflow
                    //everytime a new one is added
                    String sqlQuery4 = "Select e.EmployeeName, w.StartDate, w.EndDate, e.EmployeeID from Employee e, Workflow w WHERE e.EmployeeID = w.EmployeeID AND w.EmployeeID = @empid";
                    SqlConnection sqlConnect4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                    SqlCommand sqlCommand4 = new SqlCommand();
                    sqlCommand4.Parameters.AddWithValue("empid", f);
                    sqlCommand4.Connection = sqlConnect4;
                    sqlCommand4.CommandType = CommandType.Text;
                    sqlCommand4.CommandText = sqlQuery4;
                    sqlConnect4.Open();
                    SqlDataReader queryResults4 = sqlCommand4.ExecuteReader();
                    List<DateTime> startDates = new List<DateTime>();
                    List<DateTime> endDates = new List<DateTime>();
                    String empName = "";
                    while (queryResults4.Read())
                    {
                        empName = queryResults4["EmployeeName"].ToString();
                        startDates.Add(DateTime.Parse(queryResults4["StartDate"].ToString()));
                        endDates.Add(DateTime.Parse(queryResults4["EndDate"].ToString()));
                    }
                    for (int L = 0; L < startDates.Count; L++) //this loops for however many different workflows an employee is assigned to
                    {
                        bool overlap = serviceStart <= endDates[L] && startDates[L] <= serviceEnd;

                        if (overlap == true)
                        {
                            dateTest = true; //sets the intersection to true
                        }

                    }
                    if (dateTest == false) //if the intersection isnt true it displays the name
                    {

                        if (empAvail.Items.Contains(new ListItem(empName))) //this makes sure it doesnt display the emp name multiple times, as it pulls each empid multiple times from the workflow
                        {
                            //do nothing
                        }
                        else
                        {
                            empAvail.Items.Add(empName);
                        }
                    }
                    queryResults4.Close();
                    sqlConnect4.Close();
                }
                queryResults3.Close();
                sqlConnect3.Close();




                String sqlQuery13 = "Select EquipmentID from EquipmentRent";
                SqlConnection sqlConnect13 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand13 = new SqlCommand();
                sqlCommand13.Connection = sqlConnect13;
                sqlCommand13.CommandType = CommandType.Text;
                sqlCommand13.CommandText = sqlQuery13;
                sqlConnect13.Open();
                SqlDataReader queryResults13 = sqlCommand13.ExecuteReader();
                int M = 0; //is the max equipment
                while (queryResults13.Read())
                {
                    string holder1 = queryResults13["EquipmentID"].ToString();
                    int t = int.Parse(holder1);
                    if (t > M)
                    {
                        M = t;
                    }
                }
                DateTime.Now.ToString("yyyyMMdd");
                DateTime serviceStart1 = DateTime.Parse(startDate);
                DateTime serviceEnd1 = DateTime.Parse(endDate);

                equipAvail.Items.Clear();
                for (int H = 1; H <= M; H++) //make it so that it goes by specific employee numbers
                {

                    Boolean dateTest1 = false;
                    //make a query that pulls every single date and time that the employee is associated with from the workflow
                    //everytime a new one is added
                    String sqlQuery14 = "Select e.EquipmentName, w.RentDate, w.ReturnDate, e.EquipmentID from Equipment e, EquipmentRent w WHERE e.EquipmentID = w.EquipmentID AND w.EquipmentID = @eqpid AND w.RentDate IS NOT NUll";
                    SqlConnection sqlConnect14 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                    SqlCommand sqlCommand14 = new SqlCommand();
                    sqlCommand14.Parameters.AddWithValue("eqpid", H);
                    sqlCommand14.Connection = sqlConnect14;
                    sqlCommand14.CommandType = CommandType.Text;
                    sqlCommand14.CommandText = sqlQuery14;
                    sqlConnect14.Open();
                    SqlDataReader queryResults14 = sqlCommand14.ExecuteReader();
                    List<DateTime> startDates1 = new List<DateTime>();
                    List<DateTime> endDates1 = new List<DateTime>();
                    String eqpName = "";
                    while (queryResults14.Read())
                    {

                        eqpName = queryResults14["EquipmentName"].ToString();
                        startDates1.Add(DateTime.Parse(queryResults14["RentDate"].ToString()));
                        endDates1.Add(DateTime.Parse(queryResults14["ReturnDate"].ToString()));

                    }
                    for (int Y = 0; Y < startDates1.Count; Y++) //this loops for however many different workflows an employee is assigned to
                    {
                        bool overlap1 = serviceStart1 <= endDates1[Y] && startDates1[Y] <= serviceEnd1;

                        if (overlap1 == true)
                        {
                            dateTest1 = true; //sets the intersection to true
                        }

                    }
                    if (dateTest1 == false) //if the intersection isnt true it displays the name
                    {
                        if (equipAvail.Items.Contains(new ListItem(eqpName))) //this makes sure it doesnt display the eqp name multiple times, as it pulls each eqp multiple times from the eqp rent table
                        {
                            //do nothing
                        }
                        else
                        {
                            if (eqpName != "")
                            {
                                equipAvail.Items.Add(eqpName);
                            }

                        }
                    }
                    queryResults14.Close();
                    sqlConnect14.Close();

                    queryResults13.Close();
                    sqlConnect13.Close();
                }












            }
        }


        protected void auctionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {


            String sqlQuery1 = "Select AuctionLocation, AuctionDate FROM AuctionEvent WHERE AuctionName = @aucName AND ServiceID = @0 AND ItemID = @0";
            SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Parameters.AddWithValue("aucName", HttpUtility.HtmlEncode(auctionDDL.SelectedValue));
            sqlCommand1.Parameters.AddWithValue("0", '0');
            sqlCommand1.Connection = sqlConnect1;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQuery1;
            string thisdate = DateTime.Now.ToString("yyyy-MM-dd");
            sqlConnect1.Open();

            SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();
            while (queryResults1.Read())

            {

                String auctionDate = queryResults1["AuctionDate"].ToString();

                if (DateTime.Parse(thisdate) < DateTime.Parse(auctionDate))
                {
                    auctLocation.Value = queryResults1["AuctionLocation"].ToString();
                    AuctionStart.Value = queryResults1["AuctionDate"].ToString();
                }

            }



            queryResults1.Close();
            sqlConnect1.Close();



            String sqlQuery2 = "Select s.ServiceDate, s.CompletionDate from Service s, Customer c WHERE s.CustomerID = c.CustomerID AND c.CustomerName = @customer AND AuctionedYN =0 ";
            SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Parameters.AddWithValue("customer", custName.Value);
            sqlCommand2.Connection = sqlConnect2;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuery2;
            sqlConnect2.Open();
            SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();
            string startDate = "";
            string endDate = "";

            while (queryResults2.Read())
            {
                startDate = queryResults2["ServiceDate"].ToString();
                endDate = queryResults2["CompletionDate"].ToString();

            }

            DateTime.Now.ToString("yyyyMMdd");
            DateTime serviceStart = DateTime.Parse(startDate);
            DateTime serviceEnd = DateTime.Parse(endDate);



            String sqlQuery3 = "Select w.EmployeeID from Workflow w, Employee e WHERE e.EmployeeStatus Like @hired and w.EmployeeID = e.EmployeeID ";
            SqlConnection sqlConnect3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand3 = new SqlCommand();
            sqlCommand3.Parameters.AddWithValue("hired", "Hired");
            sqlCommand3.Connection = sqlConnect3;
            sqlCommand3.CommandType = CommandType.Text;
            sqlCommand3.CommandText = sqlQuery3;
            sqlConnect3.Open();
            SqlDataReader queryResults3 = sqlCommand3.ExecuteReader();
            int i = 0; //is the max employee id
            while (queryResults3.Read())
            {
                string holder = queryResults3["EmployeeID"].ToString();
                int x = int.Parse(holder);
                if (x > i)
                {
                    i = x;
                }
            }



            empAvail.Items.Clear();
            for (int f = 1; f <= i; f++) //make it so that it goes by specific employee numbers
            {

                Boolean dateTest = false;
                //make a query that pulls every single date and time that the employee is associated with from the workflow
                //everytime a new one is added
                String sqlQuery4 = "Select e.EmployeeName, w.StartDate, w.EndDate, e.EmployeeID from Employee e, Workflow w WHERE e.EmployeeID = w.EmployeeID AND w.EmployeeID = @empid";
                SqlConnection sqlConnect4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommand4 = new SqlCommand();
                sqlCommand4.Parameters.AddWithValue("empid", f);
                sqlCommand4.Connection = sqlConnect4;
                sqlCommand4.CommandType = CommandType.Text;
                sqlCommand4.CommandText = sqlQuery4;
                sqlConnect4.Open();
                SqlDataReader queryResults4 = sqlCommand4.ExecuteReader();
                List<DateTime> startDates = new List<DateTime>();
                List<DateTime> endDates = new List<DateTime>();
                String empName = "";
                while (queryResults4.Read())
                {
                    empName = queryResults4["EmployeeName"].ToString();
                    startDates.Add(DateTime.Parse(queryResults4["StartDate"].ToString()));
                    endDates.Add(DateTime.Parse(queryResults4["EndDate"].ToString()));
                }
                for (int L = 0; L < startDates.Count; L++) //this loops for however many different workflows an employee is assigned to
                {
                    bool overlap = serviceStart <= endDates[L] && startDates[L] <= serviceEnd;

                    if (overlap == true)
                    {
                        dateTest = true; //sets the intersection to true
                    }

                }
                if (dateTest == false) //if the intersection isnt true it displays the name
                {

                    if (empAvail.Items.Contains(new ListItem(empName))) //this makes sure it doesnt display the emp name multiple times, as it pulls each empid multiple times from the workflow
                    {
                        //do nothing
                    }
                    else
                    {
                        empAvail.Items.Add(empName);
                    }
                }
                queryResults4.Close();
                sqlConnect4.Close();
            }
            queryResults3.Close();
            sqlConnect3.Close();




            String sqlQuery13 = "Select EquipmentID from EquipmentRent";
            SqlConnection sqlConnect13 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand13 = new SqlCommand();
            sqlCommand13.Connection = sqlConnect13;
            sqlCommand13.CommandType = CommandType.Text;
            sqlCommand13.CommandText = sqlQuery13;
            sqlConnect13.Open();
            SqlDataReader queryResults13 = sqlCommand13.ExecuteReader();
            int M = 0; //is the max equipment
            while (queryResults13.Read())
            {
                string holder1 = queryResults13["EquipmentID"].ToString();
                int t = int.Parse(holder1);
                if (t > M)
                {
                    M = t;
                }
            }
            DateTime.Now.ToString("yyyyMMdd");
            DateTime serviceStart1 = DateTime.Parse(startDate);
            DateTime serviceEnd1 = DateTime.Parse(endDate);

            equipAvail.Items.Clear();
            for (int H = 1; H <= M; H++) //make it so that it goes by specific employee numbers
            {

                Boolean dateTest1 = false;
                //make a query that pulls every single date and time that the employee is associated with from the workflow
                //everytime a new one is added
                String sqlQuery14 = "Select e.EquipmentName, w.RentDate, w.ReturnDate, e.EquipmentID from Equipment e, EquipmentRent w WHERE e.EquipmentID = w.EquipmentID AND w.EquipmentID = @eqpid AND w.RentDate IS NOT NUll";
                SqlConnection sqlConnect14 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommand14 = new SqlCommand();
                sqlCommand14.Parameters.AddWithValue("eqpid", H);
                sqlCommand14.Connection = sqlConnect14;
                sqlCommand14.CommandType = CommandType.Text;
                sqlCommand14.CommandText = sqlQuery14;
                sqlConnect14.Open();
                SqlDataReader queryResults14 = sqlCommand14.ExecuteReader();
                List<DateTime> startDates1 = new List<DateTime>();
                List<DateTime> endDates1 = new List<DateTime>();
                String eqpName = "";
                while (queryResults14.Read())
                {

                    eqpName = queryResults14["EquipmentName"].ToString();
                    startDates1.Add(DateTime.Parse(queryResults14["RentDate"].ToString()));
                    endDates1.Add(DateTime.Parse(queryResults14["ReturnDate"].ToString()));

                }
                for (int Y = 0; Y < startDates1.Count; Y++) //this loops for however many different workflows an employee is assigned to
                {
                    bool overlap1 = serviceStart1 <= endDates1[Y] && startDates1[Y] <= serviceEnd1;

                    if (overlap1 == true)
                    {
                        dateTest1 = true; //sets the intersection to true
                    }

                }
                if (dateTest1 == false) //if the intersection isnt true it displays the name
                {
                    if (equipAvail.Items.Contains(new ListItem(eqpName))) //this makes sure it doesnt display the eqp name multiple times, as it pulls each eqp multiple times from the eqp rent table
                    {
                        //do nothing
                    }
                    else
                    {
                        if (eqpName != "")
                        {
                            equipAvail.Items.Add(eqpName);
                        }

                    }
                }
                queryResults14.Close();
                sqlConnect14.Close();

                queryResults13.Close();
                sqlConnect13.Close();
            }








        }


        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }

        protected void servCust_Click(object sender, EventArgs e)
        {

            MissingText.Visible = true;
            String sqlQuery20 = "Select s.ServiceDate, s.CompletionDate from Service s, Customer c WHERE s.CustomerID = c.CustomerID AND c.CustomerName = @customer AND s.Destination IS NULL";
            SqlConnection sqlConnect20 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand20 = new SqlCommand();
            sqlCommand20.Parameters.AddWithValue("customer", custName.Value);
            sqlCommand20.Connection = sqlConnect20;
            sqlCommand20.CommandType = CommandType.Text;
            sqlCommand20.CommandText = sqlQuery20;
            sqlConnect20.Open();
            SqlDataReader queryResults20 = sqlCommand20.ExecuteReader();
            string startDate = "";
            string endDate = "";

            while (queryResults20.Read())
            {
                startDate = queryResults20["ServiceDate"].ToString();
                endDate = queryResults20["CompletionDate"].ToString();

            }





            String sqlQuery9 = "Select s.ServiceID, s.ServiceName, s.CompletionDate FROM Service s, Customer c WHERE c.CustomerName = @CustomerName AND c.CustomerID = s.CustomerID";

            SqlConnection sqlConnect9 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlCommand sqlCommand9 = new SqlCommand();
            sqlCommand9.Parameters.AddWithValue("CustomerName", HttpUtility.HtmlEncode(custName.Value));
            sqlCommand9.Connection = sqlConnect9;
            sqlCommand9.CommandType = CommandType.Text;
            sqlCommand9.CommandText = sqlQuery9;


            sqlConnect9.Open();
            int serviceID;
            String serviceIdHold = "";
            serviceID = Convert.ToInt32(sqlCommand9.ExecuteScalar());
            String completionDate = "";


            SqlDataReader queryResults9 = sqlCommand9.ExecuteReader();

            while (queryResults9.Read())
            {
                serviceID = Convert.ToInt32(queryResults9["ServiceID"].ToString());
                serviceIdHold = queryResults9["ServiceID"].ToString();
                completionDate = queryResults9["CompletionDate"].ToString();

            }

            String customerName = Request.QueryString["SendCustName"];

            String sqlQuery = "Select AuctionID from AuctionEvent Where AuctionName = @auctionName AND ServiceID = @base AND ItemId = @base";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("auctionName", HttpUtility.HtmlEncode(auctionDDL.SelectedValue));
            sqlCommand.Parameters.AddWithValue("base", 0);
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlConnect.Open();
            String AuctionID = "";
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            while (queryResults.Read())
            {
                AuctionID = queryResults["AuctionID"].ToString();
            }
            queryResults.Close();
            sqlConnect.Close();


            String sqlQuery1 = "Select e.ServiceID FROM  Service e, Customer s WHERE s.CustomerName = @custName AND s.CustomerID = e.CustomerID";
            SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Parameters.AddWithValue("custName", HttpUtility.HtmlEncode(custName.Value));
            sqlCommand1.Connection = sqlConnect1;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQuery1;
            string thisdate = DateTime.Now.ToString("yyyy-MM-dd");
            sqlConnect1.Open();
            SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();


            

            try
            {
                while (queryResults1.Read())
                {

                    //String sqlQuery2 = "Insert Into AuctionEvent values (@auctionID, @serviceID, @itemID, @auctionName, @auctionDate, @auctionLocation)";
                    String sqlQuery2 = "Insert Into AuctionEvent values (@auctionID, @serviceID,@itemID, @auctionName, @auctionDate, @auctionLocation)";
                    SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                    SqlCommand sqlCommand2 = new SqlCommand();
                    sqlCommand2.Parameters.AddWithValue("auctionID", AuctionID);
                    sqlCommand2.Parameters.AddWithValue("serviceID", serviceIdHold);
                    sqlCommand2.Parameters.AddWithValue("itemID", "2");
                    sqlCommand2.Parameters.AddWithValue("auctionName", HttpUtility.HtmlEncode(auctionDDL.SelectedValue));
                    sqlCommand2.Parameters.AddWithValue("auctionDate", HttpUtility.HtmlEncode(AuctionStart.Value));
                    sqlCommand2.Parameters.AddWithValue("auctionLocation", HttpUtility.HtmlEncode(auctLocation.Value));
                    sqlCommand2.Connection = sqlConnect2;
                    sqlCommand2.CommandType = CommandType.Text;
                    sqlCommand2.CommandText = sqlQuery2;
                    sqlConnect2.Open();

                    SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();


                    queryResults2.Close();
                    sqlConnect2.Close();
                    //String sqlQuery4 = "Select e.ServiceID FROM  Service e, Item n, Customer s WHERE s.CustomerName = @custName AND n.ServiceID = e.ServiceID AND s.CustomerID = e.CustomerID";
                    String sqlQuery4 = "Select e.ServiceID FROM  Service e, Customer s WHERE s.CustomerName = @custName AND s.CustomerID = e.CustomerID";
                    SqlConnection sqlConnect4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


                    SqlCommand sqlCommand4 = new SqlCommand();
                    sqlCommand4.Parameters.AddWithValue("custName", HttpUtility.HtmlEncode(customerName));
                    sqlCommand4.Connection = sqlConnect4;
                    sqlCommand4.CommandType = CommandType.Text;
                    sqlCommand4.CommandText = sqlQuery4;

                    sqlConnect4.Open();
                    SqlDataReader queryResults4 = sqlCommand4.ExecuteReader();
                    String servID = "";
                    while (queryResults4.Read())
                    {
                        servID = queryResults4["ServiceID"].ToString();
                    }
                    queryResults4.Close();
                    sqlConnect4.Close();


                    String sqlQuery6 = "Update Service set AuctionedYN = @y WHERE ServiceID = @servID";
                    SqlConnection sqlConnect6 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                    SqlCommand sqlCommand6 = new SqlCommand();
                    sqlCommand6.Parameters.AddWithValue("y", '1');
                    sqlCommand6.Parameters.AddWithValue("servID", HttpUtility.HtmlEncode(servID));
                    sqlCommand6.Connection = sqlConnect6;
                    sqlCommand6.CommandType = CommandType.Text;
                    sqlCommand6.CommandText = sqlQuery6;
                    sqlConnect6.Open();

                    SqlDataReader queryResults6 = sqlCommand6.ExecuteReader();
                    queryResults6.Close();
                    sqlConnect6.Close();

                    MissingText.Value = customerName + " has been assigned to the " + auctionDDL.SelectedValue + " Auction";
                }

                //MissingText.Text = "hello?";
            }
            catch (Exception)
            {

            }
            if (MissingText.Value == "")
            {
                MissingText.Value = "There are no items in this Customers Service inventory to assign to an auction";
            }




            //workflow portion for creating service
            String sqlQuery8 = "Select EmployeeID FROM Employee WHERE EmployeeName = @userName";

            SqlConnection sqlConnect8 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand8 = new SqlCommand();
            sqlCommand8.Parameters.AddWithValue("userName", Session["UserName"].ToString());
            sqlCommand8.Connection = sqlConnect8;
            sqlCommand8.CommandType = CommandType.Text;
            sqlCommand8.CommandText = sqlQuery8;


            sqlConnect8.Open();

            int empID;


            empID = Convert.ToInt32(sqlCommand8.ExecuteScalar());

            sqlConnect8.Close();



            String sqlQuery19 = "Select s.ServiceID, s.ServiceName, s.CompletionDate FROM Service s, Customer c WHERE c.CustomerName = @CustomerName AND c.CustomerID = s.CustomerID";

            SqlConnection sqlConnect19 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlCommand sqlCommand19 = new SqlCommand();
            sqlCommand19.Parameters.AddWithValue("CustomerName", HttpUtility.HtmlEncode(custName.Value));
            sqlCommand19.Connection = sqlConnect19;
            sqlCommand19.CommandType = CommandType.Text;
            sqlCommand19.CommandText = sqlQuery19;


            sqlConnect19.Open();
           
            String serviceNameHold = "";
            serviceID = Convert.ToInt32(sqlCommand19.ExecuteScalar());
            


            SqlDataReader queryResults19 = sqlCommand19.ExecuteReader();

            while (queryResults19.Read())
            {
                
                serviceNameHold = queryResults19["ServiceName"].ToString();
                completionDate = queryResults19["CompletionDate"].ToString();

            }




            sqlConnect9.Close();
            DateTime thisDay = DateTime.Today;
            String sqlQuery7 = "Insert into Workflow (EmployeeID, ServiceID, StartDate, EndDate, Status) Values (@empID, @servID, @thisDay, @thisDay, 'Assigned service to an Auction event')";

            SqlConnection sqlConnect7 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand7 = new SqlCommand();
            sqlCommand7.Parameters.AddWithValue("empID", empID);
            sqlCommand7.Parameters.AddWithValue("servID", serviceID);
            sqlCommand7.Parameters.AddWithValue("thisDay", thisDay);
            sqlCommand7.Parameters.AddWithValue("compDay", HttpUtility.HtmlEncode(completionDate));
            sqlCommand7.Connection = sqlConnect7;
            sqlCommand7.CommandType = CommandType.Text;
            sqlCommand7.CommandText = sqlQuery7;

            sqlConnect7.Open();
            SqlDataReader queryResults7 = sqlCommand7.ExecuteReader();


            queryResults7.Close();//closes connection
            sqlConnect7.Close();




            //assign the stuff in the ddls to the workflow


            String length = empList.Items.Count.ToString();
            int emplength = int.Parse(length);

            string servicedID = "";
            String sqlQuery5 = "Select ServiceID from Service where ServiceName = @servName";
            SqlConnection sqlConnect5 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand5 = new SqlCommand();
            sqlCommand5.Parameters.AddWithValue("servName", HttpUtility.HtmlEncode(serviceNameHold));
            sqlCommand5.Connection = sqlConnect5;
            sqlCommand5.CommandType = CommandType.Text;
            sqlCommand5.CommandText = sqlQuery5;
            sqlConnect5.Open();
            SqlDataReader queryResults5 = sqlCommand5.ExecuteReader();
            while (queryResults5.Read())
            {
                servicedID = queryResults5["ServiceID"].ToString();

            }
            queryResults5.Close();
            sqlConnect5.Close();


            for (int i = 0; i < emplength; i++)
            {
                String sqlQuery4 = "Select EmployeeID from Employee where EmployeeName = @empName";
                SqlConnection sqlConnect4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand4 = new SqlCommand();
                sqlCommand4.Parameters.AddWithValue("empName", empList.Items[i].ToString());
                sqlCommand4.Connection = sqlConnect4;
                sqlCommand4.CommandType = CommandType.Text;
                sqlCommand4.CommandText = sqlQuery4;

                sqlConnect4.Open();
                SqlDataReader queryResults4 = sqlCommand4.ExecuteReader();

                String employeeIDHold;
                employeeIDHold = "";
                while (queryResults4.Read())
                {
                    employeeIDHold = queryResults4["EmployeeID"].ToString();
                }

                queryResults4.Close();//closes connection
                sqlConnect4.Close();
                if (employeeIDHold != "")
                {
                    String sqlQuery2 = "Insert into WorkFlow (EmployeeID, ServiceID, StartDate, EndDate, Status) Values (@employeeID, @ServiceID, @startDate, @endDate, @status)";

                    SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand2 = new SqlCommand();
                    sqlCommand2.Parameters.AddWithValue("employeeID", employeeIDHold);
                    sqlCommand2.Parameters.AddWithValue("startDate", HttpUtility.HtmlEncode(startDate));
                    sqlCommand2.Parameters.AddWithValue("endDate", HttpUtility.HtmlEncode(endDate));
                    sqlCommand2.Parameters.AddWithValue("ServiceID", HttpUtility.HtmlEncode(servicedID));
                    sqlCommand2.Parameters.AddWithValue("status", "Assigned to " + HttpUtility.HtmlEncode(serviceNameHold));
                    sqlCommand2.Connection = sqlConnect2;
                    sqlCommand2.CommandType = CommandType.Text;
                    sqlCommand2.CommandText = sqlQuery2;


                    sqlConnect2.Open();

                    SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();

                    queryResults2.Close();//closes connection
                    sqlConnect2.Close();
                }

            }

            //heres the part for submitting the chosen equipment to the database
            String length1 = equipList.Items.Count.ToString();
            int eqplength = int.Parse(length1);

            for (int U = 0; U < eqplength; U++)
            {
                String sqlQuery14 = "Select EquipmentID from Equipment where EquipmentName = @eqpName";
                SqlConnection sqlConnect14 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand14 = new SqlCommand();
                sqlCommand14.Parameters.AddWithValue("eqpName", equipList.Items[U].ToString());
                sqlCommand14.Connection = sqlConnect14;
                sqlCommand14.CommandType = CommandType.Text;
                sqlCommand14.CommandText = sqlQuery14;

                sqlConnect14.Open();
                SqlDataReader queryResults14 = sqlCommand14.ExecuteReader();

                String eqpIDHold;
                eqpIDHold = "";
                while (queryResults14.Read())
                {
                    eqpIDHold = queryResults14["EquipmentID"].ToString();
                }

                queryResults14.Close();//closes connection
                sqlConnect14.Close();
                if (eqpIDHold != "")
                {
                    String sqlQuery12 = "Insert into EquipmentRent (EquipmentID, ServiceID, RentDate, ReturnDate, Status, RentCondition, ReturnCondition) Values (@equipID, @ServiceID, @startDate, @endDate, @status, @rent, @return)";

                    SqlConnection sqlConnect12 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand12 = new SqlCommand();
                    sqlCommand12.Parameters.AddWithValue("equipID", eqpIDHold);
                    sqlCommand12.Parameters.AddWithValue("startDate", HttpUtility.HtmlEncode(startDate));
                    sqlCommand12.Parameters.AddWithValue("endDate", HttpUtility.HtmlEncode(completionDate));
                    sqlCommand12.Parameters.AddWithValue("ServiceID", HttpUtility.HtmlEncode(servicedID));
                    sqlCommand12.Parameters.AddWithValue("status", "Assigned to " + HttpUtility.HtmlEncode(serviceNameHold));
                    sqlCommand12.Parameters.AddWithValue("rent", "good");
                    sqlCommand12.Parameters.AddWithValue("return", "good");
                    sqlCommand12.Connection = sqlConnect12;
                    sqlCommand12.CommandType = CommandType.Text;
                    sqlCommand12.CommandText = sqlQuery12;


                    sqlConnect12.Open();

                    SqlDataReader queryResults12 = sqlCommand12.ExecuteReader();

                    queryResults12.Close();//closes connection
                    sqlConnect12.Close();
                }
            }

            equipList.Items.Clear();
            empList.Items.Clear();
            


        }
        protected void empButton_Click(object sender, EventArgs e)
        {
            empList.Items.Add(empAvail.Text);
        }

        protected void equipButton_Click(object sender, EventArgs e)
        {
            equipList.Items.Add(equipAvail.Text);
        }

    }
}