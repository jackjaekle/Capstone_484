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

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String sqlQuery = "Select * FROM MoveForm WHERE ServiceID = " + ddlMoveForm.SelectedValue;
            String sqlQuery2 = "SELECT * from Rooms WHERE MoveFormID = " + ddlMoveForm.SelectedValue;
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuery2;

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

            lblMoveForm.Text = "MoveForm information for MoveForm " + ddlMoveForm.SelectedValue;
            lblRoomInfo.Text = "Rooms Information for MoveForm " + ddlMoveForm.SelectedValue;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx");
        }
    }
}