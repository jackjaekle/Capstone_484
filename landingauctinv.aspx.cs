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
    public partial class landingauctinv : System.Web.UI.Page
    {

        String sendCustName = "";
        DateTime now = DateTime.UtcNow;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Service.Items.Count == 0)
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
                    Service.Items.Add(queryResults["ServiceName"].ToString());

                }
                queryResults.Close();
                sqlConnect.Close();
            }

            if (AuctionName1.Items.Count == 0)// only loads the emp info once
            {
                AuctionName1.Items.Add("Customers attending auction"); //makes a header for the display box
                String sqlQuery = "Select AuctionName FROM AuctionEvent GROUP BY AuctionName";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.AddWithValue("0", '0');
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    AuctionName1.Items.Add(queryResults["AuctionName"].ToString()); //puts it in a ddl 
                }

                queryResults.Close();
                sqlConnect.Close();
            }


            if (CustomerInfo.Items.Count == 0)// only loads the emp info once
            {


                String sqlQuery2 = "Select CustomerName, DateOfServiceRequest FROM Customer WHERE ServicedYN = @n AND descriptionOfNeeds IS NOT Null AND DateOfServiceRequest IS NOT Null AND MoveCreateYN ='0' ORDER BY DateOfServiceRequest";
                SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand2 = new SqlCommand();
                sqlCommand2.Parameters.AddWithValue("n", '1');
                sqlCommand2.Connection = sqlConnect2;
                sqlCommand2.CommandType = CommandType.Text;
                sqlCommand2.CommandText = sqlQuery2;

                sqlConnect2.Open();
                SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();
                while (queryResults2.Read())
                {
                    DateTime past = DateTime.Parse(queryResults2["DateOfServiceRequest"].ToString());
                    TimeSpan duration = now - past;

                    char[] delimiterChars = { '.' };
                    string[] words = duration.ToString().Split(delimiterChars);
                    String days = words[0].Trim();
                    String hours = words[1].Trim();
                    if (words.Length <= 2)
                    {
                        days = "0";
                        hours = words[0].Trim();
                    }
                    CustomerInfo.Items.Add("Customer Name  |  Waiting time");

                    CustomerInfo.Items.Add(queryResults2["CustomerName"].ToString() + " |  days: " + days);
                }

                queryResults2.Close();
                sqlConnect2.Close();
            }




            if (custInvList.Items.Count == 0)
            {
                custInvList.Items.Add("Customer Name  |  Waiting time");

                //This block of code fills a dropdown list with the info it needs
                String sqlQuery = "Select c.CustomerName, c.DateOfServiceRequest FROM Customer c, Service s WHERE s.AuctionedYN = @n AND DateOfServiceRequest IS NOT Null AND c.CustomerID = s.CustomerID ORDER BY DateOfServiceRequest";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                String n = "0";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.AddWithValue("n", n);
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    DateTime past = DateTime.Parse(queryResults["DateOfServiceRequest"].ToString());
                    TimeSpan duration = now - past;

                    char[] delimiterChars = { '.' };
                    string[] words = duration.ToString().Split(delimiterChars);
                    String days = words[0].Trim();
                    String hours = words[1].Trim();
                    if (words.Length <= 2)
                    {
                        days = "0";
                        hours = words[0].Trim();
                    }

                    custInvList.Items.Add(queryResults["CustomerName"].ToString() + " |  days: " + days);

                }

                queryResults.Close();
                sqlConnect.Close();

                //sql to pull up a list of customer names with the "n" for if they have been serviced
                //make the n be autofilled for new customers

            }












            if (custList.Items.Count == 0 && MovingRadio.Checked == true)
            {
                //This block of code fills a dropdown list with the info it needs
                custList.Items.Add("Customer Name  |  Waiting time");
                String sqlQuery = "Select CustomerName, DateOfServiceRequest FROM Customer WHERE ServicedYN = @n AND descriptionOfNeeds IS NOT Null AND typeOfService = @Moving ORDER BY DateOfServiceRequest";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                String n = "0";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.AddWithValue("n", n);
                sqlCommand.Parameters.AddWithValue("Moving", "Moving");
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    DateTime past = DateTime.Parse(queryResults["DateOfServiceRequest"].ToString());
                    TimeSpan duration = now - past;

                    char[] delimiterChars = { '.' };
                    string[] words = duration.ToString().Split(delimiterChars);
                    String days = words[0].Trim();
                    String hours = words[1].Trim();
                    if (words.Length <= 2)
                    {
                        days = "0";
                        hours = words[0].Trim();
                    }

                    custList.Items.Add(queryResults["CustomerName"].ToString() + " |  days: " + days);

                }

                queryResults.Close();
                sqlConnect.Close();

                //sql to pull up a list of customer names with the "n" for if they have been serviced
                //make the n be autofilled for new customers

            }


        }
        protected void MovingRadio_CheckedChanged(object sender, EventArgs e)
        {
            AuctionRadio.Checked = false;
            custList.Items.Clear();
            custList.Items.Add("Customer Name  |  Waiting time");
            String sqlQuery = "Select CustomerName, DateOfServiceRequest FROM Customer WHERE ServicedYN = @n AND descriptionOfNeeds IS NOT Null AND typeOfService = @Moving ORDER BY DateOfServiceRequest";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            String n = "0";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("n", n);
            sqlCommand.Parameters.AddWithValue("Moving", "Moving");
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            while (queryResults.Read())
            {
                DateTime past = DateTime.Parse(queryResults["DateOfServiceRequest"].ToString());
                TimeSpan duration = now - past;

                char[] delimiterChars = { '.' };
                string[] words = duration.ToString().Split(delimiterChars);
                String days = words[0].Trim();
                String hours = words[1].Trim();
                if (words.Length <= 2)
                {
                    days = "0";
                    hours = words[0].Trim();
                }

                custList.Items.Add(queryResults["CustomerName"].ToString() + " |  days: " + days);

            }


            queryResults.Close();
            sqlConnect.Close();


        }

        protected void AuctionRadio_CheckedChanged(object sender, EventArgs e)
        {
            MovingRadio.Checked = false;


            custList.Items.Clear();
            custList.Items.Add("Customer Name  |  Waiting time");
            String sqlQuery = "Select CustomerName,  DateOfServiceRequest FROM Customer WHERE ServicedYN = @n AND descriptionOfNeeds IS NOT Null AND typeOfService = @Auction ORDER BY DateOfServiceRequest";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            String n = "0";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("n", n);
            sqlCommand.Parameters.AddWithValue("Auction", "Auction");
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            while (queryResults.Read())
            {
                DateTime past = DateTime.Parse(queryResults["DateOfServiceRequest"].ToString());
                TimeSpan duration = now - past;

                char[] delimiterChars = { '.' };
                string[] words = duration.ToString().Split(delimiterChars);
                String days = words[0].Trim();
                String hours = words[1].Trim();
                if (words.Length <= 2)
                {
                    days = "0";
                    hours = words[0].Trim();
                }

                custList.Items.Add(queryResults["CustomerName"].ToString() + " |  days: " + days);

            }

            queryResults.Close();
            sqlConnect.Close();

        }

        protected void custList_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] delimiterChars = { '|' };
            string[] words = HttpUtility.HtmlEncode(custList.SelectedValue).Split(delimiterChars);
            String test2 = words[0].Trim();
            String CustName = words[0].Trim();
            UserInput.Text = HttpUtility.HtmlEncode(CustName);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            char[] delimiterChars = { '|' };
            string[] words = HttpUtility.HtmlEncode(CustomerInfo.SelectedValue).Split(delimiterChars);
            String test2 = words[0].Trim();
            String CustName = words[0].Trim();

            String ChosenName = HttpUtility.HtmlEncode(CustName);

            if (ChosenName != "")
            {
                Response.Redirect("EstimateWorkSheet.aspx?sendName=" + ChosenName);
            }
            else
            {
                //Label3.Text = "You need to select a customer before going to the next screen";
            }

        }

        protected void Auction_Click(object sender, EventArgs e)
        {
            String SendCustName = HttpUtility.HtmlEncode(UserInput.Text);



            if (SendCustName != "")
            {
                Response.Redirect("LogAvailableAuctions.aspx?SendCustName=" + SendCustName);
            }
            else
            {
                //Label1.Text = "You need to select a customer before going to the next screen";
            }
        }

        protected void custInvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] delimiterChars = { '|' };
            string[] words = HttpUtility.HtmlEncode(custInvList.SelectedValue).Split(delimiterChars);
            String test2 = words[0].Trim();
            String CustName = words[0].Trim();
            Textbox1.Text = HttpUtility.HtmlEncode(CustName);
        }
        protected void servCust_Click(object sender, EventArgs e)
        {
            String servType = "";
            String sqlQuery1 = "Select typeOfService FROM Customer WHERE CustomerName = @cName";
            SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            SqlCommand sqlCommand1 = new SqlCommand();

            sqlCommand1.Parameters.AddWithValue("cName", HttpUtility.HtmlEncode(UserInput.Text));
            sqlCommand1.Connection = sqlConnect1;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQuery1;
            sqlConnect1.Open();
            SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();
            while (queryResults1.Read())
            {
                servType = queryResults1["typeOfService"].ToString();

            }

            queryResults1.Close();
            sqlConnect1.Close();




            String sqlQuery = "Select CustomerName FROM Customer WHERE ServicedYN = @n AND descriptionOfNeeds IS NOT Null";//how to count the number of customers waiting on service

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            String n = "0";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("n", n);
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            int i = 0;
            String userInput = HttpUtility.HtmlEncode(UserInput.Text);
            Boolean match = false;
            while (queryResults.Read())
            {
                String customerName = "";
                customerName = (queryResults["CustomerName"].ToString());
                if (customerName == userInput)
                {
                    match = true;

                }
            }
            queryResults.Close();//closes connection
            sqlConnect.Close();

            if (match == true && servType == "Moving")
            {
                Response.Redirect("LogCustServCreation.aspx?SendCustName=" + userInput);
            }
            else if (match == true && servType == "Auction")
            {
                Response.Redirect("LoggedCustServAuction.aspx?SendCustName=" + userInput);
            }
            else
            {
                //matchCheck.Text = "This customer either does not exist, or does not request a new service. Please select one from the list.";
            }



            //need to verify that the customer name is in the list. can use same code that pulled the customer name from before
            //throw an error if not the same
            //if its a real customer that need service link to the service ticket creation, import the data needed
        }
        protected void CustomerInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] delimiterChars = { '|' };
            string[] words = HttpUtility.HtmlEncode(CustomerInfo.SelectedValue).Split(delimiterChars);
            String test2 = words[0].Trim();
            String CustName = words[0].Trim();
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            String sqlQuery2 = "Select * from AuctionEvent WHERE AuctionID = AuctionID;";
            SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect2;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuery2;

            sqlConnect2.Open();
            SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();
            string date = HttpUtility.HtmlEncode(auctionDate.Text);
            String auctName = HttpUtility.HtmlEncode(auctionName.Text);
            String dbAucName = "";
            String dbAucDate = "";
            Boolean duplicate = false;

            while (queryResults2.Read())
            {
                dbAucName = (queryResults2["AuctionName"].ToString());
                dbAucDate = (queryResults2["AuctionDate"].ToString());
                if (dbAucName == auctName && dbAucDate == date)
                {
                    duplicate = true;

                }
            }
            queryResults2.Close();//closes connection
            sqlConnect2.Close();





            if (duplicate == false)
            {

                String sqlQuery = "Select AuctionID from AuctionEvent"; //going to make it select the highest auction id num
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                int currentAuctionID = 0;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    int x = int.Parse(queryResults["AuctionID"].ToString()); //puts it in a ddl 
                    if (x > currentAuctionID)
                    {
                        currentAuctionID = x;
                    }
                }


                queryResults.Close();//closes connection
                sqlConnect.Close();


                int newAucID = currentAuctionID++;
                String sqlQuery1 = "Insert into AuctionEvent values (@aucID, @servID,@itemID, @auctionName, @auctionDate, @auctionLocation)";
                SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand1 = new SqlCommand();
                sqlCommand1.Parameters.AddWithValue("aucID", currentAuctionID);
                sqlCommand1.Parameters.AddWithValue("servID", "0");
                sqlCommand1.Parameters.AddWithValue("itemID", "0");
                sqlCommand1.Parameters.AddWithValue("auctionName", HttpUtility.HtmlEncode(auctionName.Text));
                sqlCommand1.Parameters.AddWithValue("auctionDate", HttpUtility.HtmlEncode(auctionDate.Text));
                sqlCommand1.Parameters.AddWithValue("auctionLocation", HttpUtility.HtmlEncode(auctionLocation.Text));




                sqlCommand1.Connection = sqlConnect1;
                sqlCommand1.CommandType = CommandType.Text;
                sqlCommand1.CommandText = sqlQuery1;

                sqlConnect1.Open();
                SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();



                queryResults1.Close();//closes connection
                sqlConnect1.Close();
                // MissingInput.Text = string.Format("Successfully created Auction Event.");



            }
            else
            {
                // MissingInput.Text = string.Format("There is already an auction with the same name and date");
            }
        }
        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx");
        }
        protected void btnLoadEmployeeData_Click(object sender, EventArgs e)
        {
            string holder = AuctionName1.SelectedValue;
            DropDownList1.Items.Clear();


            String ChosenName = HttpUtility.HtmlEncode(holder);

            String sqlQuery = "Select c.CustomerName FROM AuctionEvent a, Service s, Customer c WHERE s.ServiceID = a.ServiceID and c.CustomerID = s.CustomerID and a.AuctionName = @DDL";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(holder));
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();

            //prints values taken from the database
            while (queryResults.Read()) //outpurs the stuff from the db into the display box
            {
                string CustName = queryResults["CustomerName"].ToString();
                if (DropDownList1.Items.Contains(new ListItem(CustName))) //this makes sure it doesnt display the customer name multiple times
                {
                    //do nothing
                }
                else
                {
                    DropDownList1.Items.Add(CustName);
                }
            }

        }
        protected void BtnShowAll_Click(object sender, EventArgs e) //is used to show every customers info
        {
            string holder = AuctionName1.SelectedValue;
            DropDownList1.Items.Clear();
            AuctionName1.Items.Add("Customer Name | Auction Name "); //makes a header for the display box
            String sqlQuery = "Select s.AuctionName, c.CustomerName FROM AuctionEvent s, Service e,  Customer c WHERE e.ServiceID = s.ServiceID and c.CustomerID = e.CustomerID ORDER BY s.AuctionName";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(holder));
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();

            //prints values taken from the database
            while (queryResults.Read()) //outpurs the stuff from the db into the display box
            {

                string CustName = queryResults["CustomerName"].ToString() + " | " + queryResults["AuctionName"].ToString();
                if (AuctionName1.Items.Contains(new ListItem(CustName))) //this makes sure it doesnt display the customer name multiple times
                {
                    //do nothing
                }
                else
                {
                    AuctionName1.Items.Add(CustName);
                }
            }




            if (String.IsNullOrEmpty(needs.Text) || String.IsNullOrEmpty(cost.Text))
            {
                //do nothing
                // MissingInput.Text = string.Format("You are missing an input");//notifies user that there is missing info
            }
            else
            {
                String sqlQuery1 = "Select ServiceID FROM Service WHERE ServiceName = @servName";
                SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                string serviceID = "";
                SqlCommand sqlCommand1 = new SqlCommand();
                sqlCommand1.Parameters.AddWithValue("servName", HttpUtility.HtmlEncode(holder));
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




                //MissingInput.Text = string.Format("");
                DateTime thisDay = DateTime.Today;

                String sqlQuery3 = "Select * from Item";
                SqlConnection sqlConnect3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand3 = new SqlCommand();
                sqlCommand3.Connection = sqlConnect3;
                sqlCommand3.CommandType = CommandType.Text;
                sqlCommand3.CommandText = sqlQuery3;

                sqlConnect3.Open();
                SqlDataReader queryResults3 = sqlCommand3.ExecuteReader();
                string ItemName = HttpUtility.HtmlEncode(needs.Text);
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
                    sqlCommand2.Parameters.AddWithValue("ItemDescription", HttpUtility.HtmlEncode(needs.Text));
                    sqlCommand2.Parameters.AddWithValue("ItemCost", HttpUtility.HtmlEncode(cost.Text));
                    sqlCommand2.Parameters.AddWithValue("thisDay", thisDay);
                    sqlCommand2.Parameters.AddWithValue("serviceID", HttpUtility.HtmlEncode(serviceID));



                    sqlCommand2.Connection = sqlConnect2;
                    sqlCommand2.CommandType = CommandType.Text;
                    sqlCommand2.CommandText = sqlQuery2;

                    sqlConnect2.Open();
                    SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();

                    queryResults2.Close();//closes connection
                    sqlConnect2.Close();

                    String Item = "";
                    String sqlQuery4 = "Select ItemID FROM Item WHERE ItemDescription = @ItemDescription";
                    SqlConnection sqlConnect4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand4 = new SqlCommand();
                    sqlCommand4.Parameters.AddWithValue("ItemDescription", HttpUtility.HtmlEncode(needs.Text));
                    sqlCommand4.Connection = sqlConnect4;
                    sqlCommand4.CommandType = CommandType.Text;
                    sqlCommand4.CommandText = sqlQuery4;
                    sqlConnect4.Open();
                    SqlDataReader queryResults4 = sqlCommand4.ExecuteReader();
                    while (queryResults4.Read())
                    {
                        Item = (queryResults4["ItemID"].ToString());
                    }

                    queryResults4.Close();
                    sqlConnect4.Close();


                    String sqlQuery5 = "Insert into AuctionPickUp (ItemID, BringInDate) Values (@ItemID, @BringInDate)";
                    SqlConnection sqlConnect5 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand5 = new SqlCommand();
                    sqlCommand5.Parameters.AddWithValue("ItemID", Item);
                    sqlCommand5.Parameters.AddWithValue("BringInDate", thisDay);

                    sqlCommand5.Connection = sqlConnect5;
                    sqlCommand5.CommandType = CommandType.Text;
                    sqlCommand5.CommandText = sqlQuery5;

                    sqlConnect5.Open();
                    SqlDataReader queryResults5 = sqlCommand5.ExecuteReader();

                    queryResults5.Close();//closes connection
                    sqlConnect5.Close();


                    //TestLabel.Text = string.Format("Successfully inserted into database.");
                }
                else
                {
                    //TestLabel.Text = string.Format("An Item with this name already exists.");
                }


            }
        }

        protected void Submit2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(needs.Text) || String.IsNullOrEmpty(cost.Text))
            {
                //do nothing
               // MissingInput.Text = string.Format("You are missing an input");//notifies user that there is missing info
            }
            else
            {
                String holder = Service.SelectedValue;
                String sqlQuery1 = "Select ServiceID FROM Service WHERE ServiceName = @servName";
                SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand1 = new SqlCommand();
                sqlCommand1.Parameters.AddWithValue("servName", HttpUtility.HtmlEncode(holder));
                sqlCommand1.Connection = sqlConnect1;
                sqlCommand1.CommandType = CommandType.Text;
                sqlCommand1.CommandText = sqlQuery1;
                string serviceID = "";
                sqlConnect1.Open();
                SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();
                while (queryResults1.Read())
                {
                    serviceID = (queryResults1["ServiceID"].ToString());

                }

                queryResults1.Close();
                sqlConnect1.Close();




              //  MissingInput.Text = string.Format("");
                DateTime thisDay = DateTime.Today;

                String sqlQuery = "Select * from Item";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;

                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                string ItemName = HttpUtility.HtmlEncode(needs.Text);
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
                    sqlCommand2.Parameters.AddWithValue("ItemDescription", HttpUtility.HtmlEncode(needs.Text));
                    sqlCommand2.Parameters.AddWithValue("ItemCost", HttpUtility.HtmlEncode(cost.Text));
                    sqlCommand2.Parameters.AddWithValue("thisDay", thisDay);
                    sqlCommand2.Parameters.AddWithValue("serviceID", HttpUtility.HtmlEncode(serviceID));



                    sqlCommand2.Connection = sqlConnect2;
                    sqlCommand2.CommandType = CommandType.Text;
                    sqlCommand2.CommandText = sqlQuery2;

                    sqlConnect2.Open();
                    SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();

                    queryResults2.Close();//closes connection
                    sqlConnect2.Close();

                    String Item = "";
                    String sqlQuery4 = "Select ItemID FROM Item WHERE ItemDescription = @ItemDescription";
                    SqlConnection sqlConnect4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand4 = new SqlCommand();
                    sqlCommand4.Parameters.AddWithValue("ItemDescription", HttpUtility.HtmlEncode(needs.Text));
                    sqlCommand4.Connection = sqlConnect4;
                    sqlCommand4.CommandType = CommandType.Text;
                    sqlCommand4.CommandText = sqlQuery4;
                    sqlConnect4.Open();
                    SqlDataReader queryResults4 = sqlCommand4.ExecuteReader();
                    while (queryResults4.Read())
                    {
                        Item = (queryResults4["ItemID"].ToString());
                    }

                    queryResults4.Close();
                    sqlConnect4.Close();


                    String sqlQuery3 = "Insert into AuctionPickUp (ItemID, BringInDate) Values (@ItemID, @BringInDate)";
                    SqlConnection sqlConnect3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand3 = new SqlCommand();
                    sqlCommand3.Parameters.AddWithValue("ItemID", Item);
                    sqlCommand3.Parameters.AddWithValue("BringInDate", thisDay);

                    sqlCommand3.Connection = sqlConnect3;
                    sqlCommand3.CommandType = CommandType.Text;
                    sqlCommand3.CommandText = sqlQuery3;

                    sqlConnect3.Open();
                    SqlDataReader queryResults3 = sqlCommand3.ExecuteReader();

                    queryResults3.Close();//closes connection
                    sqlConnect3.Close();


                    //TestLabel.Text = string.Format("Successfully inserted into database.");
                }
                else
                {
                   // TestLabel.Text = string.Format("An Item with this name already exists.");
                }


            }
        }
    }
}
