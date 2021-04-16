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
    public partial class LogEquipmentRent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DDLEquipID.Items.Count == 0)
            {

                String sqlQuery = "Select EquipmentName FROM Equipment";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    DDLEquipID.Items.Add(queryResults["EquipmentName"].ToString());

                }
                queryResults.Close();
                sqlConnect.Close();
            }
            if (DDLServiceID.Items.Count == 0)
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
                    DDLServiceID.Items.Add(queryResults["ServiceName"].ToString());

                }
                queryResults.Close();
                sqlConnect.Close();
            }
        }
        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("EquipmentManagement.aspx");//links back to main page
        }
        protected void PopulateButton_Click(object sender, EventArgs e)
        {
           
            RentDate.Text = string.Format("1-1-21");
            RentedCondition.Text = string.Format("Great");
            ReturnDate.Text = string.Format("1-20-21");
            ReturnCondition.Text = string.Format("Good");
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
           
            RentDate.Text = string.Format("");
            RentedCondition.Text = string.Format("");
            ReturnDate.Text = string.Format("");
            ReturnCondition.Text = string.Format("");

        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            
            String equipName = HttpUtility.HtmlEncode(DDLEquipID.Text);

            String sqlQuery2 = "Select EquipmentID FROM Equipment WHERE @EquipmentName = EquipmentName";
            SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);



            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Parameters.AddWithValue("EquipmentName", equipName);

            sqlCommand2.Connection = sqlConnect2;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuery2;


            sqlConnect2.Open();

            SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();

            //prints values taken from the database
            while (queryResults2.Read())
            {
                equipName = (queryResults2["EquipmentID"].ToString());
            }
            queryResults2.Close();//closes connection
            sqlConnect2.Close();


            
            String serviceName = HttpUtility.HtmlEncode(DDLServiceID.Text);

            String sqlQuery3 = "Select ServiceID FROM Service WHERE @ServiceName = ServiceName";
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
                serviceName = (queryResults3["ServiceID"].ToString());
            }
            queryResults3.Close();//closes connection
            sqlConnect3.Close();




            if (String.IsNullOrEmpty(RentDate.Text) || String.IsNullOrEmpty(RentedCondition.Text) || String.IsNullOrEmpty(ReturnDate.Text) || String.IsNullOrEmpty(ReturnCondition.Text))
            {
                //do nothing
                MissingInput.Text = string.Format("You are missing an input");//notifies user that there is missing info
            }
            else
            {
                MissingInput.Text = string.Format("");
                String sqlQuery = "Insert into EquipmentRent (EquipmentID, ServiceID, RentDate, RentCondition, ReturnDate, ReturnCondition) Values (@EquipmentName, @ServiceName, @RentDate, @RentedCondition, @ReturnDate, @ReturnCondition)";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.Parameters.AddWithValue("RentDate", HttpUtility.HtmlEncode(RentDate.Text));
                sqlCommand.Parameters.AddWithValue("RentedCondition", HttpUtility.HtmlEncode(RentedCondition.Text));
                sqlCommand.Parameters.AddWithValue("ReturnDate", HttpUtility.HtmlEncode(ReturnDate.Text));
                sqlCommand.Parameters.AddWithValue("ReturnCondition", HttpUtility.HtmlEncode(ReturnCondition.Text));
                sqlCommand.Parameters.AddWithValue("ServiceName", serviceName);
                sqlCommand.Parameters.AddWithValue("EquipmentName", equipName);

                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;

                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();


                TestLabel.Text = string.Format("Successfully inserted into database.");
                queryResults.Close();//closes connection
                sqlConnect.Close();
            }
        }
    }
}