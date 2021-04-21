using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
//Noah George, William Kilpatrick, Henry Requeno-Villeda

namespace Lab2
{
    public partial class LogCustomerInfo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnShowAll_Click(object sender, EventArgs e) //the method for showing all the customers info
        {
            CustomerInformation.Items.Clear();

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
                CustomerInformation.Items.Add(cName.ToString());
            }
            queryResults1.Close();
            sqlConnect1.Close();
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedInMainPage.aspx"); //links back to main page
        }

        protected void inDepth_Click(object sender, EventArgs e)
        {

            Response.Redirect("LogInDepth.aspx?SendCustomerName=" + HttpUtility.HtmlEncode(customerNames.Text));
        }

        protected void custName_TextChanged(object sender, EventArgs e) //the method for showing all the customers info
        {
            customerNames.Items.Clear();



            String sqlQuery1 = "Select CustomerName FROM Customer WHERE CustomerName Like @userInput";
            SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            String holder = HttpUtility.HtmlEncode(custName.Text);
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Parameters.AddWithValue("userInput", $"%{holder}%");
            sqlCommand1.Connection = sqlConnect1;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQuery1;
            sqlConnect1.Open();
            String test = "hold";
            SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();
            while (queryResults1.Read())
            {

                customerNames.Items.Add(queryResults1["CustomerName"].ToString());

            }

            queryResults1.Close();
            sqlConnect1.Close();


        }
      
    }
}