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
    public partial class LogNewItem : System.Web.UI.Page
    {
        string serviceID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            TestLabel.Text = string.Format("");
            if (ServiceDDL.Items.Count == 0)
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
                    ServiceDDL.Items.Add(queryResults["ServiceName"].ToString());

                }
                queryResults.Close();
                sqlConnect.Close();
            }
        }
        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx");//links back to main page
        }
        protected void PopulateButton_Click(object sender, EventArgs e)
        {
            
            ItemDescription.Text = string.Format("an item");
            ItemCost.Text = string.Format("4.99");



        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            
            ItemDescription.Text = string.Format("");
            ItemCost.Text = string.Format("");


        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ItemDescription.Text)  || String.IsNullOrEmpty(ItemCost.Text))
            {
                //do nothing
                MissingInput.Text = string.Format("You are missing an input");//notifies user that there is missing info
            }
            else
            {
                String sqlQuery1 = "Select ServiceID FROM Service WHERE ServiceName = @servName";
                SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand1 = new SqlCommand();
                sqlCommand1.Parameters.AddWithValue("servName", HttpUtility.HtmlEncode(ServiceDDL.Text));
                sqlCommand1.Connection = sqlConnect1;
                sqlCommand1.CommandType = CommandType.Text;
                sqlCommand1.CommandText = sqlQuery1;
                sqlConnect1.Open();
                SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();
                while (queryResults1.Read())
                {
                    serviceID = (queryResults1["ServiceID"].ToString());

                }

                queryResults1.Close();
                sqlConnect1.Close();




                MissingInput.Text = string.Format("");
                DateTime thisDay = DateTime.Today;

                String sqlQuery = "Select * from Item";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;

                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                string ItemName = HttpUtility.HtmlEncode(ItemDescription.Text);
                String userInput = ItemName;
                String dbNames = "";
                Boolean duplicate = false;

                while (queryResults.Read())
                {
                    String itemServID = (queryResults["ServiceID"].ToString());
                    dbNames = (queryResults["ItemDescription"].ToString());
                    if (dbNames == userInput && itemServID == serviceID)
                    {
                        duplicate = true;

                    }
                }

                queryResults.Close();//closes connection
                sqlConnect.Close();


                if (duplicate == false)
                {
                    String sqlQuery2 = "Insert into Item (ServiceID, ItemDescription, ItemCost, InventoryDate) Values ( @serviceID, @ItemDescription, @ItemCost, @thisDay)";
                    SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand2 = new SqlCommand();
                    sqlCommand2.Parameters.AddWithValue("ItemDescription", HttpUtility.HtmlEncode(ItemDescription.Text));
                    sqlCommand2.Parameters.AddWithValue("ItemCost", HttpUtility.HtmlEncode(ItemCost.Text));
                    sqlCommand2.Parameters.AddWithValue("thisDay", thisDay);
                    sqlCommand2.Parameters.AddWithValue("serviceID", HttpUtility.HtmlEncode(serviceID));



                    sqlCommand2.Connection = sqlConnect2;
                    sqlCommand2.CommandType = CommandType.Text;
                    sqlCommand2.CommandText = sqlQuery2;

                    sqlConnect2.Open();
                    SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();



                    queryResults2.Close();//closes connection
                    sqlConnect2.Close();
                    TestLabel.Text = string.Format("Successfully inserted into database.");
                }
                else
                {
                    TestLabel.Text = string.Format("An Item with this name already exists.");
                }


            }
        }
    }
}