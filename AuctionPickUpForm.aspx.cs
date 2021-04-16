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
    public partial class AuctionPickUpForm : System.Web.UI.Page
    {

        public String ItemID = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            //make it load all info for the item when it switches from LogInvInfo to here
            String test = Request.QueryString["SendItemDescription"];

            if (test == "")
            {
                Label7.Text = "Go back and select a Item";
            }
            else
            {
                if (RentDate.Text == "") {
                    char[] delimiterChars = {'|'};
                    string[] words = test.Split(delimiterChars);
                    String test2 = words[1].Trim();

                    String serviceName = words[0].Trim();
                    String ItemDescription = words[1].Trim();
                    Label7.Text = HttpUtility.HtmlEncode(ItemDescription);

                    //find ServcieID from serviceName and then ItemID with that and ItemDescription
                    String ServiceID = "";
                    String sqlQuery2 = "Select ServiceID FROM Service WHERE @serviceName = serviceName";
                    SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand2 = new SqlCommand();
                    sqlCommand2.Parameters.AddWithValue("serviceName", serviceName);

                    sqlCommand2.Connection = sqlConnect2;
                    sqlCommand2.CommandType = CommandType.Text;
                    sqlCommand2.CommandText = sqlQuery2;

                    sqlConnect2.Open();

                    SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();

                    //prints values taken from the database
                    while (queryResults2.Read())
                    {
                        ServiceID = (queryResults2["ServiceID"].ToString());
                    }
                    queryResults2.Close();//closes connection
                    sqlConnect2.Close();

                    //ItemID with that and ItemDescription
                    String Item = "";
                    String sqlQuery3 = "Select ItemID FROM Item WHERE @serviceID = serviceID AND @ItemDescription = ItemDescription";
                    SqlConnection sqlConnect3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand3 = new SqlCommand();
                    sqlCommand3.Parameters.AddWithValue("serviceID", ServiceID);
                    sqlCommand3.Parameters.AddWithValue("ItemDescription", ItemDescription);
                    sqlCommand3.Connection = sqlConnect3;
                    sqlCommand3.CommandType = CommandType.Text;
                    sqlCommand3.CommandText = sqlQuery3;

                    sqlConnect3.Open();

                    SqlDataReader queryResults3 = sqlCommand3.ExecuteReader();

                    //prints values taken from the database
                    while (queryResults3.Read())
                    {
                        Item = (queryResults3["ItemID"].ToString());
                    }
                    queryResults3.Close();//closes connection
                    sqlConnect3.Close();

                    ItemID = Item;



                    //insert dates of the item 
                    String sqlQuery4 = "Select BringInDate, PickUpDate, LookAtDate, AppraisalDate, SaleDate, StorageLocation FROM AuctionPickUp WHERE ItemID = @ItemID";
                    SqlConnection sqlConnect4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand4 = new SqlCommand();
                    sqlCommand4.Parameters.AddWithValue("ItemID", ItemID);
                    sqlCommand4.Connection = sqlConnect4;
                    sqlCommand4.CommandType = CommandType.Text;
                    sqlCommand4.CommandText = sqlQuery4;
                    sqlConnect4.Open();
                    SqlDataReader queryResults4 = sqlCommand4.ExecuteReader();
                    while (queryResults4.Read())
                    {
                        RentDate.Text = string.Format(queryResults4["BringInDate"].ToString());
                        TextBox1.Text = string.Format(queryResults4["PickUpDate"].ToString());
                        TextBox2.Text = string.Format(queryResults4["LookAtDate"].ToString());
                        TextBox3.Text = string.Format(queryResults4["AppraisalDate"].ToString());
                        TextBox4.Text = string.Format(queryResults4["SaleDate"].ToString());
                        TextBox5.Text = string.Format(queryResults4["StorageLocation"].ToString());
                    }

                    queryResults4.Close();
                    sqlConnect4.Close();

                    TestLabel.Text = "";
                }
            }

        }

        protected void MainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }
        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogInvInfo.aspx"); //links back to LogInvInfo
        }
        protected void PopulateButton_Click(object sender, EventArgs e)
        {

            RentDate.Text = string.Format("1/1/21");
            TextBox1.Text = string.Format("1/10/21");
            TextBox2.Text = string.Format("1/1/21");
            TextBox3.Text = string.Format("1/10/21");
            TextBox4.Text = string.Format("1/20/21");
            TextBox5.Text = string.Format("Noahs place");

        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {

            RentDate.Text = string.Format("");
            TextBox1.Text = string.Format("");
            TextBox2.Text = string.Format("");
            TextBox3.Text = string.Format("");
            TextBox4.Text = string.Format("");
            TextBox5.Text = string.Format("");

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(RentDate.Text))
            {
                //do nothing
                MissingInput.Text = string.Format("You are missing an input");//notifies user that there is missing info
            }
            else
            {

                String test = Request.QueryString["SendItemDescription"];

                if (test == "")
                {
                    Label7.Text = "Go back and select a Item";
                }
                else
                {
                    char[] delimiterChars = { '|' };
                    string[] words = test.Split(delimiterChars);
                    String test2 = words[1].Trim();

                    String serviceName = words[0].Trim();
                    String ItemDescription = words[1].Trim();
                    Label7.Text = HttpUtility.HtmlEncode(ItemDescription);

                    //find ServcieID from serviceName and then ItemID with that and ItemDescription
                    String ServiceID = "";
                    String sqlQuery2 = "Select ServiceID FROM Service WHERE @serviceName = serviceName";
                    SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand2 = new SqlCommand();
                    sqlCommand2.Parameters.AddWithValue("serviceName", serviceName);

                    sqlCommand2.Connection = sqlConnect2;
                    sqlCommand2.CommandType = CommandType.Text;
                    sqlCommand2.CommandText = sqlQuery2;

                    sqlConnect2.Open();

                    SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();

                    //prints values taken from the database
                    while (queryResults2.Read())
                    {
                        ServiceID = (queryResults2["ServiceID"].ToString());
                    }
                    queryResults2.Close();//closes connection
                    sqlConnect2.Close();

                    //ItemID with that and ItemDescription
                    String Item = "";
                    String sqlQuery3 = "Select ItemID FROM Item WHERE @serviceID = serviceID AND @ItemDescription = ItemDescription";
                    SqlConnection sqlConnect3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand3 = new SqlCommand();
                    sqlCommand3.Parameters.AddWithValue("serviceID", ServiceID);
                    sqlCommand3.Parameters.AddWithValue("ItemDescription", ItemDescription);
                    sqlCommand3.Connection = sqlConnect3;
                    sqlCommand3.CommandType = CommandType.Text;
                    sqlCommand3.CommandText = sqlQuery3;

                    sqlConnect3.Open();

                    SqlDataReader queryResults3 = sqlCommand3.ExecuteReader();

                    //prints values taken from the database
                    while (queryResults3.Read())
                    {
                        Item = (queryResults3["ItemID"].ToString());
                    }
                    queryResults3.Close();//closes connection
                    sqlConnect3.Close();




                    //update entry
                    String sqlQuery4 = "Update AuctionPickUp Set BringInDate = @BringInDate , PickUpDate = @PickUpDate, LookAtDate = @LookAtDate, AppraisalDate = @AppraisalDate, SaleDate = @SaleDate, StorageLocation = @StorageLocation WHERE ItemID = @ItemID";
                    SqlConnection sqlConnect4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand4 = new SqlCommand();
                    sqlCommand4.Parameters.AddWithValue("ItemID", Item);
                    sqlCommand4.Parameters.AddWithValue("BringInDate", RentDate.Text);
                    sqlCommand4.Parameters.AddWithValue("PickUpDate", TextBox1.Text);
                    sqlCommand4.Parameters.AddWithValue("LookAtDate", TextBox2.Text);
                    sqlCommand4.Parameters.AddWithValue("AppraisalDate", TextBox3.Text);
                    sqlCommand4.Parameters.AddWithValue("SaleDate", TextBox4.Text);
                    sqlCommand4.Parameters.AddWithValue("StorageLocation", TextBox5.Text);



                    sqlCommand4.Connection = sqlConnect4;
                    sqlCommand4.CommandType = CommandType.Text;
                    sqlCommand4.CommandText = sqlQuery4;
                    sqlConnect4.Open();
                    SqlDataReader queryResults4 = sqlCommand4.ExecuteReader();
                    queryResults4.Close();
                    sqlConnect4.Close();
                    TestLabel.Text = "Record Updated";
                }
            }
        }



    }
}