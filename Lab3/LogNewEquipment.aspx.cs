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
    public partial class LogNewEquipment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("EquipmentManagement.aspx");//links back to main page
        }
        protected void PopulateButton_Click(object sender, EventArgs e)
        {

            EquipmentName.Text = string.Format("Pulley");//populates a textbox
            EquipmentCost.Text = string.Format("499.99");


        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {

            EquipmentName.Text = string.Format("");//clears a textbox
            EquipmentCost.Text = string.Format("");


        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(EquipmentName.Text) || String.IsNullOrEmpty(EquipmentCost.Text))
            {
                //do nothing
                MissingInput.Text = string.Format("You are missing an input");//notifies user that there is missing info
            }
            else
            {

                MissingInput.Text = string.Format("");


                String sqlQuery = "Select * from Equipment";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;

                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                string EName = EquipmentName.Text;
                String userInput = EName;
                String dbNames = "";
                Boolean duplicate = false;

                while (queryResults.Read())
                {
                    dbNames = (queryResults["EquipmentName"].ToString());
                    if (dbNames == userInput)
                    {
                        duplicate = true;

                    }
                }

                queryResults.Close();//closes connection
                sqlConnect.Close();


                if (duplicate == false)
                {
                    String sqlQuery1 = "Insert into Equipment (EquipmentName, EquipmentCost) Values (@EquipmentName, @EquipmentCost)";
                    SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand1 = new SqlCommand();
                    sqlCommand1.Parameters.AddWithValue("EquipmentName", HttpUtility.HtmlEncode(EquipmentName.Text));
                    sqlCommand1.Parameters.AddWithValue("EquipmentCost", HttpUtility.HtmlEncode(EquipmentCost.Text));



                    sqlCommand1.Connection = sqlConnect1;
                    sqlCommand1.CommandType = CommandType.Text;
                    sqlCommand1.CommandText = sqlQuery1;

                    sqlConnect1.Open();
                    SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();



                    queryResults1.Close();//closes connection
                    sqlConnect1.Close();
                    TestLabel.Text = string.Format("Successfully inserted into database.");
                }
                else
                {
                    TestLabel.Text = string.Format("A Equipment with this name already exists.");
                }






            }

        }
    }
}