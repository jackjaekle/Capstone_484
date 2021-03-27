using System;
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
                "AND s.ServiceName = @name";
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

            fillRoomItemsDDL();

            btnSubmitItems.Enabled = true;
            btnAddNewItem.Enabled = true;

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

        protected void fillRoomItemsDDL()
        {
            //Not a parameterized query bc it doesn't liek to rerun with the same name when you change the floor you're looking at
            //Shouldn't matter bc the only input is from ddl's anyway, encoded too.
            dtaSrcRoomItemsID.SelectCommand = "Select r.Name, r.RoomID FROM Rooms r, Service e, MoveForm s WHERE s.ServiceID = e.ServiceID" +
                " AND e.ServiceName = '" + HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue) +
                "' AND r.MoveFormID = s.MoveFormID";
            ddlRooms.DataTextField = "Name";
            ddlRooms.DataValueField = "RoomID";
        }
    }
}