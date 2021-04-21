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
    public partial class landingequip : System.Web.UI.Page
    {
        String sendCustName = "";
        DateTime now = DateTime.UtcNow;
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


            if (equipmentDDL.Items.Count == 0)
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
                    equipmentDDL.Items.Add(queryResults["EquipmentName"].ToString());

                }

                queryResults.Close();
                sqlConnect.Close();
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

            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(equipName.Value) || String.IsNullOrEmpty(equipCost.Value))
            {
                //do nothing
                //MissingInput.Text = string.Format("You are missing an input");//notifies user that there is missing info
            }
            else
            {

                //MissingInput.Text = string.Format("");


                String sqlQuery = "Select * from Equipment";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;

                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                string EName = equipCost.Value;
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
                    sqlCommand1.Parameters.AddWithValue("EquipmentName", HttpUtility.HtmlEncode(equipName.Value));
                    sqlCommand1.Parameters.AddWithValue("EquipmentCost", HttpUtility.HtmlEncode(equipCost.Value));



                    sqlCommand1.Connection = sqlConnect1;
                    sqlCommand1.CommandType = CommandType.Text;
                    sqlCommand1.CommandText = sqlQuery1;

                    sqlConnect1.Open();
                    SqlDataReader queryResults1 = sqlCommand1.ExecuteReader();



                    queryResults1.Close();//closes connection
                    sqlConnect1.Close();


                    String sqlQuery14 = "Select EquipmentID from Equipment";
                    SqlConnection sqlConnect14 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                    SqlCommand sqlCommand14 = new SqlCommand();

                    sqlCommand14.Connection = sqlConnect14;
                    sqlCommand14.CommandType = CommandType.Text;
                    sqlCommand14.CommandText = sqlQuery14;
                    sqlConnect14.Open();
                    SqlDataReader queryResults14 = sqlCommand14.ExecuteReader();

                    int i = 0;
                    while (queryResults14.Read())
                    {
                        i++;


                    }

                    int hold = i;

                    String sqlQuery10 = "Insert into EquipmentRent (EquipmentID, ServiceID, Status, RentDate, ReturnDate, RentCondition, ReturnCondition) Values (@EquipmentName, @EquipmentCost, 'Just bought', '1-1-2000', '1-1-2000', 'NEW', 'NEW')";
                    SqlConnection sqlConnect10 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand10 = new SqlCommand();
                    sqlCommand10.Parameters.AddWithValue("EquipmentName", hold);
                    sqlCommand10.Parameters.AddWithValue("EquipmentCost", 1);



                    sqlCommand10.Connection = sqlConnect10;
                    sqlCommand10.CommandType = CommandType.Text;
                    sqlCommand10.CommandText = sqlQuery10;

                    sqlConnect10.Open();
                    SqlDataReader queryResults10 = sqlCommand10.ExecuteReader();



                    queryResults1.Close();//closes connection
                    sqlConnect1.Close();





                    //TestLabel.Text = string.Format("Successfully inserted into database.");





                }
                else
                {
                    //TestLabel.Text = string.Format("A Equipment with this name already exists.");
                }






            }

        }

        protected void showAll_Click(object sender, EventArgs e)
        {
            table1.Rows.Clear();


            TableRow rowc = new TableRow();

            TableCell cellZ = new TableCell();
            TableCell cellX = new TableCell();



            cellZ.Text = "Equipment Name";
            cellX.Text = "Equipment Cost";


            rowc.Cells.Add(cellZ);
            rowc.Cells.Add(cellX);
            String hex = "#e9ecef";

            rowc.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);

            table1.Rows.Add(rowc);

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

                TableRow row = new TableRow();


                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();

                cell1.Text = queryResults["EquipmentName"].ToString();
                cell2.Text = queryResults["EquipmentCost"].ToString();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);

                table1.Rows.Add(row);
            }



        }

        protected void showSelected_Click(object sender, EventArgs e)
        {
            table1.Rows.Clear();


            TableRow rowc = new TableRow();

            TableCell cellZ = new TableCell();
            TableCell cellX = new TableCell();
            


            cellZ.Text = "Equipment Name";
            cellX.Text = "Equipment Cost";


            rowc.Cells.Add(cellZ);
            rowc.Cells.Add(cellX);
            String hex = "#e9ecef";

            rowc.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);

            table1.Rows.Add(rowc);

            String ChosenName = HttpUtility.HtmlEncode(equipmentDDL.SelectedValue);

            String sqlQuery = "Select EquipmentName, EquipmentCost FROM Equipment WHERE EquipmentName = @DDL";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(equipmentDDL.Text));
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();

            //prints values taken from the database
            while (queryResults.Read())
            {
                TableRow row = new TableRow();


                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();

                cell1.Text = queryResults["EquipmentName"].ToString();
                cell2.Text = queryResults["EquipmentCost"].ToString();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);

                table1.Rows.Add(row);

            }


        }

        protected void SubmitRental_Click(object sender, EventArgs e)
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




            if (String.IsNullOrEmpty(RentDate.Value) || String.IsNullOrEmpty(RentedCondition.Value) || String.IsNullOrEmpty(ReturnDate.Value) || String.IsNullOrEmpty(ReturnCondition.Value))
            {
                //do nothing
                //MissingInput.Text = string.Format("You are missing an input");//notifies user that there is missing info
            }
            else
            {
                //MissingInput.Text = string.Format("");
                String sqlQuery = "Insert into EquipmentRent (EquipmentID, ServiceID, RentDate, RentCondition, ReturnDate, ReturnCondition) Values (@EquipmentName, @ServiceName, @RentDate, @RentedCondition, @ReturnDate, @ReturnCondition)";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.Parameters.AddWithValue("RentDate", HttpUtility.HtmlEncode(RentDate.Value));
                sqlCommand.Parameters.AddWithValue("RentedCondition", HttpUtility.HtmlEncode(RentedCondition.Value));
                sqlCommand.Parameters.AddWithValue("ReturnDate", HttpUtility.HtmlEncode(ReturnDate.Value));
                sqlCommand.Parameters.AddWithValue("ReturnCondition", HttpUtility.HtmlEncode(ReturnCondition.Value));
                sqlCommand.Parameters.AddWithValue("ServiceName", serviceName);
                sqlCommand.Parameters.AddWithValue("EquipmentName", equipName);

                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;

                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();


                //TestLabel.Text = string.Format("Successfully inserted into database.");
                queryResults.Close();//closes connection
                sqlConnect.Close();
            }
        }

    

    protected void ShowInfo_Click(object sender, EventArgs e)
        {


            table2.Rows.Clear();


            TableRow rowc = new TableRow();

            TableCell cellx = new TableCell();
            TableCell celly = new TableCell();
            TableCell cellz = new TableCell();
            TableCell cellv = new TableCell();
            TableCell cella = new TableCell();
            TableCell cellb = new TableCell();

            cellx.Text = "Equipment ID";
            celly.Text = "Service ID";
            cellz.Text = "Rent Date";
            cellv.Text = "Rented Condition";
            cella.Text = "Return Date";
            cellb.Text = "Return Condition";
            


            rowc.Cells.Add(cellz);
            rowc.Cells.Add(cellx);
            rowc.Cells.Add(cellv);
            rowc.Cells.Add(cellv);
            rowc.Cells.Add(cella);
            rowc.Cells.Add(cellb);



            String hex = "#e9ecef";

            rowc.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);

            table2.Rows.Add(rowc);



            String ChosenName = HttpUtility.HtmlEncode(DDL.SelectedValue);
            String sqlQuery = "Select s.EquipmentName, e.RentDate, e.RentCondition, e.ReturnDate, e.ReturnCondition FROM EquipmentRent e, Equipment s WHERE e.EquipmentID = s.EquipmentID AND s.EquipmentName = @DDL ORDER BY e.ReturnDate";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("DDL", HttpUtility.HtmlEncode(DDL.Text));
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();

            while (queryResults.Read())
            {

                TableRow row = new TableRow();

                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                TableCell cell3 = new TableCell();
                TableCell cell4 = new TableCell();
                TableCell cell5 = new TableCell();



                cell1.Text = queryResults["EquipmentName"].ToString();
                cell2.Text = queryResults["RentDate"].ToString();
                cell3.Text = queryResults["RentCondition"].ToString();
                cell4.Text = queryResults["ReturnDate"].ToString();
                cell5.Text = queryResults["ReturnCondition"].ToString();






                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);

                table2.Rows.Add(row);
            }
        }

        protected void ShowAllInfo_Click(object sender, EventArgs e)
        {

            table2.Rows.Clear();

            TableRow rowc = new TableRow();

            TableCell cellx = new TableCell();
            TableCell celly = new TableCell();
            TableCell cellz = new TableCell();
            TableCell cellv = new TableCell();
            TableCell cella = new TableCell();
            TableCell cellb = new TableCell();

            cellx.Text = "Equipment ID";
            celly.Text = "Service ID";
            cellz.Text = "Rent Date";
            cellv.Text = "Rented Condition";
            cella.Text = "Return Date";
            cellb.Text = "Return Condition";



            rowc.Cells.Add(cellz);
            rowc.Cells.Add(cellx);
            rowc.Cells.Add(cellv);
            rowc.Cells.Add(cellv);
            rowc.Cells.Add(cella);
            rowc.Cells.Add(cellb);



            String hex = "#e9ecef";
            table2.Rows.Add(rowc);

            rowc.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);

            String sqlQuery = "Select s.EquipmentName, e.RentDate, e.RentCondition, e.ReturnDate, e.ReturnCondition FROM EquipmentRent e, Equipment s WHERE e.EquipmentID = s.EquipmentID ORDER BY e.ReturnDate";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;

            sqlConnect.Open();

            SqlDataReader queryResults = sqlCommand.ExecuteReader();


            while (queryResults.Read())
            {

                TableRow row = new TableRow();

                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                TableCell cell3 = new TableCell();
                TableCell cell4 = new TableCell();
                TableCell cell5 = new TableCell();



                cell1.Text = queryResults["EquipmentName"].ToString();
                cell2.Text = queryResults["RentDate"].ToString();
                cell3.Text = queryResults["RentCondition"].ToString();
                cell4.Text = queryResults["ReturnDate"].ToString();
                cell5.Text = queryResults["ReturnCondition"].ToString();







                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);

                table2.Rows.Add(row);



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
    }
}
