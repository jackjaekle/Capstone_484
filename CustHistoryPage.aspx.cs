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




            if (!IsPostBack)
            {
                InfoGV.Visible = true;
                Label2.Visible = true;
                SvcLB.Visible = true;
                Label1.Visible = true;
                Label3.Visible = true;
                Label8.Visible = true;

                UpdateBtn.Visible = true;
               
                HistoryGV.Visible = true;
                EquipmentGV.Visible = true;
                NoteGV.Visible = true;

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
          NameLbl.Text = "Selected Customer: " + CustLB.SelectedValue.ToString();
           

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

        protected void NewCustomerBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCustByPhone.aspx");
        }

        protected void MainMenuBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx");
        }


        protected void CustLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label5.Text = "";
            Label6.Text = "";
            Label7.Text = "";

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
            Label5.Text = "";
            Label6.Text = "";
            Label7.Text = "";

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
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT Service.ServiceName, Service.ServiceDate, Service.CompletionDate, Service.UpdateStatus, Service.PaymentStatus, Service.Origin, Service.Destination FROM Service INNER JOIN Workflow ON Service.ServiceID = Workflow.ServiceID WHERE Service.ServiceID != 1 AND Service.ServiceName = '"+ svcNmB + "' AND Service.CustomerID = " + yCID, sqlConnect2);
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
                        Label5.Text = "There are currently no employees assgined to this Service";
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
                        Label6.Text = "There is currently no equipment assgined to this Service";
                    }

                }
            }

            //heres the part for the notes
            String svcNm2 = SvcLB.SelectedValue.ToString();
            char separator2 = '|';
            String[] svcNm4 = svcNm2.Split(separator2);
            String svcNm3 = svcNm4[0];

            using (SqlConnection sqlConnectD = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))
            {
                {
                    // Populate Employee Gridview based off SvcName
                    sqlConnectD.Open();
                    SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT Service.ServiceName, Note.NoteTitle, Note.NoteBody" +
                        " FROM Workflow INNER JOIN Service ON Workflow.ServiceID = Service.ServiceID INNER JOIN  Note ON Workflow.WorkflowID = Note.WorkflowID WHERE Service.ServiceID != 1 AND Service.ServiceName = " + "'" + svcNm3 + "'", sqlConnectD);
                    DataTable dt2 = new DataTable();
                    adapter2.Fill(dt2);
                    NoteGV.DataSource = dt2;
                    NoteGV.DataBind();

                    if (dt2.Rows.Count == 0)
                    {
                        Label7.Text = "There are currently no notes associated with this Service";
                    }

                }
            }


        }
    }
}