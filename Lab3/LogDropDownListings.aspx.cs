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
    public partial class LogDropDownListings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DDL.Items.Count == 0)
            { //This block of code fills a dropdown list with the info it needs
                String sqlQuery = "Select CustomerName FROM Customer";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    DDL.Items.Add(queryResults["CustomerName"].ToString());

                }

                queryResults.Close();
                sqlConnect.Close();
            }
        }


        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }
        protected void btnLoadCustomerData_Click(object sender, EventArgs e)
        {
            DisplayBox.Items.Clear();

            String ChosenName = HttpUtility.HtmlEncode(DDL.SelectedValue); //takes the value from the DDL

            String sqlQuery = "Select c.CustomerName, c.CustomerEmail, s.ServiceDate, s.ServiceCost, s.ServiceName FROM Customer c, Service s WHERE c.CustomerID = s.CustomerID AND c.CustomerName = " + "'" + ChosenName + "'";
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

                DisplayBox.Items.Add(queryResults["CustomerName"].ToString() + " " + queryResults["CustomerEmail"].ToString() + " " + queryResults["ServiceDate"].ToString() + " " + queryResults["ServiceCost"].ToString() + queryResults["ServiceName"].ToString());
            }





        }
        protected void BtnShowAll_Click(object sender, EventArgs e)
        {
            DisplayBox.Items.Clear(); //clears the display box so it doesnt stack unrelated stuff

            String sqlQuery = "Select c.CustomerName, c.CustomerEmail, s.ServiceDate, s.ServiceCost, s.ServiceName FROM Customer c, Service s WHERE c.CustomerID = s.CustomerID";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();


            while (queryResults.Read()) //adds stuff to the displaybox
            {

                DisplayBox.Items.Add(queryResults["CustomerName"].ToString() + " " + queryResults["CustomerEmail"].ToString() + " " + queryResults["ServiceDate"].ToString() + " " + queryResults["ServiceCost"].ToString() + queryResults["ServiceName"].ToString());
            }
        }
    }
}