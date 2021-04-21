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
    public partial class LogEquipmentStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DDL.Items.Count == 0)
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
                    DDL.Items.Add(queryResults["EquipmentName"].ToString());

                }

                queryResults.Close();
                sqlConnect.Close();
            }
        }
        protected void btnLoadEquipmentData_Click(object sender, EventArgs e)
        {
            EquipmentInformation.Items.Clear();
            EquipmentInformation.Items.Add("Equipment Name, EquipmentCost");
            String ChosenName = HttpUtility.HtmlEncode(DDL.SelectedValue);

            String sqlQuery = "Select EquipmentName, EquipmentCost FROM Equipment WHERE EquipmentName = @DDL";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(DDL.Text));
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();

            //prints values taken from the database
            while (queryResults.Read())
            {

                EquipmentInformation.Items.Add(queryResults["EquipmentName"].ToString() + " | " + queryResults["EquipmentCost"].ToString());
            }





        }
        protected void BtnShowAll_Click(object sender, EventArgs e)
        {
            EquipmentInformation.Items.Clear();
            EquipmentInformation.Items.Add("Equipment Name, EquipmentCost");

            String sqlQuery = "Select EquipmentName, EquipmentCost FROM Equipment WHERE EquipmentID = EquipmentID";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();


            while (queryResults.Read())
            {

                EquipmentInformation.Items.Add(queryResults["EquipmentName"].ToString() + " | " + queryResults["EquipmentCost"].ToString());
            }
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("EquipmentManagement.aspx"); //links back to main page
        }
    }
}