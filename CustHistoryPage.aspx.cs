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
    public partial class CustHistoryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (ddlMoveForm.Items.Count == 0)
            {
                //dtaSrcMoveFormID.SelectCommand = "Select s.ServiceName, e.MoveFormID FROM Service s, MoveForm e WHERE s.ServiceID = e.ServiceID";
                //ddlMoveForm.DataTextField = "ServiceName";
                //ddlMoveForm.DataValueField = "MoveFormID";
                String sqlQuery = "Select s.ServiceName FROM Service s, MoveForm e WHERE s.ServiceID = e.ServiceID";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    ddlMoveForm.Items.Add(queryResults["ServiceName"].ToString());


                }

                sqlConnect.Close();
            }


            if (!IsPostBack)
            {
                InfoGV.Visible = true;
                //Label2.Visible = true;
                SvcLB.Visible = true;
                //Label1.Visible = true;
                //Label3.Visible = true;
                //Label8.Visible = true;

                UpdateBtn.Visible = true;

                HistoryGV.Visible = true;
                EquipmentGV.Visible = true;
                NoteGV.Visible = true;


                //Label10.Visible = false;
                noteBody.Visible = false;
               // Label9.Visible = false;
                noteTitle.Visible = false;
                noteCreate.Visible = false;
                UpdateNote.Visible = false;
                //testlbl.Visible = false;

                // Populate ListBox
                String sqlQuery1 = "Select CustomerName FROM Customer ORDER BY CustomerName";
                SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand1 = new SqlCommand();
                sqlCommand1.Connection = sqlConnect1;
                sqlCommand1.CommandType = CommandType.Text;
                sqlCommand1.CommandText = sqlQuery1;
                sqlConnect1.Open();
                SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();
                while (queryResults1.Read())
                {
                    String cName = queryResults1["CustomerName"].ToString();
                    CustLB.Items.Add(cName.ToString());
                }
                queryResults1.Close();
                sqlConnect1.Close();

                // Clear old customers services from LB
                //SvcLB.Items.Clear();

            }
            NameLbl.Value = "Selected Customer: " + CustLB.SelectedValue.ToString();


        }





        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            String ChosenService = SvcLB.SelectedValue.ToString();
            char separator = '|';
            String[] svcNmA = ChosenService.Split(separator);
            String svcNmB = svcNmA[0];

            Response.Redirect("LogServiceTicketEdit.aspx?sendService=" + svcNmB);
        }



        protected void NewServiceBtn_Click(object sender, EventArgs e)
        {
            String custName = CustLB.SelectedValue.ToString();
            Response.Redirect("AddServiceByPhone.aspx?sendName=" + custName);
        }

      

        protected void MainMenuBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx");
        }


        protected void CustLB_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  Label5.Text = "";
           // Label6.Text = "";
            //Label7.Text = "";

            InfoGV.Visible = false;
            NoteGV.Visible = false;
            HistoryGV.Visible = false;
            EquipmentGV.Visible = false;
            notesList.Items.Clear();


            // Clear old customers services from LB
            SvcLB.Items.Clear();

            // Get CID

            SqlConnection sqlConnectCID = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            sqlConnectCID.Open();

            String cidCheckA = "SELECT CustomerID FROM CUSTOMER WHERE CustomerName = @CustomerName";
            SqlCommand cCheckA = new SqlCommand(cidCheckA, sqlConnectCID);
            cCheckA.Parameters.AddWithValue("@CustomerName", CustLB.SelectedValue.ToString());
            int nCID = Convert.ToInt32(cCheckA.ExecuteScalar());



            // Populate tickets DL
            SqlConnection sqlConnectSvc1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            sqlConnectSvc1.Open();
            // Query for getting servicenames based on cid
            String tickNoA1 = "SELECT CustomerPhone, CustomerEmail, CustomerFoundUsBy, CustomerCurrentAddress from Customer Where CustomerID = @ID";

            SqlCommand sqlCmdSvc1 = new SqlCommand(); // Command needs these 3 things
            sqlCmdSvc1.Connection = sqlConnectSvc1;
            sqlCmdSvc1.CommandType = CommandType.Text;
            sqlCmdSvc1.Parameters.AddWithValue("ID", nCID);
            sqlCmdSvc1.CommandText = tickNoA1;

            // Takes all the data from query and executes
            SqlDataReader queryResultSvc1 = sqlCmdSvc1.ExecuteReader();

            while (queryResultSvc1.Read()) // Populate Ticket Number dropdown
            {
                add.Text = queryResultSvc1["CustomerCurrentAddress"].ToString();
                phone.Text = queryResultSvc1["CustomerPhone"].ToString();
                email.Text = queryResultSvc1["CustomerEmail"].ToString();
                disc.Text = queryResultSvc1["CustomerFoundUsBy"].ToString();


            }


            // Populate tickets DL
            SqlConnection sqlConnectSvc = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            sqlConnectSvc.Open();
            // Query for getting servicenames based on cid
            String tickNoA = "SELECT DISTINCT ServiceName, ServiceDate FROM Service WHERE ServiceID != 1 AND CustomerID = " + nCID;

            SqlCommand sqlCmdSvc = new SqlCommand(); // Command needs these 3 things
            sqlCmdSvc.Connection = sqlConnectSvc;
            sqlCmdSvc.CommandType = CommandType.Text;
            sqlCmdSvc.CommandText = tickNoA;

            // Takes all the data from query and executes
            SqlDataReader queryResultSvc = sqlCmdSvc.ExecuteReader();
            SvcLB.Items.Clear();
            while (queryResultSvc.Read()) // Populate Ticket Number dropdown
            {
                String xSID = queryResultSvc["ServiceName"].ToString();
                String xsDate = queryResultSvc["ServiceDate"].ToString();
                // UpdateDL.Items.Add(SID);
                SvcLB.Items.Add(xSID + "|" + xsDate);
            }
            SvcLB.Items.Add("");

            queryResultSvc.Close();


            SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            sqlConnect2.Open();

            String cidCheck = "SELECT CustomerID FROM CUSTOMER WHERE CustomerName = @CustomerName";
            SqlCommand cCheck = new SqlCommand(cidCheck, sqlConnect2);
            cCheck.Parameters.AddWithValue("@CustomerName", CustLB.SelectedValue.ToString());

            int yCID = Convert.ToInt32(cCheck.ExecuteScalar());
            sqlConnect2.Close();

            // Populate tickets DL
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            sqlConnect.Open();
            // Query for getting servicenames based on cid
            String tickNo = "SELECT DISTINCT ServiceName, ServiceDate FROM Service WHERE ServiceID != 1  AND CustomerID = " + yCID;

            SqlCommand sqlCmd1 = new SqlCommand(); // Command needs these 3 things
            sqlCmd1.Connection = sqlConnect;
            sqlCmd1.CommandType = CommandType.Text;
            sqlCmd1.CommandText = tickNo;

            // Takes all the data from query and executes
            SqlDataReader queryResult = sqlCmd1.ExecuteReader();
            SvcLB.Items.Clear();
            while (queryResult.Read()) // Populate Ticket Number dropdown
            {
                String SID = queryResult["ServiceName"].ToString();
                String sDate = queryResult["ServiceDate"].ToString();
                // UpdateDL.Items.Add(SID);
                SvcLB.Items.Add(SID + "|" + sDate);

            }
            SvcLB.Items.Add("");

            queryResult.Close();

        }
        protected void SvcLB_SelectedIndexChanged(object sender, EventArgs e)
        {
           // Label5.Text = "";
            //Label6.Text = "";
            //Label7.Text = "";
            InfoGV.Visible = true;
            NoteGV.Visible = true;
            HistoryGV.Visible = true;
            EquipmentGV.Visible = true;
            ProgressTbl.Visible = true;

            //heres the part for the notes
            String svcNm22 = SvcLB.SelectedValue.ToString();
            char separator22 = '|';
            String[] svcNm42 = svcNm22.Split(separator22);
            String svcNm32 = svcNm42[0];

            //heres the part for the notes
            String svcNm21 = notesList.SelectedValue.ToString();
            char separator21 = '|';
            String[] svcNm41 = svcNm21.Split(separator21);
            String svcNm31 = svcNm41[0];

            using (SqlConnection sqlConnectD = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))
            {
                {
                    // Populate Employee Gridview based off SvcName
                    sqlConnectD.Open();
                    // for just one result SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT Service.ServiceName, Note.NoteTitle, Note.NoteBody FROM Workflow INNER JOIN Service ON Workflow.ServiceID = Service.ServiceID INNER JOIN  Note ON Workflow.WorkflowID = Note.WorkflowID WHERE Service.ServiceID != 1 AND Note.NoteTitle = " +"'"+ svcNm21 +"'"+ "AND Service.ServiceName = "+ "'"+svcNm3 + "'", sqlConnectD);
                    SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT Service.ServiceName, Note.NoteTitle, Note.NoteBody FROM Workflow INNER JOIN Service ON Workflow.ServiceID = Service.ServiceID INNER JOIN  Note ON Workflow.WorkflowID = Note.WorkflowID WHERE Service.ServiceID != 1 AND Service.ServiceName = " + "'" + svcNm32 + "'", sqlConnectD);
                    DataTable dt2 = new DataTable();
                    adapter2.Fill(dt2);
                    NoteGV.DataSource = dt2;
                    NoteGV.DataBind();

                    if (dt2.Rows.Count == 0)
                    {
                       // Label7.Text = "There are currently no notes associated with this Service";
                    }

                }
            }









            //heres the part for the employees and the equipment
            String svcNm = SvcLB.SelectedValue.ToString();
            char separator = '|';
            String[] svcNmA = svcNm.Split(separator);
            String svcNmB = svcNmA[0];



            SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            sqlConnect2.Open();

            String cidCheck = "SELECT CustomerID FROM CUSTOMER WHERE CustomerName = @CustomerName";
            SqlCommand cCheck = new SqlCommand(cidCheck, sqlConnect2);
            cCheck.Parameters.AddWithValue("@CustomerName", CustLB.SelectedValue.ToString());


            int yCID = Convert.ToInt32(cCheck.ExecuteScalar());

            using (SqlConnection sqlConnectA = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))

            {
                {
                    // Populate Gridview based off CID
                    sqlConnectA.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT Service.ServiceName, Service.ServiceDate, Service.CompletionDate, Service.UpdateStatus, Service.PaymentStatus, Service.Origin, Service.Destination FROM Service INNER JOIN Workflow ON Service.ServiceID = Workflow.ServiceID WHERE Service.ServiceID != 1 AND Service.ServiceName = '" + svcNmB + "' AND Service.CustomerID = " + yCID, sqlConnect2);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    InfoGV.DataSource = dt;
                    InfoGV.DataBind();

                }
            }

            sqlConnect2.Close();






            using (SqlConnection sqlConnectC = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))
            {
                {

                    // Populate Employee Gridview based off SvcName
                    sqlConnectC.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT Service.ServiceName, Employee.EmployeeName, Employee.EmployeeEmail, Workflow.StartDate, Workflow.EndDate, Workflow.Status FROM Workflow INNER JOIN Service ON Workflow.ServiceID = Service.ServiceID INNER JOIN Employee ON Workflow.EmployeeID = Employee.EmployeeID WHERE Service.ServiceID != 1 AND Service.ServiceName = " + "'" + svcNmB + "'", sqlConnectC);
                    DataTable dtA = new DataTable();
                    adapter.Fill(dtA);
                    HistoryGV.DataSource = dtA;
                    HistoryGV.DataBind();

                    if (dtA.Rows.Count == 0)
                    {
                      //  Label5.Text = "There are currently no employees assgined to this Service";
                    }

                }
            }

            using (SqlConnection sqlConnectB = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))
            {
                {
                    // Populate  Equipment Gridview based off SvcName
                    sqlConnectB.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT Service.ServiceName, Equipment.EquipmentName, EquipmentRent.RentCondition, EquipmentRent.ReturnCondition, EquipmentRent.RentDate, EquipmentRent.ReturnDate FROM Equipment INNER JOIN EquipmentRent ON Equipment.EquipmentID = EquipmentRent.EquipmentID INNER JOIN Service ON EquipmentRent.ServiceID = Service.ServiceID WHERE Service.ServiceID != 1 AND Service.ServiceName = " + "'" + svcNmB + "'", sqlConnectB);
                    DataTable dtB = new DataTable();
                    adapter.Fill(dtB);
                    EquipmentGV.DataSource = dtB;
                    EquipmentGV.DataBind();

                    if (dtB.Rows.Count == 0)
                    {
                      //  Label6.Text = "There is currently no equipment assgined to this Service";
                    }

                }
            }


            //make it so that it clears, then popualtes the notes listbox

            notesList.Items.Clear();


            String svcNm2 = SvcLB.SelectedValue.ToString();
            char separator2 = '|';
            String[] svcNmA2 = svcNm2.Split(separator2);
            String svcNmB2 = svcNmA2[0];



            String serviceName = HttpUtility.HtmlEncode(svcNmB2);
            String serviceID = "";
            String sqlQuery3 = "Select ServiceID FROM Service WHERE @ServiceName = ServiceName and ServiceID != 1";  //pull the service ID based off the service name
            SqlConnection sqlConnect3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlCommand sqlCommand3 = new SqlCommand();
            sqlCommand3.Parameters.AddWithValue("ServiceName", serviceName);
            sqlCommand3.Connection = sqlConnect3;
            sqlCommand3.CommandType = CommandType.Text;
            sqlCommand3.CommandText = sqlQuery3;


            sqlConnect3.Open();

            SqlDataReader queryResults3 = sqlCommand3.ExecuteReader();

            //prints values taken from the database
            while (queryResults3.Read())
            {
                serviceID = (queryResults3["ServiceID"].ToString());
            }
            queryResults3.Close();//closes connection
            sqlConnect3.Close();

            //"Select WorkflowID from FROM Workflow WHERE ServiceID =  @ServiceID";
            String sqlQuery4 = "Select s.NoteTitle FROM Note s, Workflow e WHERE e.ServiceID = @ServiceID AND e.WorkflowID = s.WorkflowID AND e.ServiceID != 1";
            SqlConnection sqlConnect4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlCommand sqlCommand4 = new SqlCommand();

            sqlCommand4.Parameters.AddWithValue("ServiceID", serviceID);
            sqlCommand4.Connection = sqlConnect4;
            sqlCommand4.CommandType = CommandType.Text;
            sqlCommand4.CommandText = sqlQuery4;

            sqlConnect4.Open();
            // testlbl.Text = serviceID;
            SqlDataReader queryResults4 = sqlCommand4.ExecuteReader();

            //prints values taken from the database

            while (queryResults4.Read())
            {
                notesList.Items.Add(queryResults4["NoteTitle"].ToString());  //pull and display all service names
            }
            queryResults4.Close();//closes connection
            sqlConnect4.Close();




            //heres the part to get the status bar displayed


            String serviceStatus = "";
            String payStatus = "";


            //Service name stored in this variable svcNmB
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            sqlConnect.Open();

            // Query for getting updateStatus
            String updateString = "SELECT UpdateStatus, PaymentStatus FROM Service WHERE ServiceID != 1  AND ServiceName = " + "'" + svcNmB + "'";

            SqlCommand sqlCmd1 = new SqlCommand(); // Command needs these 3 things
            sqlCmd1.Connection = sqlConnect;
            sqlCmd1.CommandType = CommandType.Text;
            sqlCmd1.CommandText = updateString;

            // Takes all the data from query and executes
            SqlDataReader queryResult = sqlCmd1.ExecuteReader();

            while (queryResult.Read()) // Populate Ticket Number dropdown
            {
                serviceStatus = queryResult["UpdateStatus"].ToString();
                payStatus = queryResult["PaymentStatus"].ToString();

            }

            Bar0.Visible = false;
            Bar1.Visible = false;
            Bar2.Visible = false;
            Bar3.Visible = false;
            Bar4.Visible = false;
            Bar5.Visible = false;
            Bar6.Visible = false;

            //Start choosing which bar to display
            if (serviceStatus.Equals("") && payStatus.Equals(""))
            {
                Bar0.Visible = true;
                Lbl0.Text = "Service Status - Waiting for Scheduling | Payment Status - NOT RECEIVED";
            }
            else if (serviceStatus.Equals("Not Started") && payStatus.Equals("Incomplete"))
            {
                Bar1.Visible = true;
                Lbl1.Text = "Service Status - NOT STARTED | Payment Status - NOT RECEIVED";
            }
            else if (serviceStatus.Equals("Not Started") && payStatus.Equals("Complete"))
            {
                Bar2.Visible = true;
                Lbl2.Text = "Service Status - NOT STARTED | Payment Status - RECEIVED";
            }
            else if (serviceStatus.Equals("In Progress") && payStatus.Equals("Incomplete"))
            {
                Bar3.Visible = true;
                Lbl3.Text = "Service Status - IN PROGRESS | Payment Status - NOT RECEIVED";
            }
            else if (serviceStatus.Equals("In Progress") && payStatus.Equals("Complete"))
            {
                Bar4.Visible = true;
                Lbl4.Text = "Service Status - IN PROGRESS | Payment Status - RECEIVED";
            }
            else if (serviceStatus.Equals("Complete") && payStatus.Equals("Incomplete"))
            {
                Bar5.Visible = true;
                Lbl5.Text = "Service Status - COMPLETE| Payment Status - NOT RECEIVED";

            }
            else if (serviceStatus.Equals("Complete") && payStatus.Equals("Complete"))
            {
                Bar6.Visible = true;
                Lbl6.Text = "Service Status - COMPLETE | Payment Status - RECEIVED";

            }
            else
            {
                Bar0.Visible = true;
                Lbl0.Text = "The Services status is in limbo.";
            }

            queryResult.Close();


        }




        protected void notesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //is for wheneveer they change their selected note


            //heres the part for the notes
            String svcNm2 = SvcLB.SelectedValue.ToString();
            char separator2 = '|';
            String[] svcNm4 = svcNm2.Split(separator2);
            String svcNm3 = svcNm4[0];

            //heres the part for the notes
            String svcNm21 = notesList.SelectedValue.ToString();
            char separator21 = '|';
            String[] svcNm41 = svcNm2.Split(separator2);
            String svcNm31 = svcNm4[0];

            using (SqlConnection sqlConnectD = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))
            {
                {
                    // Populate Employee Gridview based off SvcName
                    sqlConnectD.Open();
                    // for just one result SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT Service.ServiceName, Note.NoteTitle, Note.NoteBody FROM Workflow INNER JOIN Service ON Workflow.ServiceID = Service.ServiceID INNER JOIN  Note ON Workflow.WorkflowID = Note.WorkflowID WHERE Service.ServiceID != 1 AND Note.NoteTitle = " +"'"+ svcNm21 +"'"+ "AND Service.ServiceName = "+ "'"+svcNm3 + "'", sqlConnectD);
                    SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT Service.ServiceName, Note.NoteTitle, Note.NoteBody FROM Workflow INNER JOIN Service ON Workflow.ServiceID = Service.ServiceID INNER JOIN  Note ON Workflow.WorkflowID = Note.WorkflowID WHERE Service.ServiceID != 1 AND Service.ServiceName = " + "'" + svcNm3 + "'", sqlConnectD);
                    DataTable dt2 = new DataTable();
                    adapter2.Fill(dt2);
                    NoteGV.DataSource = dt2;
                    NoteGV.DataBind();

                    if (dt2.Rows.Count == 0)
                    {
                       // Label7.Text = "There are currently no notes associated with this Service";
                    }

                }
            }


        }


        protected void editNote_Click(object sender, EventArgs e)
        {
            //testlb.Text = "";
            //Label10.Visible = true;
            noteBody.Visible = true;
            UpdateNote.Visible = true;
           // testlbl.Visible = true;
           // Label9.Visible = false;
            noteTitle.Visible = false;
            noteCreate.Visible = false;
            //need to populate the textbox with the current description, and then also save it to the note.





            String svcNm2 = SvcLB.SelectedValue.ToString();
            char separator2 = '|';
            String[] svcNm4 = svcNm2.Split(separator2);
            String svcNm3 = svcNm4[0];

            //heres the part for the notes
            String svcNm21 = notesList.SelectedValue.ToString();
            char separator21 = '|';
            String[] svcNm41 = svcNm2.Split(separator2);
            String svcNm31 = svcNm4[0];

            //"Select WorkflowID from FROM Workflow WHERE ServiceID =  @ServiceID";
            String sqlQuery4 = "SELECT Service.ServiceName, Note.NoteTitle, Note.NoteBody FROM Workflow INNER JOIN Service ON Workflow.ServiceID = Service.ServiceID INNER JOIN  Note ON Workflow.WorkflowID = Note.WorkflowID WHERE Service.ServiceID != 1 AND Note.NoteTitle = " + "'" + svcNm21 + "'" + "AND Service.ServiceName = " + "'" + svcNm3 + "'";
            SqlConnection sqlConnect4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlCommand sqlCommand4 = new SqlCommand();


            sqlCommand4.Connection = sqlConnect4;
            sqlCommand4.CommandType = CommandType.Text;
            sqlCommand4.CommandText = sqlQuery4;

            sqlConnect4.Open();
            // testlbl.Text = serviceID;
            SqlDataReader queryResults4 = sqlCommand4.ExecuteReader();

            //prints values taken from the database

            while (queryResults4.Read())
            {
                noteBody.Text = queryResults4["NoteBody"].ToString();
            }
            queryResults4.Close();//closes connection
            sqlConnect4.Close();
        }


        protected void UpdateNote_Click(object sender, EventArgs e)
        {
           // testlbl.Text = "";

            String svcNm21 = notesList.SelectedValue.ToString();


            String sqlQuery4 = "Update Note Set NoteBody = @NoteInfo WHERE NoteTitle = @NoteTitle";
            SqlConnection sqlConnect4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand4 = new SqlCommand();
            String NoteTitle = HttpUtility.HtmlEncode(svcNm21);
            sqlCommand4.Parameters.AddWithValue("NoteInfo", HttpUtility.HtmlEncode(noteBody.Text));
            sqlCommand4.Parameters.AddWithValue("NoteTitle", NoteTitle);


            sqlCommand4.Connection = sqlConnect4;
            sqlCommand4.CommandType = CommandType.Text;
            sqlCommand4.CommandText = sqlQuery4;
            sqlConnect4.Open();
            SqlDataReader queryResults4 = sqlCommand4.ExecuteReader();
            queryResults4.Close();
            sqlConnect4.Close();
           // testlbl.Text = "Record Updated";

            noteCreate.Visible = false;
            //Label10.Visible = false;
            noteBody.Visible = false;
           //Label9.Visible = false;
            noteTitle.Visible = false;
            noteCreate.Visible = false;
            UpdateNote.Visible = false;
           // testlbl.Visible = true;


        }

        protected void newNote_Click(object sender, EventArgs e)
        {
          // Label10.Visible = true;
            noteBody.Visible = true;
           // Label9.Visible = true;
            noteTitle.Visible = true;
            noteCreate.Visible = true;
          //  testlbl.Visible = true;
          //  testlbl.Text = "";
            noteTitle.Text = "";
            noteBody.Text = "";
            UpdateNote.Visible = false;

        }

        protected void noteCreate_Click(object sender, EventArgs e)
        {



            String svcNm2 = SvcLB.SelectedValue.ToString();
            char separator2 = '|';
            String[] svcNm4 = svcNm2.Split(separator2);
            String svcNm3 = svcNm4[0];


            String workFlowID = "";
            String sqlQuery6 = "Select s.WorkflowID FROM WorkFlow s, Service e WHERE e.ServiceID = s.ServiceID AND e.ServiceName = @jobname";           //how to see if the note name is a dupe
            SqlConnection sqlConnect6 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            String jobNames = HttpUtility.HtmlEncode(svcNm3);
            SqlCommand sqlCommand6 = new SqlCommand();
            sqlCommand6.Parameters.AddWithValue("jobname", jobNames);
            sqlCommand6.Connection = sqlConnect6;
            sqlCommand6.CommandType = CommandType.Text;
            sqlCommand6.CommandText = sqlQuery6;

            sqlConnect6.Open();
            SqlDataReader queryResults6 = sqlCommand6.ExecuteReader();


            while (queryResults6.Read())
            {
                workFlowID = "";
                workFlowID = (queryResults6["WorkFlowID"].ToString());
            }
            queryResults6.Close();//closes connection
            sqlConnect6.Close();


            String sqlQuery = "Select NoteTitle FROM Note Where WorkFlowID = @workFlowID ";           //how to see if the note name is a dupe
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("workFlowID", workFlowID);
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            String notetitle = "";
            String userInput = HttpUtility.HtmlEncode(noteTitle.Text);
            Boolean duplicate = false;

            while (queryResults.Read())
            {
                notetitle = "";
                notetitle = (queryResults["NoteTitle"].ToString());
                if (notetitle == userInput)
                {
                    duplicate = true;

                }
            }
            queryResults.Close();//closes connection
            sqlConnect.Close();

            if (duplicate == false)
            {

                if (noteTitle.Text != "")
                {

                    String sqlQuery2 = "Select s.WorkflowID FROM WorkFlow s, Service e WHERE e.ServiceID = s.ServiceID AND e.ServiceName = @jobname";

                    SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                    String jobName = HttpUtility.HtmlEncode(svcNm3);
                    SqlCommand sqlCommand2 = new SqlCommand();
                    sqlCommand2.Parameters.AddWithValue("jobname", jobName);
                    sqlCommand2.Connection = sqlConnect2;
                    sqlCommand2.CommandType = CommandType.Text;
                    sqlCommand2.CommandText = sqlQuery2;



                    sqlConnect2.Open();
                    String workflowID = "";
                    SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();

                    while (queryResults2.Read())
                    {
                        workflowID = "";
                        workflowID = (queryResults2["WorkFlowID"].ToString());
                    }
                    queryResults2.Close();
                    sqlConnect2.Close();





                    String sqlQuery3 = "Insert into Note (WorkflowID, NoteTitle, NoteBody) Values (@WorkFlowID, @NewNoteTitle, @NoteInfo)";

                    SqlConnection sqlConnect3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                    SqlCommand sqlCommand3 = new SqlCommand();
                    sqlCommand3.Parameters.AddWithValue("WorkFlowID", workflowID);
                    sqlCommand3.Parameters.AddWithValue("NewNoteTitle", HttpUtility.HtmlEncode(noteTitle.Text));
                    sqlCommand3.Parameters.AddWithValue("NoteInfo", HttpUtility.HtmlEncode(noteBody.Text));

                    sqlCommand3.Connection = sqlConnect3;
                    sqlCommand3.CommandType = CommandType.Text;
                    sqlCommand3.CommandText = sqlQuery3;
                    sqlConnect3.Open();

                    SqlDataReader queryResults3 = sqlCommand3.ExecuteReader();

                    queryResults3.Close();
                    sqlConnect3.Close();
                   // testlbl.Text = "New Note Created. Refresh page to view";
                   // Label10.Visible = false;
                    noteBody.Visible = false;
                  //  Label9.Visible = false;
                    noteTitle.Visible = false;
                    noteCreate.Visible = false;
                    UpdateNote.Visible = false;
                  //  testlbl.Visible = true;
                    noteBody.Text = "";
                    noteTitle.Text = "";

                }
                else if (noteTitle.Text == "")
                {
                   // testlbl.Text = "You need to name this note";
                   // testlbl.Visible = true;

                }

            }


            else
            {
               // testlbl.Text = "A note with this name already exists";
               // testlbl.Visible = true;
            }



        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String sqlQuery = "Select e.Stories, e.TruckDist, e.DrivewayAccess, e.LoadCondition FROM MoveForm e, Service s WHERE " +
                "s.ServiceID = e.ServiceID " +
                "AND s.ServiceName = @name";
            String sqlQuery2 = "SELECT r.Name, r.Floor, r.TypeofBoxes, r.NumOfBoxes, r.Blankets from Rooms r, Service s, MoveForm e WHERE " +
                "s.ServiceID = e.ServiceID " +
                "AND s.ServiceName = @name " +
                "AND r.MoveFormID = e.MoveFormID";
            String sqlQuery3 = "SELECT DISTINCT r.Floor from Rooms r, MoveForm e, Service s WHERE " +
                "s.ServiceID = e.ServiceID " +
                "AND s.ServiceName = @name " +
                "AND r.MoveFormID = e.MoveFormID";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnect;
            sqlCommand.Parameters.AddWithValue("name", HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue));
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect;
            sqlCommand2.Parameters.AddWithValue("name", HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue));
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuery2;


            SqlCommand sqlCommand3 = new SqlCommand();
            sqlCommand3.Connection = sqlConnect;
            sqlCommand3.Parameters.AddWithValue("name", HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue));
            sqlCommand3.CommandType = CommandType.Text;
            sqlCommand3.CommandText = sqlQuery3;

            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            grdMoveForm.DataSource = queryResults;
            grdMoveForm.DataBind();
            sqlConnect.Close();

            sqlConnect.Open();
            SqlDataReader query2Results = sqlCommand2.ExecuteReader();
            grdRoomInfo.DataSource = query2Results;
            grdRoomInfo.DataBind();
            sqlConnect.Close();

            sqlConnect.Open();
            SqlDataReader query3Results = sqlCommand3.ExecuteReader();
            ddlFloor.DataSource = query3Results;
            ddlFloor.DataBind();
            sqlConnect.Close();

            //lblMoveForm.Text = "MoveForm information for Service " + HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue);
            //lblRoomInfo.Text = "Rooms Information for Service " + HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue);

            btnShowFloor.Enabled = true;
            btnShowAll.Enabled = true;
            //btnSubmitItems.Enabled = false;
            //btnAddNewItem.Enabled = false;
        }
        protected void btnShowFloor_Click(object sender, EventArgs e)
        {
            String sqlQuery = "Select r.Name, r.Floor, r.TypeofBoxes, r.NumOfBoxes, r.Blankets FROM Rooms r, Service e, MoveForm s WHERE s.ServiceID = e.ServiceID AND r.MoveFormID = s.MoveFormID AND e.ServiceName = @name AND Floor = " + HttpUtility.HtmlEncode(ddlFloor.SelectedValue);
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.Parameters.AddWithValue("name", HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue));
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            grdRoomInfo.DataSource = queryResults;
            grdRoomInfo.DataBind();
            sqlConnect.Close();
          //  lblRoomInfo.Text = "Rooms Information for Service " + HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue) + ", Floor " + HttpUtility.HtmlEncode(ddlFloor.SelectedValue);

            fillRoomItemsDDL();

           // btnSubmitItems.Enabled = true;
           // btnAddNewItem.Enabled = true;
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            showAllRooms();
        }
        protected void fillRoomItemsDDL()
        {
            //Not a parameterized query bc it doesn't liek to rerun with the same name when you change the floor you're looking at 
            //Shouldn't matter bc the only input is from ddl's anyway, encoded too.
            dtaSrcRoomItemsID.SelectCommand = "Select r.Name, r.RoomID FROM Rooms r, Service e, MoveForm s WHERE s.ServiceID = e.ServiceID" +
                " AND e.ServiceName = '" + HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue) +
                "' AND r.MoveFormID = s.MoveFormID" +
                " AND r.Floor = '" + HttpUtility.HtmlEncode(ddlFloor.SelectedValue) + "'";
            ddlRooms.DataTextField = "Name";
            ddlRooms.DataValueField = "RoomID";
        }

        protected void showAllRooms()
        {
            String sqlQuery = "Select r.Name, r.Floor, r.TypeofBoxes, r.NumOfBoxes, r.Blankets FROM Rooms r, Service e, MoveForm s WHERE " +
                            "s.ServiceID = e.ServiceID " +
                            "AND e.ServiceName = @name " +
                            "AND r.MoveFormID = s.MoveFormID";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("name", HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue));
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            grdRoomInfo.DataSource = queryResults;
            grdRoomInfo.DataBind();
            sqlConnect.Close();

           // lblRoomInfo.Text = "Rooms Information for Service " + HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue);

            fillRoomItemsDDLAllFloors();

           // btnSubmitItems.Enabled = true;
           // btnAddNewItem.Enabled = true;
        }
        protected void fillRoomItemsDDLAllFloors()
        {
            //Not a parameterized query bc it doesn't liek to rerun with the same name when you change the floor you're looking at
            //Shouldn't matter bc the only input is from ddl's anyway, encoded too.
            dtaSrcRoomItemsID.SelectCommand = "Select r.Name, r.RoomID FROM Rooms r, Service e, MoveForm s WHERE s.ServiceID = e.ServiceID" +
                " AND e.ServiceName = '" + HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue) +
                "' AND r.MoveFormID = s.MoveFormID";
            ddlRooms.DataTextField = "Name";
            ddlRooms.DataValueField = "RoomID";
        }
        protected void btnSubmitItems_Click(object sender, EventArgs e)
        {
            refreshRoomItems();
            //lblItemInfo.Text = "Item Information for Room " + HttpUtility.HtmlEncode(ddlRooms.SelectedValue) + ", Floor " + HttpUtility.HtmlEncode(ddlFloor.SelectedValue);
        }
        protected void refreshRoomItems()
        {
            String sqlQuery = "Select distinct r.Name, r.Description, r.Action FROM RoomItems r, Rooms ro WHERE r.RoomID = " + HttpUtility.HtmlEncode(ddlRooms.SelectedValue);
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            grdViewItems.DataSource = queryResults;
            grdViewItems.DataBind();
            sqlConnect.Close();
        }
    }
}