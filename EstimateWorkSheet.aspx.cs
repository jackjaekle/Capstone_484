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
    public partial class EstimateWorkSheet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String customerName = HttpUtility.HtmlEncode(Request.QueryString["sendName"]);
            ChosenCust.Value = customerName;

            if (ChosenService.Items.Count == 0)// only loads the cust info once
            {
                String sqlQuery = "SELECT s.ServiceName FROM Service s, Customer e WHERE s.CustomerID = e.CustomerID AND e.CustomerName = @custName AND e.MoveCreateYN = @n AND e.ServicedYN = @y";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.AddWithValue("custName", HttpUtility.HtmlEncode(customerName));
                sqlCommand.Parameters.AddWithValue("y", "1");
                sqlCommand.Parameters.AddWithValue("n", '0');

                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    ChosenService.Items.Add(queryResults["ServiceName"].ToString()); //puts it in a ddl 

                }

                queryResults.Close();
                sqlConnect.Close();



            }
            String sqlQuery1 = "Select s.ServiceDate, s.CompletionDate from Service s, Customer e where s.CustomerID = e.CustomerID AND e.CustomerName = @custName AND s.ServiceName = @chosenService";
            SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            DateTime.Now.ToString("yyyyMMdd");
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Parameters.AddWithValue("custName", HttpUtility.HtmlEncode(customerName));
            sqlCommand1.Parameters.AddWithValue("chosenService", HttpUtility.HtmlEncode(ChosenService.Text));
            sqlCommand1.Connection = sqlConnect1;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQuery1;
            sqlConnect1.Open();
            SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();
            while (queryResults1.Read())
            {
                String startDate = queryResults1["ServiceDate"].ToString();
                String endingDate = queryResults1["CompletionDate"].ToString();
                DateTime startingD = DateTime.Parse(startDate);
                DateTime endingD = DateTime.Parse(endingDate);
                var sdate = startingD.ToString("MM/dd/yyyy");
                var edate = endingD.ToString("MM/dd/yyyy");
                startingDate.Value = sdate.ToString();
                endDate.Value = edate.ToString();
            }
            queryResults1.Close();
            sqlConnect1.Close();

            if (empDDL.Items.Count == 0)// only loads the emp info once
            {
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
                DateTime serviceStart = DateTime.Parse(startingDate.Value);
                DateTime serviceEnd = DateTime.Parse(endDate.Value);

               

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
                        if (empDDL.Items.Contains(new ListItem(empName))) //this makes sure it doesnt display the emp name multiple times, as it pulls each empid multiple times from the workflow
                        {
                            //do nothing
                        }
                        else
                        {
                            empDDL.Items.Add(empName);
                        }
                    }
                    queryResults4.Close();
                    sqlConnect4.Close();
                }
                queryResults3.Close();
                sqlConnect3.Close();
            }


            if (truckDDL.Items.Count == 0)// only loads the eqp info once
            {
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
                DateTime serviceStart1 = DateTime.Parse(startingDate.Value);
                DateTime serviceEnd1 = DateTime.Parse(endDate.Value);


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
                        if (truckDDL.Items.Contains(new ListItem(eqpName))) //this makes sure it doesnt display the eqp name multiple times, as it pulls each eqp multiple times from the eqp rent table
                        {
                            //do nothing
                        }
                        else
                        {
                            if (eqpName != "")
                            {
                                truckDDL.Items.Add(eqpName);
                            }
                        }
                    }
                    queryResults14.Close();
                    sqlConnect14.Close();
                }
                queryResults13.Close();
                sqlConnect13.Close();
            }



        }


        protected void ChosenService_SelectedIndexChanged(object sender, EventArgs e)
        {
            String customerName = HttpUtility.HtmlEncode(Request.QueryString["sendName"]);
            String sqlQuery1 = "Select s.ServiceDate, s.CompletionDate from Service s, Customer e where s.CustomerID = e.CustomerID AND e.CustomerName = @custName AND s.ServiceName = @chosenService";
            SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Parameters.AddWithValue("custName", HttpUtility.HtmlEncode(customerName));
            sqlCommand1.Parameters.AddWithValue("chosenService", HttpUtility.HtmlEncode(ChosenService.Text));
            sqlCommand1.Connection = sqlConnect1;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQuery1;
            sqlConnect1.Open();
            SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();
            while (queryResults1.Read())
            {
                startingDate.Value = queryResults1["ServiceDate"].ToString();
                endDate.Value = queryResults1["CompletionDate"].ToString();
            }
            queryResults1.Close();
            sqlConnect1.Close();
        }

        protected void SaveService_Click(object sender, EventArgs e)
        {
            string ServiceName = ChosenService.SelectedValue;

            String sqlQuery = "Update Service Set ServiceDate = @serviceDate, CompletionDate = @comDate, PriceOrigin = @porg, " +
                "ContractPrice = @conPrice, ConSuppliesCost = @supp, EstHours = @est, FinHours = @fin, Mileage = @miles, Fuel = @fuel, Insurance = @ins, " +
                "WorkerPay = @work, Food = @food, Hotel = @hotel Where ServiceName = @serviceName";
            SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Parameters.AddWithValue("serviceName", ServiceName);
            
            sqlCommand1.Parameters.AddWithValue("serviceDate", HttpUtility.HtmlEncode(startingDate.Value));
            sqlCommand1.Parameters.AddWithValue("comDate", HttpUtility.HtmlEncode(endDate.Value));
           
            sqlCommand1.Parameters.AddWithValue("porg", HttpUtility.HtmlEncode(PricingDDL.Text));

            sqlCommand1.Parameters.AddWithValue("conPrice", HttpUtility.HtmlEncode(PriceBox.Text));
            sqlCommand1.Parameters.AddWithValue("supp", HttpUtility.HtmlEncode(SuppliesBox.Text));
            sqlCommand1.Parameters.AddWithValue("est", HttpUtility.HtmlEncode(EstBox.Text));
            sqlCommand1.Parameters.AddWithValue("fin", HttpUtility.HtmlEncode(FinalBox.Text));
            sqlCommand1.Parameters.AddWithValue("miles", HttpUtility.HtmlEncode(MileageBox.Text));
            sqlCommand1.Parameters.AddWithValue("fuel", HttpUtility.HtmlEncode(FuelBox.Text));
            sqlCommand1.Parameters.AddWithValue("ins", HttpUtility.HtmlEncode(InsuranceBox.Text));
            sqlCommand1.Parameters.AddWithValue("work", HttpUtility.HtmlEncode(WorkerCostBox.Text));
            sqlCommand1.Parameters.AddWithValue("food", HttpUtility.HtmlEncode(FoodBox.Text));
            sqlCommand1.Parameters.AddWithValue("hotel", HttpUtility.HtmlEncode(HotelBox.Text));




            sqlCommand1.Connection = sqlConnect1;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQuery;

            sqlConnect1.Open();
            SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();



            queryResults1.Close();//closes connection
            sqlConnect1.Close();




            String sqlQuery3 = "Select CustomerID FROM Customer WHERE CustomerName = @cName";
            SqlConnection sqlConnect3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            String customerName1 = HttpUtility.HtmlEncode(ChosenCust.Value);

            SqlCommand sqlCommand3 = new SqlCommand();
            sqlCommand3.Parameters.AddWithValue("cName", customerName1);
            sqlCommand3.Connection = sqlConnect3;
            sqlCommand3.CommandType = CommandType.Text;
            sqlCommand3.CommandText = sqlQuery3;
            int customerID;
            sqlConnect3.Open();

            customerID = Convert.ToInt32(sqlCommand3.ExecuteScalar());



            sqlConnect3.Close();

            String sqlQuery10 = "Update Customer set Servicedate = @servDate, MoveCreateYN = '1' WHERE CustomerID = @CustomerID";

            SqlConnection sqlConnect10 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand10 = new SqlCommand();
            sqlCommand10.Parameters.AddWithValue("servDate", HttpUtility.HtmlEncode(startingDate.Value));
            sqlCommand10.Parameters.AddWithValue("CustomerID", customerID);
            sqlCommand10.Connection = sqlConnect10;
            sqlCommand10.CommandType = CommandType.Text;
            sqlCommand10.CommandText = sqlQuery10;


            sqlConnect10.Open();

            SqlDataReader queryResults10 = sqlCommand10.ExecuteReader();

            queryResults10.Close();//closes connection
            sqlConnect10.Close();


            String length = empList.Items.Count.ToString();
            int emplength = int.Parse(length);

            string serviceID = "";
            String sqlQuery5 = "Select ServiceID from Service where ServiceName = @servName";
            SqlConnection sqlConnect5 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand5 = new SqlCommand();
            sqlCommand5.Parameters.AddWithValue("servName", HttpUtility.HtmlEncode(ChosenService.Text));
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
                sqlCommand2.Parameters.AddWithValue("startDate", HttpUtility.HtmlEncode(startingDate.Value));
                sqlCommand2.Parameters.AddWithValue("endDate", HttpUtility.HtmlEncode(endDate.Value));
                sqlCommand2.Parameters.AddWithValue("ServiceID", HttpUtility.HtmlEncode(serviceID));
                sqlCommand2.Parameters.AddWithValue("status", "Assigned to " + HttpUtility.HtmlEncode(ChosenService.Text));
                sqlCommand2.Connection = sqlConnect2;
                sqlCommand2.CommandType = CommandType.Text;
                sqlCommand2.CommandText = sqlQuery2;


                sqlConnect2.Open();

                SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();

                queryResults2.Close();//closes connection
                sqlConnect2.Close();

            }

            //workflow part

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
            sqlCommand9.Parameters.AddWithValue("ServiceName", HttpUtility.HtmlEncode(ChosenService.Text));
            sqlCommand9.Connection = sqlConnect9;
            sqlCommand9.CommandType = CommandType.Text;
            sqlCommand9.CommandText = sqlQuery9;


            sqlConnect9.Open();
            int servID;

            servID = Convert.ToInt32(sqlCommand9.ExecuteScalar());

            sqlConnect9.Close();
            DateTime thisDay = DateTime.Today;
            String sqlQuery7 = "Insert into Workflow (EmployeeID, ServiceID, StartDate, EndDate, Status) Values (@empID, @servID, @thisDay, @thisDay, 'Filled out moving estimate Form')";

            SqlConnection sqlConnect7 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand7 = new SqlCommand();
            sqlCommand7.Parameters.AddWithValue("empID", empID);
            sqlCommand7.Parameters.AddWithValue("servID", servID);
            sqlCommand7.Parameters.AddWithValue("thisDay", thisDay);
            sqlCommand7.Parameters.AddWithValue("compDay", HttpUtility.HtmlEncode(endDate.Value));
            sqlCommand7.Connection = sqlConnect7;
            sqlCommand7.CommandType = CommandType.Text;
            sqlCommand7.CommandText = sqlQuery7;

            sqlConnect7.Open();
            SqlDataReader queryResults7 = sqlCommand7.ExecuteReader();


            queryResults7.Close();//closes connection
            sqlConnect7.Close();




            //heres the part for submitting the chosen equipment to the database
            String length1 = truckList.Items.Count.ToString();
            int eqplength = int.Parse(length1);

            for (int U = 0; U < eqplength; U++)
            {
                String sqlQuery14 = "Select EquipmentID from Equipment where EquipmentName = @eqpName";
                SqlConnection sqlConnect14 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand14 = new SqlCommand();
                sqlCommand14.Parameters.AddWithValue("eqpName", truckList.Items[U].ToString());
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
                sqlCommand12.Parameters.AddWithValue("startDate", HttpUtility.HtmlEncode(startingDate.Value));
                sqlCommand12.Parameters.AddWithValue("endDate", HttpUtility.HtmlEncode(endDate.Value));
                sqlCommand12.Parameters.AddWithValue("ServiceID", HttpUtility.HtmlEncode(serviceID));
                sqlCommand12.Parameters.AddWithValue("status", "Assigned to " + HttpUtility.HtmlEncode(ChosenService.Text));
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
            truckList.Items.Clear();
            empList.Items.Clear();
            truckDDL.Items.Clear();
            empDDL.Items.Clear();

            Updated.Text = "Service Updated";
            
        }

        protected void ReturnButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx");
        }

        protected void empAdd_Click(object sender, EventArgs e)
        {
            empList.Items.Add(empDDL.Text);
        }

        protected void truckAdd_Click(object sender, EventArgs e)
        {
            truckList.Items.Add(truckDDL.Text);
        }
    }
}