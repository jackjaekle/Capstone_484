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
    public partial class LogInvInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DDL.Items.Count == 0)
            {

                String sqlQuery = "Select ServiceName FROM Service";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    DDL.Items.Add(queryResults["ServiceName"].ToString());

                }

                queryResults.Close();
                sqlConnect.Close();
            }
        }

        protected void AuctionPickUpForm_Click(object sender, EventArgs e)
        {

            Response.Redirect("AuctionPickUpForm.aspx?SendItemDescription=" + HttpUtility.HtmlEncode(InventoryInfo.Text));
        }

        protected void btnLoadInventoryData_Click(object sender, EventArgs e)
        {
            InventoryInfo.Items.Clear();
            InventoryInfo.Items.Add("Service Name, ItemDescription, ItemCost, InventoryDate");

            String ChosenName = HttpUtility.HtmlEncode(DDL.SelectedValue);// need the servicename from service, and the rest from the inventory

            String sqlQuery = "Select s.ServiceName, e.ItemDescription, e.ItemCost, e.InventoryDate FROM Service s, Item e WHERE e.ServiceID = s.ServiceID AND s.ServiceName = @ddl";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("ddl", HttpUtility.HtmlEncode(DDL.Text));
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();

            //prints values taken from the database
            while (queryResults.Read())
            {

                InventoryInfo.Items.Add(queryResults["ServiceName"].ToString() + " | "  + queryResults["ItemDescription"].ToString() + " | " + queryResults["ItemCost"].ToString() + " | " + queryResults["InventoryDate"].ToString());
            }





        }
        protected void BtnShowAll_Click(object sender, EventArgs e)
        {
            InventoryInfo.Items.Clear();
            InventoryInfo.Items.Add("Service Name, ItemDescription, ItemCost, InventoryDate");

            String sqlQuery = "Select s.ServiceName, e.ItemDescription, e.ItemCost, e.InventoryDate FROM Service s, Item e WHERE e.ServiceID = s.ServiceID";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();


            while (queryResults.Read())
            {

                InventoryInfo.Items.Add(queryResults["ServiceName"].ToString() + " | " + queryResults["ItemDescription"].ToString() + " | " + queryResults["ItemCost"].ToString() + " | " + queryResults["InventoryDate"].ToString());
            }
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }
    }
}