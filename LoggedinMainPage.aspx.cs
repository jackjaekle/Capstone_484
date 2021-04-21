using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab1
{
    public partial class LoggedinMainPage : System.Web.UI.Page
    {
        String sendCustName = "";
        DateTime now = DateTime.UtcNow;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {


                }
                else
                {

                    Response.Redirect("MainPageNoLogin.aspx?InvalidUse=true");
                }
            }


            if (CustomerInfo.Items.Count == 0)// only loads the emp info once
            {

             

                String sqlQuery2 = "Select CustomerName, DateOfServiceRequest FROM Customer WHERE ServicedYN = @n AND descriptionOfNeeds IS NOT Null AND DateOfServiceRequest IS NOT Null AND MoveCreateYN ='0' ORDER BY DateOfServiceRequest";
                SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand2 = new SqlCommand();
                sqlCommand2.Parameters.AddWithValue("n", '1');
                sqlCommand2.Connection = sqlConnect2;
                sqlCommand2.CommandType = CommandType.Text;
                sqlCommand2.CommandText = sqlQuery2;

                sqlConnect2.Open();
                SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();
                while (queryResults2.Read())
                {
                    DateTime past = DateTime.Parse(queryResults2["DateOfServiceRequest"].ToString());
                    TimeSpan duration = now - past;

                    char[] delimiterChars = { '.' };
                    string[] words = duration.ToString().Split(delimiterChars);
                    String days = words[0].Trim();
                    String hours = words[1].Trim();
                    if (words.Length <= 2)
                    {
                        days = "0";
                        hours = words[0].Trim();
                    }
                    CustomerInfo.Items.Add("Customer Name  |  Waiting time");

                    CustomerInfo.Items.Add(queryResults2["CustomerName"].ToString() + " |  days: " + days);
                }

                queryResults2.Close();
                sqlConnect2.Close();
            }




            if (custInvList.Items.Count == 0)
            {
                custInvList.Items.Add("Customer Name  |  Waiting time");

                //This block of code fills a dropdown list with the info it needs
                String sqlQuery = "Select c.CustomerName, c.DateOfServiceRequest FROM Customer c, Service s WHERE s.AuctionedYN = @n AND DateOfServiceRequest IS NOT Null AND c.CustomerID = s.CustomerID ORDER BY DateOfServiceRequest";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                String n = "0";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.AddWithValue("n", n);
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    DateTime past = DateTime.Parse(queryResults["DateOfServiceRequest"].ToString());
                    TimeSpan duration = now - past;

                    char[] delimiterChars = { '.' };
                    string[] words = duration.ToString().Split(delimiterChars);
                    String days = words[0].Trim();
                    String hours = words[1].Trim();
                    if (words.Length <= 2)
                    {
                        days = "0";
                        hours = words[0].Trim();
                    }

                    custInvList.Items.Add(queryResults["CustomerName"].ToString() + " |  days: " + days);

                }

                queryResults.Close();
                sqlConnect.Close();

                //sql to pull up a list of customer names with the "n" for if they have been serviced
                //make the n be autofilled for new customers

            }












            if (custList.Items.Count == 0 && MovingRadio.Checked == true)
            {
                //This block of code fills a dropdown list with the info it needs
                custList.Items.Add("Customer Name  |  Waiting time");
                String sqlQuery = "Select CustomerName, DateOfServiceRequest FROM Customer WHERE ServicedYN = @n AND descriptionOfNeeds IS NOT Null AND typeOfService = @Moving ORDER BY DateOfServiceRequest";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                String n = "0";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.AddWithValue("n", n);
                sqlCommand.Parameters.AddWithValue("Moving", "Moving");
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    DateTime past = DateTime.Parse(queryResults["DateOfServiceRequest"].ToString());
                    TimeSpan duration = now - past;

                    char[] delimiterChars = { '.' };
                    string[] words = duration.ToString().Split(delimiterChars);
                    String days = words[0].Trim();
                    String hours = words[1].Trim();
                    if (words.Length <= 2)
                    {
                        days = "0";
                        hours = words[0].Trim();
                    }

                    custList.Items.Add(queryResults["CustomerName"].ToString() + " |  days: " + days);

                }
                
                queryResults.Close();
                sqlConnect.Close();

                //sql to pull up a list of customer names with the "n" for if they have been serviced
                //make the n be autofilled for new customers

            }

            if (DDL.Items.Count == 0)// only loads the emp info once
            {

                String sqlQuery = "Select EmployeeName FROM Employee";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    DDL.Items.Add(queryResults["EmployeeName"].ToString()); //puts it in a ddl 

                }

                queryResults.Close();
                sqlConnect.Close();
            }

            //String sqlQuery = "Select CustomerName FROM Customer WHERE ServicedYN = @n AND descriptionOfNeeds IS NOT Null AND MoveCreateYN IS NULL";
            //SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            //String n = "0";
            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.Parameters.AddWithValue("n", n);
            //sqlCommand.Connection = sqlConnect;
            //sqlCommand.CommandType = CommandType.Text;
            //sqlCommand.CommandText = sqlQuery;

            //sqlConnect.Open();
            //SqlDataReader queryResults = sqlCommand.ExecuteReader();
            //int i = 0;

            //while (queryResults.Read())
            //{
            //    i++;
            //}
            //queryResults.Close();//closes connection
            //sqlConnect.Close();
            //if (i == 1)
            //{
            //    customersWait.Text = i + " Customer waiting on service";
            //}
            //else
            //{
            //    customersWait.Text = i + " Customers waiting on service";
            //}


            //String sqlQuery2 = "Select CustomerName FROM Customer WHERE ServicedYN = @n AND descriptionOfNeeds IS NOT Null AND MoveCreateYN = '0'";
            //SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            //SqlCommand sqlCommand2 = new SqlCommand();
            //sqlCommand2.Parameters.AddWithValue("n", '1');
            //sqlCommand2.Connection = sqlConnect;
            //sqlCommand2.CommandType = CommandType.Text;
            //sqlCommand2.CommandText = sqlQuery2;

            //sqlConnect.Open();
            //SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();
            //int f = 0;
            //while (queryResults2.Read())
            //{
            //    f++;
            //}
            //queryResults2.Close();//closes connection
            //sqlConnect2.Close();
            //if (f == 1)
            //{
            //    moveWait.Text = f + " Customer waiting on Moving service pricing assignment";
            //}
            //else
            //{
            //    moveWait.Text = f + " Customers waiting on Moving service pricing assignment";
            //}

            //String sqlQuery1 = "Select ServiceName FROM Service WHERE AuctionedYN = @n";
            //SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            //String y = "0";
            //SqlCommand sqlCommand1 = new SqlCommand();
            //sqlCommand1.Parameters.AddWithValue("n", y);
            //sqlCommand1.Connection = sqlConnect1;
            //sqlCommand1.CommandType = CommandType.Text;
            //sqlCommand1.CommandText = sqlQuery1;

            //sqlConnect1.Open();
            //SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();
            //int x = 0;

            //while (queryResults1.Read())
            //{
            //    x++;
            //}
            //queryResults1.Close();//closes connection
            //sqlConnect1.Close();
            //if (x == 1)
            //{
            //    auctionWait.Text = x + " Customer Inventory waiting to be auctioned";
            //}
            //else
            //{
            //    auctionWait.Text = x + " Customer Inventories waiting to be auctioned";
            //}
            //// ENSURE ADMIN IS LOGGED IN, FOR GREGS EYES ONLY, BUTTON IS INVISIBLE IF ADMIN ISNT LOGGED IN

            //SqlConnection sqlConnectA = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            //sqlConnectA.Open();


            //string user = Session["UserName"] as string; // Store logged in user username in variable
            //// Pull employee type based on email == login from AUTH db
            //String typeCheck = "SELECT EmployeeType FROM Employee WHERE EmployeeEmail = @EmployeeEmail";
            //SqlCommand tCheck = new SqlCommand(typeCheck, sqlConnectA);
            //tCheck.Parameters.AddWithValue("@EmployeeEmail", user);
            //// Store employee tye in a variable
            //String userType = Convert.ToString(tCheck.ExecuteScalar());


            //if (userType == "A") // If admin is logged in, make moving schedule info visible
            //{
            //    MovingSchedule.Visible = true;
            //    moveWait.Visible = true;
            //}
            //else if (userType == "D") // If a driver, redirect to driver page
            //{
            //    Response.Redirect("DriverPage.aspx");
            //}
            //else // If employee type is E, make Moving schedule info unavaialble 
            //{
            //    MovingSchedule.Visible = false;
            //    moveWait.Visible = false;
            //}

        }

        protected void PopulateButton_Click(object sender, EventArgs e)
        {

            EmployeeFirstName.Value = string.Format("Employee");//populates a textbox
            EmployeePhone.Value = string.Format("8754853");
            EmployeeEmail.Value = string.Format("notalegitemail@gmail.com");
            Password.Value = string.Format("111");
            EmployeeAddress.Value = string.Format("1234 mainstreet USA");
            EmployeeLastName.Value = string.Format("McEmployeeFace");
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            EmployeeFirstName.Value = string.Format("");//clears a textbox
            EmployeePhone.Value = string.Format("");
            EmployeeEmail.Value = string.Format("");
            Password.Value = string.Format("");
            EmployeeAddress.Value = string.Format("");
            EmployeeLastName.Value = string.Format("");

        }
        protected void Submit_Click(object sender, EventArgs e)
        {
          

                //MissingInput.Text = string.Format("");


                String sqlQuery = "Select * from Employee";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;

                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                string FirstLast = HttpUtility.HtmlEncode(EmployeeFirstName.Value) + " " + HttpUtility.HtmlEncode(EmployeeLastName.Value);
                String userInput = FirstLast;
                
                String dbNames = "";
                String dbEmails = "";
                Boolean duplicate = false;

                while (queryResults.Read())
                {
                    dbNames = (queryResults["EmployeeName"].ToString());
                    dbEmails = (queryResults["EmployeeEmail"].ToString());
                    if (dbNames == userInput /*|| dbEmails == EmployeeEmail.Text*/)
                    {
                        duplicate = true;

                    }
                }

                queryResults.Close();//closes connection
                sqlConnect.Close();


                if (duplicate == false)
                {
                    String sqlQuery1 = "Insert into Employee (EmployeeName, EmployeePhone, EmployeeEmail, EmployeeAddress, EmployeeStatus, EmployeeType) Values (@EmployeeName, @EmployeePhone, @EmployeeEmail, @EmployeeAddress, 'Hired', @EmployeeType)";
                    SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand1 = new SqlCommand();
                    sqlCommand1.Parameters.AddWithValue("EmployeeName", FirstLast);
                    sqlCommand1.Parameters.AddWithValue("EmployeePhone", HttpUtility.HtmlEncode(EmployeePhone.Value));
                    sqlCommand1.Parameters.AddWithValue("EmployeeEmail", HttpUtility.HtmlEncode(EmployeeEmail.Value));
                    sqlCommand1.Parameters.AddWithValue("EmployeeAddress", HttpUtility.HtmlEncode(EmployeeAddress.Value));
                    String employeeType = "";
                    if (rankDDL.Text.Equals("Employee"))
                    {
                        employeeType = "E";
                    }
                    if (rankDDL.Text.Equals("Mover"))
                    {
                        employeeType = "M";
                    }
                    if (rankDDL.Text.Equals("Driver"))
                    {
                        employeeType = "D";
                    }
                    if (rankDDL.Text.Equals("Admin"))
                    {
                        employeeType = "A";
                    }
                    sqlCommand1.Parameters.AddWithValue("EmployeeType", HttpUtility.HtmlEncode(employeeType));



                    sqlCommand1.Connection = sqlConnect1;
                    sqlCommand1.CommandType = CommandType.Text;
                    sqlCommand1.CommandText = sqlQuery1;

                    sqlConnect1.Open();
                    SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();



                    queryResults1.Close();//closes connection
                    sqlConnect1.Close();





                    String sqlQuery4 = "Select EmployeeID from Employee where EmployeeName = @empName";
                    SqlConnection sqlConnect4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand4 = new SqlCommand();
                    sqlCommand4.Parameters.AddWithValue("empName", FirstLast);
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








                    //need to get the emp number for the employee name that i just input first

                    String sqlQuery3 = "Insert into WorkFlow (EmployeeID, ServiceID, StartDate, EndDate, Status) Values (@empID, @servID, @startD, @endD, @status)";
                    SqlConnection sqlConnect3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand3 = new SqlCommand();
                    sqlCommand3.Parameters.AddWithValue("empID", employeeIDHold);
                    sqlCommand3.Parameters.AddWithValue("servID", '1');
                    sqlCommand3.Parameters.AddWithValue("startD", "1/1/2000");
                    sqlCommand3.Parameters.AddWithValue("endD", "1/2/2000");
                    sqlCommand3.Parameters.AddWithValue("status", "Hiring");



                    sqlCommand3.Connection = sqlConnect3;
                    sqlCommand3.CommandType = CommandType.Text;
                    sqlCommand3.CommandText = sqlQuery3;

                    sqlConnect3.Open();
                    SqlDataReader queryResults3 = sqlCommand3.ExecuteReader();



                    queryResults3.Close();//closes connection
                    sqlConnect3.Close();




                    String sqlQuery2 = "Insert into ELogin(UserName, Password) Values (@EmployeeEmail, @CPassword)";

                    SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);

                    SqlCommand sqlCommand2 = new SqlCommand();

                    String HashPass = PasswordHash.HashPassword(Password.Value);

                    sqlCommand2.Parameters.AddWithValue("EmployeeEmail", HttpUtility.HtmlEncode(EmployeeEmail.Value));
                    sqlCommand2.Parameters.AddWithValue("CPassword", HashPass);



                    sqlCommand2.Connection = sqlConnect2;
                    sqlCommand2.CommandType = CommandType.Text;
                    sqlCommand2.CommandText = sqlQuery2;

                    sqlConnect2.Open();
                    SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();



                    queryResults2.Close();//closes connection
                    sqlConnect2.Close();



                    //TestLabel.Text = string.Format("New Employee Added");


                }
                else
                {
                    EmployeeFirstName.Value = "nope";
                    //TestLabel.Text = string.Format("A User with this name and/or email already exists.");
                }





            
        }


        protected void NewCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogNewCustomer.aspx");
        }

        protected void NewEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogNewEmployee.aspx");
        }

        protected void CustomerInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogCustomerInfo.aspx");
        }

        protected void EmployeeInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogEmployeeInfo.aspx");
        }

        protected void InventoryInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogInvInfo.aspx");
        }

        protected void NewService_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogNewService.aspx");
        }




        protected void ServiceInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogServiceInfo.aspx");
        }

        protected void NewWorkFlow_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogNewWorkflow.aspx");
        }
        protected void WorkFlowInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogWorkFlowInfo.aspx");
        }
        protected void NewItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogNewItem.aspx");
        }
        protected void equipMana_Click(object sender, EventArgs e)
        {
            Response.Redirect("EquipmentManagement.aspx");
        }

        protected void noteMgmt_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedNotes.aspx");
        }
        protected void serviceEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogServiceTicketEdit.aspx");
        }

        protected void servReq_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogServiceRequest.aspx");
        }
        protected void invAuction_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogInvToAuction.aspx");
        }
        protected void newAuction_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogCreateNewAuction.aspx");
        }
        protected void AuctionInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogAuctionInfo.aspx");
        }
        protected void MovingSchedule_Click(object sender, EventArgs e)
        {
            Response.Redirect("MoveSchedule.aspx");
        }
        protected void moveFormBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogMoveFormInfo.aspx");
        }

        protected void PhoneReqBtn_Click(object sender, EventArgs e)
        {
            //Response.Redirect("LogCustServCreation.aspx?employeeadd=true");
            Response.Redirect("AddCustByPhone.aspx");
        }

        protected void CustPortalBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustHistoryPage.aspx");
        }

        protected void Reports_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogReport.aspx");
        }

        protected void Show_All_Information(object sender, EventArgs e)
        {

            table1.Rows.Clear();
            TableRow rowc = new TableRow();

            TableCell cellZ = new TableCell();
            TableCell cellX = new TableCell();
            TableCell cellC = new TableCell();
            TableCell cellV = new TableCell();


            cellZ.Text = "Employee Name";
            cellX.Text = "Employee Address";
            cellC.Text = "Employee Phone";
            cellV.Text = "Employee Email";

            rowc.Cells.Add(cellZ);
            rowc.Cells.Add(cellX);
            rowc.Cells.Add(cellC);
            rowc.Cells.Add(cellV);

            String hex = "#e9ecef";



            rowc.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);

            table1.Rows.Add(rowc);



            String sqlQuery = "Select EmployeeName, EmployeeAddress, EmployeePhone, EmployeeEmail FROM Employee WHERE EmployeeName = EmployeeName";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();


            while (queryResults.Read())
            {

                TableRow row = new TableRow();

                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                TableCell cell3 = new TableCell();
                TableCell cell4 = new TableCell();



                cell1.Text = queryResults["EmployeeName"].ToString();
                cell2.Text = queryResults["EmployeeAddress"].ToString();
                cell3.Text = queryResults["EmployeePhone"].ToString();
                cell4.Text = queryResults["EmployeeEmail"].ToString();

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);

                table1.Rows.Add(row);
            }

        }

        protected void btnLoadEmployeeData_Click(object sender, EventArgs e)
        {
            table1.Rows.Clear();
            TableRow rowc = new TableRow();

            TableCell cellZ = new TableCell();
            TableCell cellX = new TableCell();
            TableCell cellC = new TableCell();
            TableCell cellV = new TableCell();


            cellZ.Text = "Employee Name";
            cellX.Text = "Employee Address";
            cellC.Text = "Employee Phone";
            cellV.Text = "Employee Email";

            rowc.Cells.Add(cellZ);
            rowc.Cells.Add(cellX);
            rowc.Cells.Add(cellC);
            rowc.Cells.Add(cellV);

            String hex = "#e9ecef";

            rowc.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);

            table1.Rows.Add(rowc);

            String ChosenName = HttpUtility.HtmlEncode(DDL.SelectedValue);

            String sqlQuery = "Select EmployeeName, EmployeeAddress, EmployeePhone, EmployeeEmail FROM Employee WHERE EmployeeName = @DDL";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(DDL.Text));
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();

            //prints values taken from the database
            while (queryResults.Read()) //outpurs the stuff from the db into the display box
            {
                TableRow row = new TableRow();

                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                TableCell cell3 = new TableCell();
                TableCell cell4 = new TableCell();



                cell1.Text = queryResults["EmployeeName"].ToString();
                cell2.Text = queryResults["EmployeeAddress"].ToString();
                cell3.Text = queryResults["EmployeePhone"].ToString();
                cell4.Text = queryResults["EmployeeEmail"].ToString();

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);

                table1.Rows.Add(row);

            }





        }

        protected void MovingRadio_CheckedChanged(object sender, EventArgs e)
        {
            AuctionRadio.Checked = false;
            custList.Items.Clear();
            custList.Items.Add("Customer Name  |  Waiting time");
            String sqlQuery = "Select CustomerName, DateOfServiceRequest FROM Customer WHERE ServicedYN = @n AND descriptionOfNeeds IS NOT Null AND typeOfService = @Moving ORDER BY DateOfServiceRequest";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            String n = "0";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("n", n);
            sqlCommand.Parameters.AddWithValue("Moving", "Moving");
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            while (queryResults.Read())
            {
                DateTime past = DateTime.Parse(queryResults["DateOfServiceRequest"].ToString());
                TimeSpan duration = now - past;

                char[] delimiterChars = { '.' };
                string[] words = duration.ToString().Split(delimiterChars);
                String days = words[0].Trim();
                String hours = words[1].Trim();
                if (words.Length <= 2)
                {
                    days = "0";
                    hours = words[0].Trim();
                }

                custList.Items.Add(queryResults["CustomerName"].ToString() + " |  days: " + days);

            }


            queryResults.Close();
            sqlConnect.Close();


        }

        protected void AuctionRadio_CheckedChanged(object sender, EventArgs e)
        {
            MovingRadio.Checked = false;


            custList.Items.Clear();
            custList.Items.Add("Customer Name  |  Waiting time");
            String sqlQuery = "Select CustomerName,  DateOfServiceRequest FROM Customer WHERE ServicedYN = @n AND descriptionOfNeeds IS NOT Null AND typeOfService = @Auction ORDER BY DateOfServiceRequest";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            String n = "0";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("n", n);
            sqlCommand.Parameters.AddWithValue("Auction", "Auction");
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            while (queryResults.Read())
            {
                DateTime past = DateTime.Parse(queryResults["DateOfServiceRequest"].ToString());
                TimeSpan duration = now - past;

                char[] delimiterChars = { '.' };
                string[] words = duration.ToString().Split(delimiterChars);
                String days = words[0].Trim();
                String hours = words[1].Trim();
                if (words.Length <= 2)
                {
                    days = "0";
                    hours = words[0].Trim();
                }

                custList.Items.Add(queryResults["CustomerName"].ToString() + " |  days: " + days);

            }

            queryResults.Close();
            sqlConnect.Close();

        }

        protected void custList_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] delimiterChars = { '|' };
            string[] words = HttpUtility.HtmlEncode(custList.SelectedValue).Split(delimiterChars);
            String test2 = words[0].Trim();
            String CustName = words[0].Trim();
            UserInput.Text = HttpUtility.HtmlEncode(CustName);
        }

        protected void servCust_Click(object sender, EventArgs e)
        {
            String servType = "";
            String sqlQuery1 = "Select typeOfService FROM Customer WHERE CustomerName = @cName";
            SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            SqlCommand sqlCommand1 = new SqlCommand();

            sqlCommand1.Parameters.AddWithValue("cName", HttpUtility.HtmlEncode(UserInput.Text));
            sqlCommand1.Connection = sqlConnect1;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQuery1;
            sqlConnect1.Open();
            SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();
            while (queryResults1.Read())
            {
                servType = queryResults1["typeOfService"].ToString();

            }

            queryResults1.Close();
            sqlConnect1.Close();




            String sqlQuery = "Select CustomerName FROM Customer WHERE ServicedYN = @n AND descriptionOfNeeds IS NOT Null";//how to count the number of customers waiting on service

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            String n = "0";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("n", n);
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            int i = 0;
            String userInput = HttpUtility.HtmlEncode(UserInput.Text);
            Boolean match = false;
            while (queryResults.Read())
            {
                String customerName = "";
                customerName = (queryResults["CustomerName"].ToString());
                if (customerName == userInput)
                {
                    match = true;

                }
            }
            queryResults.Close();//closes connection
            sqlConnect.Close();

            if (match == true && servType == "Moving")
            {
                Response.Redirect("LogCustServCreation.aspx?SendCustName=" + userInput);
            }
            else if (match == true && servType == "Auction")
            {
                Response.Redirect("LoggedCustServAuction.aspx?SendCustName=" + userInput);
            }
            else
            {
               //matchCheck.Text = "This customer either does not exist, or does not request a new service. Please select one from the list.";
            }



            //need to verify that the customer name is in the list. can use same code that pulled the customer name from before
            //throw an error if not the same
            //if its a real customer that need service link to the service ticket creation, import the data needed
        }

        protected void CustomerInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] delimiterChars = { '|' };
            string[] words = HttpUtility.HtmlEncode(CustomerInfo.SelectedValue).Split(delimiterChars);
            String test2 = words[0].Trim();
            String CustName = words[0].Trim();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            char[] delimiterChars = { '|' };
            string[] words = HttpUtility.HtmlEncode(CustomerInfo.SelectedValue).Split(delimiterChars);
            String test2 = words[0].Trim();
            String CustName = words[0].Trim();

            String ChosenName = HttpUtility.HtmlEncode(CustName);

            if (ChosenName != "")
            {
                Response.Redirect("EstimateWorkSheet.aspx?sendName=" + ChosenName);
            }
            else
            {
                //Label3.Text = "You need to select a customer before going to the next screen";
            }

        }

        protected void Auction_Click(object sender, EventArgs e)
        {
            String SendCustName = HttpUtility.HtmlEncode(UserInput.Text);



            if (SendCustName != "")
            {
                Response.Redirect("LogAvailableAuctions.aspx?SendCustName=" + SendCustName);
            }
            else
            {
                //Label1.Text = "You need to select a customer before going to the next screen";
            }
        }

        protected void custInvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] delimiterChars = { '|' };
            string[] words = HttpUtility.HtmlEncode(custInvList.SelectedValue).Split(delimiterChars);
            String test2 = words[0].Trim();
            String CustName = words[0].Trim();
            Textbox1.Text = HttpUtility.HtmlEncode(CustName);
        }
    }
}