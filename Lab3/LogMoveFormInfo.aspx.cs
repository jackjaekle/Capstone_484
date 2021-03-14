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
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            String sqlQuery4 = "SELECT ServiceID from Service where ServiceName = @name";
            SqlCommand sqlCommand4 = new SqlCommand();
            sqlCommand4.Connection = sqlConnect;
            sqlCommand4.Parameters.AddWithValue("name", HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue));
            sqlCommand4.CommandType = CommandType.Text;
            sqlCommand4.CommandText = sqlQuery4;
            sqlConnect.Open();
            int serviceID = (int)sqlCommand4.ExecuteScalar();
            sqlConnect.Close();

            String sqlQuery5 = "SELECT MoveFormID from MoveForm, Service where MoveForm.ServiceID = Service.ServiceID AND Service.ServiceName = @name";
            SqlCommand sqlCommand5 = new SqlCommand();
            sqlCommand5.Connection = sqlConnect;
            sqlCommand5.Parameters.AddWithValue("name", HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue));
            sqlCommand5.CommandType = CommandType.Text;
            sqlCommand5.CommandText = sqlQuery5;
            sqlConnect.Open();
            int workFormID = (int)sqlCommand5.ExecuteScalar();
            sqlConnect.Close();

            String sqlQuery = "Select e.Stories, e.TruckDist, e.DrivewayAccess, e.LoadCondition FROM MoveForm e, Service s WHERE s.ServiceID = e.ServiceID AND s.ServiceName = @name" ;
            String sqlQuery2 = "SELECT r.Name, r.Floor, r.TypeofBoxes, r.NumOfBoxes, r.Blankets from Rooms r, Service s, MoveForm e WHERE r.MoveFormID = " + workFormID + " AND s.ServiceID = e.ServiceID AND s.ServiceName = @name";
            String sqlQuery3 = "SELECT DISTINCT r.Floor from Rooms r, MoveForm e, Service s WHERE r.MoveFormID = e.MoveFormID AND e.ServiceID = " + serviceID;// s.ServiceID = e.ServiceID AND s.ServiceName = @name";


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
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx");
        }

        protected void btnShowFloor_Click(object sender, EventArgs e)
        {
            String sqlQuery = "Select r.Name, r.Floor, r.TypeofBoxes, r.NumOfBoxes, r.Blankets FROM Rooms r, Service e, MoveForm s WHERE s.ServiceID = e.ServiceID AND e.ServiceName = @name AND Floor = " + HttpUtility.HtmlEncode(ddlFloor.SelectedValue);
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
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            String sqlQuery2 = "SELECT MoveFormID from MoveForm, Service where MoveForm.ServiceID = Service.ServiceID AND Service.ServiceName = @name";
            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect;
            sqlCommand2.Parameters.AddWithValue("name", HttpUtility.HtmlEncode(ddlMoveForm.SelectedValue));
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuery2;
            sqlConnect.Open();
            int workFormID = (int)sqlCommand2.ExecuteScalar();
            sqlConnect.Close();

            String sqlQuery = "Select r.Name, r.Floor, r.TypeofBoxes, r.NumOfBoxes, r.Blankets FROM Rooms r, Service e, MoveForm s WHERE r.MoveFormID = " + workFormID + " AND s.ServiceID = e.ServiceID AND e.ServiceName = @name";

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
        }
    }
}