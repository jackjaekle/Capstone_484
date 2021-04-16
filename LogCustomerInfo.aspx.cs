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
            CustomerInformation.Items.Add("Customer Name, Customer Phone, Customer Email");

            String sqlQuery = "Select CustomerName, CustomerEmail, CustomerPhone FROM Customer WHERE CustomerName= CustomerName";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();


            while (queryResults.Read()) //adds all the info to a single list box
            {

                CustomerInformation.Items.Add(queryResults["CustomerName"].ToString() + " | " + queryResults["CustomerPhone"].ToString() + " | " + queryResults["CustomerEmail"].ToString());
            }
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
        protected void custNames_SelectedIndexChanged(object sender, EventArgs e) //the method for showing all the customers info
        {
            CustomerInformation.Items.Clear();
            CustomerInformation.Items.Add("Customer Name, Customer Phone, Customer Email"); //puts a header on the output


            String sqlQuery = "Select CustomerName, CustomerEmail, CustomerPhone FROM Customer WHERE CustomerName = @ChosenName";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.Parameters.AddWithValue("ChosenName", HttpUtility.HtmlEncode(customerNames.SelectedValue));
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();

            //prints values taken from the database
            while (queryResults.Read())
            {

                CustomerInformation.Items.Add(queryResults["CustomerName"].ToString() + " | " + queryResults["CustomerPhone"].ToString() + " | " + queryResults["CustomerEmail"].ToString());
            }

        }
    }
}