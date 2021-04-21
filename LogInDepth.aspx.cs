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
    public partial class LogInDepth : System.Web.UI.Page
    {
        public int Cust { get; set; }
        public String CustomerName { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerName = Request.QueryString["SendCustomerName"];
           
            Label1.Text = HttpUtility.HtmlEncode(CustomerName);
            if (CustomerName == "")
            {
                Label1.Text = "Go back and select a Customer Name";
            }

            //Get customer ID
            String sqlQuery = "Select CustomerID FROM Customer WHERE CustomerName = @Cname";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("Cname", HttpUtility.HtmlEncode(CustomerName));
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            while (queryResults.Read())
            {
                String test = queryResults["CustomerID"].ToString();
                Cust = int.Parse(test);
            }

            queryResults.Close();
            sqlConnect.Close();

            //populate service DDL
            if (ListBox2.Items.Count == 0)
            {
                ListBox2.Items.Add("");
                ListBox2.Items.Add("General Customer Info");
                ListBox2.Items.Add("Customer Services");
                ListBox2.Items.Add("Customer Workflows");
                ListBox2.Items.Add("Customer Items");
                ListBox2.Items.Add("WorkFlow notes");
            }


        }

        protected void custStuff_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change what is put into the Info box base on whats selected in the DDL
            if (ListBox2.Text != "")
            {
                if (ListBox2.Text == "General Customer Info")
                {
                    Info_Box.Items.Clear();
                    Info_Box.Items.Add("Customer Name, Customer Phone, Customer Email"); //puts a header on the output

                    String sqlQuery = "Select CustomerName, CustomerEmail, CustomerPhone FROM Customer WHERE CustomerID = " + Cust;
                    SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnect;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = sqlQuery;


                    sqlConnect.Open();

                    SqlDataReader queryResults = sqlCommand.ExecuteReader();

                    //prints values taken from the database
                    while (queryResults.Read())
                    {
                        Info_Box.Items.Add(queryResults["CustomerName"].ToString() + " | " + queryResults["CustomerPhone"].ToString() + " | " + queryResults["CustomerEmail"].ToString());
                    }

                    queryResults.Close();
                    sqlConnect.Close();
                }

                else if (ListBox2.Text == "Customer Services")
                {
                    Info_Box.Items.Clear();
                    Info_Box.Items.Add("Service Name, Customer Phone, Customer Email"); //puts a header on the output

                    String sqlQuery = "Select ServiceName, ServiceDate, ServiceCost, CompletionDate FROM Service WHERE CustomerID = " + Cust;
                    SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnect;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = sqlQuery;


                    sqlConnect.Open();

                    SqlDataReader queryResults = sqlCommand.ExecuteReader();

                    //prints values taken from the database
                    while (queryResults.Read())
                    {
                        Info_Box.Items.Add(queryResults["ServiceName"].ToString() + " | " + queryResults["ServiceDate"].ToString() + " | " + queryResults["ServiceCost"].ToString() + " | " + queryResults["CompletionDate"].ToString());
                    }

                    queryResults.Close();
                    sqlConnect.Close();
                }

                else if (ListBox2.Text == "Customer Workflows")
                {

                    Info_Box.Items.Clear();
                    Info_Box.Items.Add("Employee Name, ServiceName, Start Date, End Date, Employee Role");

                    String ChosenName = HttpUtility.HtmlEncode(Label1.Text); //need to get the service name from service by suing service id as the linking factor. mix of the workflow and service tables

                    String sqlQuery = "Select t.EmployeeName, e.ServiceName, s.StartDate, s.EndDate, s.Status " +
                        "FROM WorkFlow s, Service e, Employee t, Customer l " +
                        "WHERE e.ServiceID = s.ServiceID AND t.EmployeeID = s.EmployeeID AND l.CustomerID = e.CustomerID AND l.CustomerName = @name";
                    SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Parameters.AddWithValue("name", ChosenName);

                    sqlCommand.Connection = sqlConnect;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = sqlQuery;


                    sqlConnect.Open();

                    SqlDataReader queryResults = sqlCommand.ExecuteReader();

                    //prints values taken from the database
                    while (queryResults.Read())
                    {
                        Info_Box.Items.Add(queryResults["EmployeeName"].ToString() + " | " + queryResults["ServiceName"].ToString() + " | " + queryResults["StartDate"].ToString() + " | " + queryResults["EndDate"].ToString() + " | " + queryResults["Status"].ToString());
                    }

                    queryResults.Close();
                    sqlConnect.Close();
                }

                else if (ListBox2.Text == "Customer Items")
                {
                    Info_Box.Items.Clear();
                    Info_Box.Items.Add("ItemDescription, ItemCost, InventoryDate"); //puts a header on the output

                    String ChosenName = HttpUtility.HtmlEncode(Label1.Text); //need to get the service name from service by suing service id as the linking factor. mix of the workflow and service tables

                    String sqlQuery2 = "Select s.ItemDescription, s.ItemCost, s.InventoryDate " +
                        "FROM Item s, Service e, Customer l " +
                        "WHERE e.ServiceID = s.ServiceID AND l.CustomerID = e.CustomerID AND l.CustomerName = @name";
                    SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand2 = new SqlCommand();
                    sqlCommand2.Parameters.AddWithValue("name", ChosenName);
                    sqlCommand2.Connection = sqlConnect2;
                    sqlCommand2.CommandType = CommandType.Text;
                    sqlCommand2.CommandText = sqlQuery2;
                    sqlConnect2.Open();
                    SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();
                    while (queryResults2.Read())
                    {
                        Info_Box.Items.Add(queryResults2["ItemDescription"].ToString() + " | " + queryResults2["ItemCost"].ToString() + " | " + queryResults2["InventoryDate"].ToString());
                    }

                    queryResults2.Close();
                    sqlConnect2.Close();
                }

                else if (ListBox2.Text == "WorkFlow notes")
                {
                    Info_Box.Items.Clear();
                    Info_Box.Items.Add("NoteTitle, NoteBody"); //puts a header on the output

                    String ChosenName = HttpUtility.HtmlEncode(Label1.Text); //need to get the service name from service by suing service id as the linking factor. mix of the workflow and service tables

                    String sqlQuery2 = "Select s.NoteTitle, s.NoteBody FROM Note s, Workflow e, Service x, Customer c WHERE e.ServiceID = x.ServiceID AND e.WorkFlowId = s.WorkflowID AND c.CustomerID = x.CustomerID AND c.CustomerName = @name";
                    SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand2 = new SqlCommand();
                    sqlCommand2.Parameters.AddWithValue("name", ChosenName);
                    sqlCommand2.Connection = sqlConnect2;
                    sqlCommand2.CommandType = CommandType.Text;
                    sqlCommand2.CommandText = sqlQuery2;
                    sqlConnect2.Open();
                    SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();
                    while (queryResults2.Read())
                    {
                        Info_Box.Items.Add(queryResults2["NoteTitle"].ToString() + " | " + queryResults2["NoteBody"].ToString());
                    }

                    queryResults2.Close();
                    sqlConnect2.Close();
                }
            }

        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }

        protected void Info_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogCustomerInfo.aspx"); //links back to Log Customer Info
        }

    }
}