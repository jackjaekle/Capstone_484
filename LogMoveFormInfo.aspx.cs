﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class LogMoveFormInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (ddlMoveForm.Items.Count == 0)
            {
                //dtaSrcMoveFormID.SelectCommand = "Select s.ServiceName, e.MoveFormID FROM Service s, MoveForm e WHERE s.ServiceID = e.ServiceID";
                //ddlMoveForm.DataTextField = "ServiceName";
                //ddlMoveForm.DataValueField = "MoveFormID";
                String sqlQuery = "Select s.ServiceName FROM Service s, MoveForm e WHERE s.ServiceID = e.ServiceID";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlConnect.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();
                while (queryResults.Read())
                {
                    ddlMoveForm.Items.Add(queryResults["ServiceName"].ToString());


                }

                sqlConnect.Close();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String sqlQuery = "Select e.Stories, e.TruckDist, e.DrivewayAccess, e.LoadCondition FROM MoveForm e, Service s WHERE " +
                "s.ServiceID = e.ServiceID " +
                "AND s.ServiceName = @name" ;
            String sqlQuery2 = "SELECT r.Name, r.Floor, r.TypeofBoxes, r.NumOfBoxes, r.Blankets from Rooms r, Service s, MoveForm e WHERE " +
                "s.ServiceID = e.ServiceID " +
                "AND s.ServiceName = @name " +
                "AND r.MoveFormID = e.MoveFormID";
            String sqlQuery3 = "SELECT DISTINCT r.Floor from Rooms r, MoveForm e, Service s WHERE " +
                "s.ServiceID = e.ServiceID " +
                "AND s.ServiceName = @name " + 
                "AND r.MoveFormID = e.MoveFormID";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            
            sqlCommand.Connection = sqlConnect;
            sqlCommand.Parameters.AddWithValue("name", HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue));
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect;
            sqlCommand2.Parameters.AddWithValue("name", HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue));
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuery2;


            SqlCommand sqlCommand3 = new SqlCommand();
            sqlCommand3.Connection = sqlConnect;
            sqlCommand3.Parameters.AddWithValue("name", HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue));
            sqlCommand3.CommandType = CommandType.Text;
            sqlCommand3.CommandText = sqlQuery3;

            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            grdMoveForm.DataSource = queryResults;
            grdMoveForm.DataBind();
            sqlConnect.Close();

            sqlConnect.Open();
            SqlDataReader query2Results = sqlCommand2.ExecuteReader();
            grdRoomInfo.DataSource = query2Results;
            grdRoomInfo.DataBind();
            sqlConnect.Close();

            sqlConnect.Open();
            SqlDataReader query3Results = sqlCommand3.ExecuteReader();
            ddlFloor.DataSource = query3Results;
            ddlFloor.DataBind();
            sqlConnect.Close();

            lblMoveForm.Text = "MoveForm information for Service " + HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue);
            lblRoomInfo.Text = "Rooms Information for Service " + HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue);

            btnShowFloor.Enabled = true;
            btnShowAll.Enabled = true;
            btnSubmitItems.Enabled = false;
            btnAddNewItem.Enabled = false;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx");
        }

        protected void btnShowFloor_Click(object sender, EventArgs e)
        {
            String sqlQuery = "Select r.Name, r.Floor, r.TypeofBoxes, r.NumOfBoxes, r.Blankets FROM Rooms r, Service e, MoveForm s WHERE s.ServiceID = e.ServiceID AND r.MoveFormID = s.MoveFormID AND e.ServiceName = @name AND Floor = " + HttpUtility.HtmlEncode(ddlFloor.SelectedValue);
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.Parameters.AddWithValue("name", HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue));
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            grdRoomInfo.DataSource = queryResults;
            grdRoomInfo.DataBind();
            sqlConnect.Close();
            lblRoomInfo.Text = "Rooms Information for Service " + HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue) + ", Floor " + HttpUtility.HtmlEncode(ddlFloor.SelectedValue);

            fillRoomItemsDDL();

            btnSubmitItems.Enabled = true;
            btnAddNewItem.Enabled = true;
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            showAllRooms();
        }

        protected void btnSubmitItems_Click(object sender, EventArgs e)
        {
            refreshRoomItems();
            //lblItemInfo.Text = "Item Information for Room " + HttpUtility.HtmlEncode(ddlRooms.SelectedValue) + ", Floor " + HttpUtility.HtmlEncode(ddlFloor.SelectedValue);
        }

        protected void btnAddNewItem_Click(object sender, EventArgs e)
        {
            int roomID = int.Parse(ddlRooms.SelectedValue);
            String Name = HttpUtility.HtmlEncode(txtItemName.Text);
            String Description = HttpUtility.HtmlEncode(txtItemDescrip.Text);
            String Action;
            if (rdoBtnMove.Checked)
            {
                Action = "Move";
            }
            else
            {
                Action = "Dispose";
            }
            String sqlQuery = "Insert into RoomItems (RoomID, Name, Description, Action) " +
                "values (@roomID, @name ,@description, @action);";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Parameters.AddWithValue("roomID", roomID);
            sqlCommand.Parameters.AddWithValue("name", Name);
            sqlCommand.Parameters.AddWithValue("description", Description);
            sqlCommand.Parameters.AddWithValue("action", Action);

            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            queryResults.Close();//closes connection
            sqlConnect.Close();

            txtItemDescrip.Text = string.Empty;
            txtItemName.Text = string.Empty;
            rdoBtnDispose.Checked = false;
            rdoBtnMove.Checked = true;

            refreshRoomItems();
        }

        protected void refreshRoomItems()
        {
            String sqlQuery = "Select distinct r.Name, r.Description, r.Action FROM RoomItems r, Rooms ro WHERE r.RoomID = " + HttpUtility.HtmlEncode(ddlRooms.SelectedValue);
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            grdViewItems.DataSource = queryResults;
            grdViewItems.DataBind();
            sqlConnect.Close();
        }

        protected void fillRoomItemsDDLAllFloors()
        {
            //Not a parameterized query bc it doesn't liek to rerun with the same name when you change the floor you're looking at
            //Shouldn't matter bc the only input is from ddl's anyway, encoded too.
            dtaSrcRoomItemsID.SelectCommand = "Select r.Name, r.RoomID FROM Rooms r, Service e, MoveForm s WHERE s.ServiceID = e.ServiceID" +
                " AND e.ServiceName = '" + HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue) +
                "' AND r.MoveFormID = s.MoveFormID";
            ddlRooms.DataTextField = "Name";
            ddlRooms.DataValueField = "RoomID";
        }
        protected void fillRoomItemsDDL()
        {
            //Not a parameterized query bc it doesn't liek to rerun with the same name when you change the floor you're looking at 
            //Shouldn't matter bc the only input is from ddl's anyway, encoded too.
            dtaSrcRoomItemsID.SelectCommand = "Select r.Name, r.RoomID FROM Rooms r, Service e, MoveForm s WHERE s.ServiceID = e.ServiceID" +
                " AND e.ServiceName = '" + HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue) +
                "' AND r.MoveFormID = s.MoveFormID" +
                " AND r.Floor = '" + HttpUtility.HtmlEncode(ddlFloor.SelectedValue) + "'";
            ddlRooms.DataTextField = "Name";
            ddlRooms.DataValueField = "RoomID";
        }

        protected void showAllRooms()
        {
            String sqlQuery = "Select r.Name, r.Floor, r.TypeofBoxes, r.NumOfBoxes, r.Blankets FROM Rooms r, Service e, MoveForm s WHERE " +
                            "s.ServiceID = e.ServiceID " +
                            "AND e.ServiceName = @name " +
                            "AND r.MoveFormID = s.MoveFormID";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("name", HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue));
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            grdRoomInfo.DataSource = queryResults;
            grdRoomInfo.DataBind();
            sqlConnect.Close();

            lblRoomInfo.Text = "Rooms Information for Service " + HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue);

            fillRoomItemsDDLAllFloors();

            btnSubmitItems.Enabled = true;
            btnAddNewItem.Enabled = true;
        }

        protected void btnAddNewRoom_Click(object sender, EventArgs e)
        {

            String sqlQuery3 = "Select m.MoveFormID FROM MoveForm m, Service s WHERE m.ServiceID = s.ServiceID AND s.ServiceName = @name";
            SqlConnection sqlConnect3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            String serviceName = HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue);

            SqlCommand sqlCommand3 = new SqlCommand();
            sqlCommand3.Parameters.AddWithValue("name", serviceName);
            sqlCommand3.Connection = sqlConnect3;
            sqlCommand3.CommandType = CommandType.Text;
            sqlCommand3.CommandText = sqlQuery3;
            int moveFormID;
            sqlConnect3.Open();

            moveFormID = Convert.ToInt32(sqlCommand3.ExecuteScalar());

            sqlConnect3.Close();

            String roomName = HttpUtility.HtmlEncode(txtBoxRoomName.Text);
            int roomFloor = int.Parse(HttpUtility.HtmlEncode(txtBoxRoomFloor.Text));
            String typeOfBoxes = HttpUtility.HtmlEncode(txtBoxBoxType.Text);
            int numOfBoxes = int.Parse(HttpUtility.HtmlEncode(txtBoxBoxNumber.Text));
            int blankets = 0;

            if (chkBoxBlankets.Checked)
                blankets = 1;

            String sqlQuery = "Insert into Rooms(MoveFormID, Name, Floor, TypeofBoxes, NumOfBoxes, Blankets) "+
                                "Values(@moveFormID, @roomName, @roomFloor, @boxType, @numOfBoxes, @blankets);";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Parameters.AddWithValue("moveFormID", moveFormID);
            sqlCommand.Parameters.AddWithValue("roomName", roomName);
            sqlCommand.Parameters.AddWithValue("roomFloor", roomFloor);
            sqlCommand.Parameters.AddWithValue("boxType", typeOfBoxes);
            sqlCommand.Parameters.AddWithValue("numOfboxes", numOfBoxes);
            sqlCommand.Parameters.AddWithValue("blankets", blankets);

            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            queryResults.Close();//closes connection
            sqlConnect.Close();

            txtBoxRoomName.Text = String.Empty;
            txtBoxRoomFloor.Text = String.Empty;
            txtBoxBoxType.Text = String.Empty;
            txtBoxBoxNumber.Text = String.Empty;
            chkBoxBlankets.Checked = false;

            showAllRooms();
        }
    }
}