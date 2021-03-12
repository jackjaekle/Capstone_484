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
        protected void Page_Load(object sender, EventArgs e)
        {

            String sqlQuery = "Select CustomerName FROM Customer WHERE ServicedYN = @n AND descriptionOfNeeds IS NOT Null";
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

            while (queryResults.Read())
            {
                i++;
            }
            queryResults.Close();//closes connection
            sqlConnect.Close();
            if (i == 1)
            {
                customersWait.Text = i + " Customer waiting on service";
            }
            else
            {
                customersWait.Text = i + " Customers waiting on service";
            }

            String sqlQuery1 = "Select ServiceName FROM Service WHERE AuctionedYN = @n";
            SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            String y = "0";
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Parameters.AddWithValue("n", y);
            sqlCommand1.Connection = sqlConnect1;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQuery1;

            sqlConnect1.Open();
            SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();
            int x = 0;

            while (queryResults1.Read())
            {
                x++;
            }
            queryResults1.Close();//closes connection
            sqlConnect1.Close();
            if (x == 1)
            {
                auctionWait.Text = x + " Customer Inventory waiting to be auctioned";
            }
            else
            {
                auctionWait.Text = x + " Customer Inventories waiting to be auctioned";
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


        protected void moveFormBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogMoveFormInfo.aspx");
        }
    }
}