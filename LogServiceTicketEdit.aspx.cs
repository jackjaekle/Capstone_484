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
    public partial class LogServiceTicketEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                String svcName = HttpUtility.HtmlEncode(Request.QueryString["sendService"]);
               // DDL.SelectedValue = svcName;
            //    //DDL.Enabled = false;

            //    // Populate Textboxes

            //    String sqlQuery = "Select ServiceName, ServiceCost, ServiceDate, CompletionDate, UpdateStatus, PaymentStatus, Origin, Destination FROM Service WHERE ServiceName = '" + serviceName + "'";
            //    SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            //    SqlCommand sqlCommand = new SqlCommand();

            //    sqlCommand.Connection = sqlConnect;
            //    sqlCommand.CommandType = CommandType.Text;
            //    sqlCommand.CommandText = sqlQuery;
            //    sqlConnect.Open();
            //    SqlDataReader queryResults = sqlCommand.ExecuteReader();
            //    while (queryResults.Read())
            //    {
            //        serviceName.Text = queryResults["ServiceName"].ToString();
            //        serviceCost.Text = queryResults["ServiceCost"].ToString();
            //        startDate.Text = queryResults["ServiceDate"].ToString();
            //        completionDate.Text = queryResults["CompletionDate"].ToString();
            //        updateStatus.Text = queryResults["UpdateStatus"].ToString();
            //        paymentStatus.Text = queryResults["PaymentStatus"].ToString();
            //        origin.Text = queryResults["Origin"].ToString();
            //        destination.Text = queryResults["Destination"].ToString();

            //    }
            //}


            if (DDL.Items.Count == 0)
            {
                equipAvail.Visible = false;
                Label4.Visible = false;
                equipList.Visible = false;
                Label2.Visible = false;
                Label5.Visible = false;
                empList.Visible = false;
                Label3.Visible = false;
                Submit2.Visible = false;
                yesButton.Visible = false;
                noButton.Visible = false;
                equipButton.Visible = false;
                empButton.Visible = false;
                empAvail.Visible = false;

                updateStatus.Items.Add("Not Started");
                paymentStatus.Items.Add("Not Received");
                updateStatus.Items.Add("In Progress");
                paymentStatus.Items.Add("Received");
                updateStatus.Items.Add("Complete");


                DDL.Visible = false;

                DDL.Items.Add(svcName);
                noteStatus.Text = "";
                

                DDL.SelectedValue = svcName;

                // Populate Textboxes

                String sqlQueryC = "Select ServiceName, ServiceCost, ServiceDate, CompletionDate, UpdateStatus, PaymentStatus, Origin, Destination FROM Service WHERE ServiceName = '" + DDL.SelectedValue.ToString() + "'";
                SqlConnection sqlConnectC = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommandC = new SqlCommand();

                sqlCommandC.Connection = sqlConnectC;
                sqlCommandC.CommandType = CommandType.Text;
                sqlCommandC.CommandText = sqlQueryC;
                sqlConnectC.Open();
                SqlDataReader queryResultsC = sqlCommandC.ExecuteReader();
                while (queryResultsC.Read())
                {

                    String startingDate = queryResultsC["ServiceDate"].ToString();
                    String endingDate = queryResultsC["CompletionDate"].ToString();
                    DateTime startingD = DateTime.Parse(startingDate);
                    DateTime endingD = DateTime.Parse(endingDate);
                    var sdate = startingD.ToString("MM/dd/yyyy");
                    var edate = endingD.ToString("MM/dd/yyyy");
                    startDate.Text = sdate.ToString();
                    completionDate.Text = edate.ToString();



                    serviceName.Value = queryResultsC["ServiceName"].ToString();
                    serviceCost.Text = queryResultsC["ServiceCost"].ToString();
                    //startDate.Text = queryResults["ServiceDate"].ToString();
                    //completionDate.Text = queryResults["CompletionDate"].ToString();
                    updateStatus.Text = queryResultsC["UpdateStatus"].ToString();
                    paymentStatus.Text = queryResultsC["PaymentStatus"].ToString();
                    origin.Text = queryResultsC["Origin"].ToString();
                    destination.Text = queryResultsC["Destination"].ToString();

                }

                svcNm.Text = svcName;
                DDL.Visible = false;



            }
        }
        String servStartDate = "";
        String servEndDate = "";
        String newStartDate = "";
        String newEndDate = "";
        Boolean dateUpdate = false;
        protected void startChanged(object sender, EventArgs e)
        {
            dateUpdate = true;
        }

        protected void endChanged(object sender, EventArgs e)
        {
            dateUpdate = true;
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }

        protected void DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            equipAvail.Visible = false;
            Label4.Visible = false;
            equipList.Visible = false;
            Label2.Visible = false;
            Label5.Visible = false;
            empList.Visible = false;
            Label3.Visible = false;
            Submit2.Visible = false;
            yesButton.Visible = false;
            noButton.Visible = false;
            equipButton.Visible = false;
            empButton.Visible = false;
            empAvail.Visible = false;

            String sqlQuery = "Select ServiceName, ServiceCost, ServiceDate, CompletionDate, UpdateStatus, PaymentStatus, Origin, Destination FROM Service WHERE ServiceName = @DDL";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            DateTime.Now.ToString("yyyyMMdd");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(DDL.Text));

            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            while (queryResults.Read())
            {
                String startingDate = queryResults["ServiceDate"].ToString();
                String endingDate = queryResults["CompletionDate"].ToString();
                DateTime startingD = DateTime.Parse(startingDate);
                DateTime endingD = DateTime.Parse(endingDate);
                var sdate = startingD.ToString("MM/dd/yyyy");
                var edate = endingD.ToString("MM/dd/yyyy");
                startDate.Text = sdate.ToString();
                completionDate.Text = edate.ToString();



                serviceName.Value = queryResults["ServiceName"].ToString();
                serviceCost.Text = queryResults["ServiceCost"].ToString();
                //startDate.Text = queryResults["ServiceDate"].ToString();
                //completionDate.Text = queryResults["CompletionDate"].ToString();
                updateStatus.Text = queryResults["UpdateStatus"].ToString();
                paymentStatus.Text = queryResults["PaymentStatus"].ToString();
                origin.Text = queryResults["Origin"].ToString();
                destination.Text = queryResults["Destination"].ToString();

            }


            String custName = "";
            String sqlQuery7 = "Select c.CustomerName from Customer c, Service s Where s.CustomerID = c.CustomerID and s.ServiceName = @DDL";
            SqlConnection sqlConnect7 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand7 = new SqlCommand();
            sqlCommand7.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(DDL.Text));

            sqlCommand7.Connection = sqlConnect7;
            sqlCommand7.CommandType = CommandType.Text;
            sqlCommand7.CommandText = sqlQuery7;
            sqlConnect7.Open();
            SqlDataReader queryResults7 = sqlCommand7.ExecuteReader();
            while (queryResults7.Read())
            {
                custName = queryResults7["CustomerName"].ToString();

            }
            queryResults7.Close();
            sqlConnect7.Close();



            String sqlQuery2 = "Select s.ServiceDate, s.CompletionDate from Service s, Customer e where s.CustomerID = e.CustomerID AND e.CustomerName = @custName AND s.ServiceName = @chosenService";
            SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            DateTime.Now.ToString("yyyyMMdd");
            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Parameters.AddWithValue("custName", HttpUtility.HtmlEncode(custName));
            sqlCommand2.Parameters.AddWithValue("chosenService", HttpUtility.HtmlEncode(DDL.Text));
            sqlCommand2.Connection = sqlConnect2;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuery2;
            sqlConnect2.Open();
            SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();
            while (queryResults2.Read())

            {
                String startingDate = queryResults2["ServiceDate"].ToString();
                String endingDate = queryResults2["CompletionDate"].ToString();
                DateTime startingD = DateTime.Parse(startingDate);
                DateTime endingD = DateTime.Parse(endingDate);
                var sdate = startingD.ToString("MM/dd/yyyy");
                var edate = endingD.ToString("MM/dd/yyyy");
                startDate.Text = sdate.ToString();
                completionDate.Text = edate.ToString();
                servStartDate = sdate.ToString();
                servEndDate = edate.ToString();

            }

            queryResults2.Close();
            sqlConnect2.Close();


            queryResults.Close();
            sqlConnect.Close();
        }
        int i = 0;
        protected void Submit_Click(object sender, EventArgs e)
        {
            //String servStartDate = "";
            //String servEndDate = "";
            //String newStartDate = "";
            //String newEndDate = "";
            newStartDate = startDate.Text;
            newEndDate = completionDate.Text;

            String custName = "";
            String sqlQuery7 = "Select c.CustomerName from Customer c, Service s Where s.CustomerID = c.CustomerID and s.ServiceName = @DDL";
            SqlConnection sqlConnect7 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand7 = new SqlCommand();
            sqlCommand7.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(DDL.Text));

            sqlCommand7.Connection = sqlConnect7;
            sqlCommand7.CommandType = CommandType.Text;
            sqlCommand7.CommandText = sqlQuery7;
            sqlConnect7.Open();
            SqlDataReader queryResults7 = sqlCommand7.ExecuteReader();
            while (queryResults7.Read())
            {
                custName = queryResults7["CustomerName"].ToString();

            }
            queryResults7.Close();
            sqlConnect7.Close();

            String sqlQuery2 = "Select s.ServiceDate, s.CompletionDate from Service s, Customer e where s.CustomerID = e.CustomerID AND e.CustomerName = @custName AND s.ServiceName = @chosenService";
            SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            DateTime.Now.ToString("yyyyMMdd");
            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Parameters.AddWithValue("custName", HttpUtility.HtmlEncode(custName));
            sqlCommand2.Parameters.AddWithValue("chosenService", HttpUtility.HtmlEncode(DDL.Text));
            sqlCommand2.Connection = sqlConnect2;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuery2;
            sqlConnect2.Open();
            SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();
            while (queryResults2.Read())

            {
                String startingDate = queryResults2["ServiceDate"].ToString();
                String endingDate = queryResults2["CompletionDate"].ToString();
                DateTime startingD = DateTime.Parse(startingDate);
                DateTime endingD = DateTime.Parse(endingDate);
                var sdate = startingD.ToString("MM/dd/yyyy");
                var edate = endingD.ToString("MM/dd/yyyy");

                servStartDate = sdate.ToString();
                servEndDate = edate.ToString();

            }

            queryResults2.Close();
            sqlConnect2.Close();
           
            if (servStartDate.Equals(newStartDate) && newEndDate.Equals(servEndDate))
            {
                String sqlQuery = "Update Service Set ServiceName = @serviceName , ServiceCost = @serviceCost, UpdateStatus = @updateStatus, PaymentStatus = @paymentStatus, Origin = @origin , Destination = @destination WHERE ServiceName = @DDL";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(DDL.Text));
                sqlCommand.Parameters.AddWithValue("serviceName", HttpUtility.HtmlEncode(serviceName.Value));
                sqlCommand.Parameters.AddWithValue("serviceCost", HttpUtility.HtmlEncode(serviceCost.Text));

                sqlCommand.Parameters.AddWithValue("updateStatus", HttpUtility.HtmlEncode(updateStatus.Text));
                sqlCommand.Parameters.AddWithValue("paymentStatus", HttpUtility.HtmlEncode(paymentStatus.Text));
                sqlCommand.Parameters.AddWithValue("origin", HttpUtility.HtmlEncode(origin.Text));
                sqlCommand.Parameters.AddWithValue("destination", HttpUtility.HtmlEncode(destination.Text));



                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                queryResults.Close();
                sqlConnect.Close();
                noteStatus.Text = "Record Updated";
               
                
            }
            else
            {
                //make the warning show up saying that if you save these changes you will have to reassign the employees
                //make a confirm button visible
                //make it dissapear after confirming
                //change to a different submit button, replace the old one
                //make the listboxes and labels visible.
                noteStatus.Text = "You have have changed the start and / or end time of service, doing so will remove all employees and equipment from the service if there are any assigned, and they will have to be reassigned. Continue?" ;
                //make a yes or no button. yes button continues, no button returns back to how the date and time is.

                yesButton.Visible = true;
                noButton.Visible = true;



            }


            //new code to insert into workflow who assigned this

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



            String sqlQuery9 = "Select ServiceID FROM service WHERE ServiceName = @ServiceName";

            SqlConnection sqlConnect9 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlCommand sqlCommand9 = new SqlCommand();
            sqlCommand9.Parameters.AddWithValue("ServiceName", HttpUtility.HtmlEncode(DDL.Text));
            sqlCommand9.Connection = sqlConnect9;
            sqlCommand9.CommandType = CommandType.Text;
            sqlCommand9.CommandText = sqlQuery9;


            sqlConnect9.Open();
            int servID;

            servID = Convert.ToInt32(sqlCommand9.ExecuteScalar());

            sqlConnect9.Close();
            DateTime thisDay = DateTime.Today;
            String sqlQuery17 = "Insert into Workflow (EmployeeID, ServiceID, StartDate, EndDate, Status) Values (@empID, @servID, @thisDay, @thisDay, 'Edited Service Info')";

            SqlConnection sqlConnect17 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand17 = new SqlCommand();
            sqlCommand17.Parameters.AddWithValue("empID", empID);
            sqlCommand17.Parameters.AddWithValue("servID", servID);
            sqlCommand17.Parameters.AddWithValue("thisDay", thisDay);
            sqlCommand17.Parameters.AddWithValue("compDay", HttpUtility.HtmlEncode(completionDate.Text));
            sqlCommand17.Connection = sqlConnect17;
            sqlCommand17.CommandType = CommandType.Text;
            sqlCommand17.CommandText = sqlQuery17;

            sqlConnect17.Open();
            SqlDataReader queryResults17 = sqlCommand17.ExecuteReader();


            queryResults17.Close();//closes connection
            sqlConnect17.Close();



        }

        protected void yesButton_Click(object sender, EventArgs e)
        {
            //make all the new stuff visible / the old submit button invisible
            Label6.Visible = true;
            Label7.Visible = true;
            Label6.Text = startDate.Text;
            Label7.Text = completionDate.Text;
            startDate.Visible = false;
            completionDate.Visible = false;
            equipAvail.Visible = true;
            Label4.Visible = true;
            equipList.Visible = true;
            Label2.Visible = true;
            Label5.Visible = true;
            empList.Visible = true;
            Label3.Visible = true;
            Submit2.Visible = true;
            Submit.Visible = false;
            equipButton.Visible = true;
            empButton.Visible = true;
            empAvail.Visible = true;
            yesButton.Visible = false;
            noButton.Visible = false;
            noteStatus.Text = "";
            //clear the workflow of all entries associated with the current service selected by the ddl.
            warn1.Text = "Dates cannot be changed right now";
            warn2.Text = "Dates cannot be changed right now";

            String sqlQuery = "Select ServiceID FROM Service WHERE ServiceName = @DDL";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(DDL.Text));

            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            String serviceIDHold = "";
            while (queryResults.Read())
            {
                serviceIDHold = queryResults["ServiceID"].ToString();


            }
            queryResults.Close();
            sqlConnect.Close();

            String sqlQuery1 = "Update Workflow SET EmployeeID = Null, StartDate= Null, EndDate = Null, Status = 'Removed from Job'  where ServiceID = @id";
            SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Parameters.AddWithValue("id", serviceIDHold);

            sqlCommand1.Connection = sqlConnect1;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQuery1;
            sqlConnect1.Open();
            SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();


            queryResults1.Close();
            sqlConnect1.Close();

            //removes the past assigned rental on the equipment

            String sqlQuery10 = "Update EquipmentRent SET RentDate= Null, ReturnDate = Null, Status = 'Removed from Job' where ServiceID = @id";
            SqlConnection sqlConnect10 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand10 = new SqlCommand();
            sqlCommand10.Parameters.AddWithValue("id", serviceIDHold);

            sqlCommand10.Connection = sqlConnect10;
            sqlCommand10.CommandType = CommandType.Text;
            sqlCommand10.CommandText = sqlQuery10;
            sqlConnect10.Open();
            SqlDataReader queryResults10 = sqlCommand10.ExecuteReader();


            queryResults10.Close();
            sqlConnect10.Close();


            //fill the ddls with available equip and employees
            //
            //
            //
            //



            String sqlQuery3 = "Select w.EmployeeID from Workflow w, Employee e WHERE e.EmployeeStatus Like @hired and w.EmployeeID = e.EmployeeID";
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
            DateTime.Now.ToString("yyyyMMdd");
            DateTime serviceStart = DateTime.Parse(startDate.Text);
            DateTime serviceEnd = DateTime.Parse(completionDate.Text);


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
            DateTime serviceStart1 = DateTime.Parse(startDate.Text);
            DateTime serviceEnd1 = DateTime.Parse(completionDate.Text);

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






        protected void noButton_Click(object sender, EventArgs e)
        {
            //change it back to how it was
            yesButton.Visible = false;
            noButton.Visible = false;

            String sqlQuery = "Select ServiceName, ServiceCost, ServiceDate, CompletionDate, UpdateStatus, PaymentStatus, Origin, Destination FROM Service WHERE ServiceName = @DDL";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(DDL.Text));

            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            while (queryResults.Read())
            {

                startDate.Text = queryResults["ServiceDate"].ToString();
                completionDate.Text = queryResults["CompletionDate"].ToString();

            }
            queryResults.Close();
            sqlConnect.Close();

            String custName = "";
            String sqlQuery7 = "Select c.CustomerName from Customer c, Service s Where s.CustomerID = c.CustomerID and s.ServiceName = @DDL";
            SqlConnection sqlConnect7 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand7 = new SqlCommand();
            sqlCommand7.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(DDL.Text));

            sqlCommand7.Connection = sqlConnect7;
            sqlCommand7.CommandType = CommandType.Text;
            sqlCommand7.CommandText = sqlQuery7;
            sqlConnect7.Open();
            SqlDataReader queryResults7 = sqlCommand7.ExecuteReader();
            while (queryResults7.Read())
            {
                custName = queryResults7["CustomerName"].ToString();

            }
            queryResults7.Close();
            sqlConnect7.Close();



            String sqlQuery2 = "Select s.ServiceDate, s.CompletionDate from Service s, Customer e where s.CustomerID = e.CustomerID AND e.CustomerName = @custName AND s.ServiceName = @chosenService";
            SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            DateTime.Now.ToString("yyyyMMdd");
            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Parameters.AddWithValue("custName", HttpUtility.HtmlEncode(custName));
            sqlCommand2.Parameters.AddWithValue("chosenService", HttpUtility.HtmlEncode(DDL.Text));
            sqlCommand2.Connection = sqlConnect2;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuery2;
            sqlConnect2.Open();
            SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();
            while (queryResults2.Read())
            {
                String startingDate = queryResults2["ServiceDate"].ToString();
                String endingDate = queryResults2["CompletionDate"].ToString();
                DateTime startingD = DateTime.Parse(startingDate);
                DateTime endingD = DateTime.Parse(endingDate);
                var sdate = startingD.ToString("MM/dd/yyyy");
                var edate = endingD.ToString("MM/dd/yyyy");
                startDate.Text = sdate.ToString();
                completionDate.Text = edate.ToString();
            }
            queryResults2.Close();
            sqlConnect2.Close();


            noteStatus.Text = "Reverted back to original dates, other changes can still be made and submitted";

        }



        protected void Submit2_Click(object sender, EventArgs e)
        {
            //submit the new changes

            //this is where i will both submit the stuff in the texboxes as normal, and also the looping stuff for the listboxes.
            warn1.Text = "";
            warn2.Text = "";

            String sqlQuery = "Update Service Set ServiceName = @serviceName ,ServiceDate = @startDate, CompletionDate = @endDate, ServiceCost = @serviceCost, UpdateStatus = @updateStatus, PaymentStatus = @paymentStatus, Origin = @origin , Destination = @destination WHERE ServiceName = @DDL";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(DDL.Text));
            sqlCommand.Parameters.AddWithValue("serviceName", HttpUtility.HtmlEncode(serviceName.Value));
            sqlCommand.Parameters.AddWithValue("serviceCost", HttpUtility.HtmlEncode(serviceCost.Text));
            sqlCommand.Parameters.AddWithValue("startDate", HttpUtility.HtmlEncode(startDate.Text));
            sqlCommand.Parameters.AddWithValue("endDate", HttpUtility.HtmlEncode(completionDate.Text));
            sqlCommand.Parameters.AddWithValue("updateStatus", HttpUtility.HtmlEncode(updateStatus.Text));
            sqlCommand.Parameters.AddWithValue("paymentStatus", HttpUtility.HtmlEncode(paymentStatus.Text));
            sqlCommand.Parameters.AddWithValue("origin", HttpUtility.HtmlEncode(origin.Text));
            sqlCommand.Parameters.AddWithValue("destination", HttpUtility.HtmlEncode(destination.Text));



            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            queryResults.Close();
            sqlConnect.Close();


            String length = empList.Items.Count.ToString();
            int emplength = int.Parse(length);

            string serviceID = "";
            String sqlQuery5 = "Select ServiceID from Service where ServiceName = @servName";
            SqlConnection sqlConnect5 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand5 = new SqlCommand();
            sqlCommand5.Parameters.AddWithValue("servName", HttpUtility.HtmlEncode(DDL.Text));
            sqlCommand5.Connection = sqlConnect5;
            sqlCommand5.CommandType = CommandType.Text;
            sqlCommand5.CommandText = sqlQuery5;
            sqlConnect5.Open();
            SqlDataReader queryResults5 = sqlCommand5.ExecuteReader();
            while (queryResults5.Read())
            {
                serviceID = queryResults5["ServiceID"].ToString();

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

                String sqlQuery2 = "Insert into WorkFlow (EmployeeID, ServiceID, StartDate, EndDate, Status) Values (@employeeID, @ServiceID, @startDate, @endDate, @status)";

                SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand2 = new SqlCommand();
                sqlCommand2.Parameters.AddWithValue("employeeID", employeeIDHold);
                sqlCommand2.Parameters.AddWithValue("startDate", HttpUtility.HtmlEncode(startDate.Text));
                sqlCommand2.Parameters.AddWithValue("endDate", HttpUtility.HtmlEncode(completionDate.Text));
                sqlCommand2.Parameters.AddWithValue("ServiceID", HttpUtility.HtmlEncode(serviceID));
                sqlCommand2.Parameters.AddWithValue("status", "Assigned to " + HttpUtility.HtmlEncode(DDL.Text));
                sqlCommand2.Connection = sqlConnect2;
                sqlCommand2.CommandType = CommandType.Text;
                sqlCommand2.CommandText = sqlQuery2;


                sqlConnect2.Open();

                SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();

                queryResults2.Close();//closes connection
                sqlConnect2.Close();

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

                String sqlQuery12 = "Insert into EquipmentRent (EquipmentID, ServiceID, RentDate, ReturnDate, Status, RentCondition, ReturnCondition) Values (@equipID, @ServiceID, @startDate, @endDate, @status, @rent, @return)";

                SqlConnection sqlConnect12 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand12 = new SqlCommand();
                sqlCommand12.Parameters.AddWithValue("equipID", eqpIDHold);
                sqlCommand12.Parameters.AddWithValue("startDate", HttpUtility.HtmlEncode(startDate.Text));
                sqlCommand12.Parameters.AddWithValue("endDate", HttpUtility.HtmlEncode(completionDate.Text));
                sqlCommand12.Parameters.AddWithValue("ServiceID", HttpUtility.HtmlEncode(serviceID));
                sqlCommand12.Parameters.AddWithValue("status", "Assigned to " + HttpUtility.HtmlEncode(DDL.Text));
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

            equipList.Items.Clear();
            empList.Items.Clear();
            equipAvail.Items.Clear();
            empAvail.Items.Clear();

            noteStatus.Text = "Record Updated";

            Label6.Visible = false;
            Label7.Visible = false;
            
            startDate.Visible = true;
            completionDate.Visible = true;
            equipAvail.Visible = false;
            Label4.Visible = false;
            equipList.Visible = false;
            Label2.Visible = false;
            Label5.Visible = false;
            empList.Visible = false;
            Label3.Visible = false;
            Submit2.Visible = false;
            Submit.Visible = true;
            equipButton.Visible = false;
            empButton.Visible = false;
            empAvail.Visible = false;
            yesButton.Visible = false;
            noButton.Visible = false;



            //new code to insert into workflow who assigned this

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



            String sqlQuery9 = "Select ServiceID FROM service WHERE ServiceName = @ServiceName";

            SqlConnection sqlConnect9 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlCommand sqlCommand9 = new SqlCommand();
            sqlCommand9.Parameters.AddWithValue("ServiceName", HttpUtility.HtmlEncode(DDL.Text));
            sqlCommand9.Connection = sqlConnect9;
            sqlCommand9.CommandType = CommandType.Text;
            sqlCommand9.CommandText = sqlQuery9;


            sqlConnect9.Open();
            int servID;

            servID = Convert.ToInt32(sqlCommand9.ExecuteScalar());

            sqlConnect9.Close();
            DateTime thisDay = DateTime.Today;
            String sqlQuery7 = "Insert into Workflow (EmployeeID, ServiceID, StartDate, EndDate, Status) Values (@empID, @servID, @thisDay, @thisDay, 'Edited Service Info')";

            SqlConnection sqlConnect7 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand7 = new SqlCommand();
            sqlCommand7.Parameters.AddWithValue("empID", empID);
            sqlCommand7.Parameters.AddWithValue("servID", servID);
            sqlCommand7.Parameters.AddWithValue("thisDay", thisDay);
            sqlCommand7.Parameters.AddWithValue("compDay", HttpUtility.HtmlEncode(completionDate.Text));
            sqlCommand7.Connection = sqlConnect7;
            sqlCommand7.CommandType = CommandType.Text;
            sqlCommand7.CommandText = sqlQuery7;
           
            sqlConnect7.Open();
            SqlDataReader queryResults7 = sqlCommand7.ExecuteReader();


            queryResults7.Close();//closes connection
            sqlConnect7.Close();





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


