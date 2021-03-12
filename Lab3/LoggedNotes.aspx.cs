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
    public partial class LoggedNotes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            noteStatus.Text = "";

            if (ServiceDDL.Items.Count == 0)
            {

                EditNote.Checked = true;
                noteTitle.Visible = false;
                noteTitleLbl.Visible = false;


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
                    ServiceDDL.Items.Add(queryResults["ServiceName"].ToString());  //pull and display all service names

                }
                queryResults.Close();
                sqlConnect.Close();



                String serviceName = HttpUtility.HtmlEncode(ServiceDDL.Text);
                String serviceID = "";
                String sqlQuery3 = "Select ServiceID FROM Service WHERE @ServiceName = ServiceName";  //pull the service ID based off the service name
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
                    serviceID = (queryResults3["ServiceID"].ToString());
                }
                queryResults3.Close();//closes connection
                sqlConnect3.Close();


                NoteDDL.Items.Clear();
                //"Select WorkflowID from FROM Workflow WHERE ServiceID =  @ServiceID";
                String sqlQuery4 = "Select s.NoteTitle FROM Note s, Workflow e WHERE e.ServiceID = @ServiceID AND e.WorkflowID = s.WorkflowID";
                SqlConnection sqlConnect4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommand4 = new SqlCommand();

                sqlCommand4.Parameters.AddWithValue("ServiceID", serviceID);
                sqlCommand4.Connection = sqlConnect4;
                sqlCommand4.CommandType = CommandType.Text;
                sqlCommand4.CommandText = sqlQuery4;

                sqlConnect4.Open();

                SqlDataReader queryResults4 = sqlCommand4.ExecuteReader();

                //prints values taken from the database

                while (queryResults4.Read())
                {
                    NoteDDL.Items.Add(queryResults4["NoteTitle"].ToString());  //pull and display all service names
                }
                queryResults4.Close();//closes connection
                sqlConnect4.Close();

                String noteID = "";
                String notetitle = HttpUtility.HtmlEncode(NoteDDL.Text);
                String sqlQuery6 = "Select NoteID FROM Note WHERE @noteTitle = NoteTitle";  //pull the service ID based off the service name
                SqlConnection sqlConnect6 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommand6 = new SqlCommand();
                sqlCommand6.Parameters.AddWithValue("noteTitle", notetitle);
                sqlCommand6.Connection = sqlConnect6;
                sqlCommand6.CommandType = CommandType.Text;
                sqlCommand6.CommandText = sqlQuery6;


                sqlConnect6.Open();

                SqlDataReader queryResults6 = sqlCommand6.ExecuteReader();

                //prints values taken from the database
                while (queryResults6.Read())
                {
                    noteID = (queryResults6["NoteID"].ToString());
                }
                queryResults6.Close();//closes connection
                sqlConnect6.Close();


                String sqlQuery5 = "Select NoteBody FROM Note WHERE @noteID = NoteID";  //pull the service ID based off the service name
                SqlConnection sqlConnect5 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommand5 = new SqlCommand();
                sqlCommand5.Parameters.AddWithValue("noteID", noteID);
                sqlCommand5.Connection = sqlConnect5;
                sqlCommand5.CommandType = CommandType.Text;
                sqlCommand5.CommandText = sqlQuery5;


                sqlConnect5.Open();

                SqlDataReader queryResults5 = sqlCommand5.ExecuteReader();

                //prints values taken from the database
                queryResults5.Read();
                NoteInfo.Text = string.Format(queryResults5["NoteBody"].ToString());

                queryResults5.Close();//closes connection
                sqlConnect5.Close();
            }
        }
        protected void NewNote_CheckedChanged(object sender, EventArgs e)       //how to tell if its visible or not
        {
            EditNote.Checked = false;
            saveChanges.Text = "Save New Note";
            noteTitle.Visible = true;
            NoteDDL.Visible = false;
            noteTitleLbl.Visible = true;
            noteDDLTitle.Visible = false;
            NoteInfo.Text = "";
            noteTitle.Text = "";
        }

        protected void EditNote_CheckedChanged(object sender, EventArgs e)       //how to tell if its visible or not
        {
            NewNote.Checked = false;
            saveChanges.Text = "Save Changes";
            noteTitle.Visible = false;
            NoteDDL.Visible = true;
            noteTitleLbl.Visible = false;
            noteDDLTitle.Visible = true;
            NoteInfo.Text = "";
            noteTitle.Text = "";

        }


        protected void ServiceDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            NoteInfo.Text = "";
            String serviceName = HttpUtility.HtmlEncode(ServiceDDL.Text);
            String serviceID = "";
            String sqlQuery3 = "Select ServiceID FROM Service WHERE @ServiceName = ServiceName";  //pull the service ID based off the service name
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
                serviceID = (queryResults3["ServiceID"].ToString());
            }
            queryResults3.Close();//closes connection
            sqlConnect3.Close();


            NoteDDL.Items.Clear();
            String blank = "";
            NoteDDL.Items.Add(blank);
            //"Select WorkflowID from FROM Workflow WHERE ServiceID =  @ServiceID";
            String sqlQuery4 = "Select s.NoteTitle FROM Note s, Workflow e WHERE e.ServiceID = @ServiceID AND e.WorkflowID = s.WorkflowID";
            SqlConnection sqlConnect4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlCommand sqlCommand4 = new SqlCommand();

            sqlCommand4.Parameters.AddWithValue("ServiceID", serviceID);
            sqlCommand4.Connection = sqlConnect4;
            sqlCommand4.CommandType = CommandType.Text;
            sqlCommand4.CommandText = sqlQuery4;

            sqlConnect4.Open();

            SqlDataReader queryResults4 = sqlCommand4.ExecuteReader();

            //prints values taken from the database
            while (queryResults4.Read())
            {
                NoteDDL.Items.Add(queryResults4["NoteTitle"].ToString());  //pull and display all service names
            }
            queryResults4.Close();//closes connection
            sqlConnect4.Close();



        }
        protected void NoteDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NoteDDL.Text != "")
            {

                String noteID = "";
                String notetitle = HttpUtility.HtmlEncode(NoteDDL.Text);
                String sqlQuery6 = "Select NoteID FROM Note WHERE @noteTitle = NoteTitle";  //pull the service ID based off the service name
                SqlConnection sqlConnect6 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommand6 = new SqlCommand();
                sqlCommand6.Parameters.AddWithValue("noteTitle", notetitle);
                sqlCommand6.Connection = sqlConnect6;
                sqlCommand6.CommandType = CommandType.Text;
                sqlCommand6.CommandText = sqlQuery6;


                sqlConnect6.Open();

                SqlDataReader queryResults6 = sqlCommand6.ExecuteReader();

                //prints values taken from the database
                while (queryResults6.Read())
                {
                    noteID = (queryResults6["NoteID"].ToString());
                }
                queryResults6.Close();//closes connection
                sqlConnect6.Close();


                String sqlQuery5 = "Select NoteBody FROM Note WHERE @noteID = NoteID";  //pull the service ID based off the service name
                SqlConnection sqlConnect5 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommand5 = new SqlCommand();
                sqlCommand5.Parameters.AddWithValue("noteID", noteID);
                sqlCommand5.Connection = sqlConnect5;
                sqlCommand5.CommandType = CommandType.Text;
                sqlCommand5.CommandText = sqlQuery5;


                sqlConnect5.Open();

                SqlDataReader queryResults5 = sqlCommand5.ExecuteReader();

                //prints values taken from the database
                queryResults5.Read();
                NoteInfo.Text = string.Format(queryResults5["NoteBody"].ToString());

                queryResults5.Close();//closes connection
                sqlConnect5.Close();




            }
        }


        protected void saveChanges_Click(object sender, EventArgs e)
        {


            //"Select s.NoteTitle FROM Note s, Workflow e WHERE e.ServiceID = @ServiceID AND e.WorkflowID = s.WorkflowID";
            String workFlowID = "";
            String sqlQuery6 = "Select s.WorkflowID FROM WorkFlow s, Service e WHERE e.ServiceID = s.ServiceID AND e.ServiceName = @jobname";           //how to see if the note name is a dupe
            SqlConnection sqlConnect6 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            String jobNames = HttpUtility.HtmlEncode(ServiceDDL.Text);
            SqlCommand sqlCommand6 = new SqlCommand();
            sqlCommand6.Parameters.AddWithValue("jobname", jobNames);
            sqlCommand6.Connection = sqlConnect6;
            sqlCommand6.CommandType = CommandType.Text;
            sqlCommand6.CommandText = sqlQuery6;

            sqlConnect6.Open();
            SqlDataReader queryResults6 = sqlCommand6.ExecuteReader();


            while (queryResults6.Read())
            {
                workFlowID = "";
                workFlowID = (queryResults6["WorkFlowID"].ToString());
            }
            queryResults6.Close();//closes connection
            sqlConnect6.Close();


            String sqlQuery = "Select NoteTitle FROM Note Where WorkFlowID = @workFlowID ";           //how to see if the note name is a dupe
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("workFlowID", workFlowID);
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            String notetitle = "";
            String userInput = HttpUtility.HtmlEncode(noteTitle.Text);
            Boolean duplicate = false;

            while (queryResults.Read())
            {
                notetitle = "";
                notetitle = (queryResults["NoteTitle"].ToString());
                if (notetitle == userInput)
                {
                    duplicate = true;

                }
            }
            queryResults.Close();//closes connection
            sqlConnect.Close();

            if (duplicate == false)
            {

                if (NewNote.Checked == true && noteTitle.Text != "")
                {

                    String sqlQuery2 = "Select s.WorkflowID FROM WorkFlow s, Service e WHERE e.ServiceID = s.ServiceID AND e.ServiceName = @jobname";

                    SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                    String jobName = HttpUtility.HtmlEncode(ServiceDDL.Text);
                    SqlCommand sqlCommand2 = new SqlCommand();
                    sqlCommand2.Parameters.AddWithValue("jobname", jobName);
                    sqlCommand2.Connection = sqlConnect2;
                    sqlCommand2.CommandType = CommandType.Text;
                    sqlCommand2.CommandText = sqlQuery2;



                    sqlConnect2.Open();
                    String workflowID = "";
                    SqlDataReader queryResults2 = sqlCommand2.ExecuteReader();

                    while (queryResults2.Read())
                    {
                        workflowID = "";
                        workflowID = (queryResults2["WorkFlowID"].ToString());
                    }
                    queryResults2.Close();
                    sqlConnect2.Close();





                    String sqlQuery3 = "Insert into Note (WorkflowID, NoteTitle, NoteBody) Values (@WorkFlowID, @NewNoteTitle, @NoteInfo)";

                    SqlConnection sqlConnect3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                    SqlCommand sqlCommand3 = new SqlCommand();
                    sqlCommand3.Parameters.AddWithValue("WorkFlowID", workflowID);
                    sqlCommand3.Parameters.AddWithValue("NewNoteTitle", HttpUtility.HtmlEncode(noteTitle.Text));
                    sqlCommand3.Parameters.AddWithValue("NoteInfo", HttpUtility.HtmlEncode(NoteInfo.Text));

                    sqlCommand3.Connection = sqlConnect3;
                    sqlCommand3.CommandType = CommandType.Text;
                    sqlCommand3.CommandText = sqlQuery3;
                    sqlConnect3.Open();

                    SqlDataReader queryResults3 = sqlCommand3.ExecuteReader();

                    queryResults3.Close();
                    sqlConnect3.Close();
                    noteStatus.Text = "New Record Created";

                }
                else if (noteTitle.Text == "" && NewNote.Checked == true)
                {
                    noteStatus.Text = "Your note Name Dropdown is blank";

                }
                else if (NewNote.Checked == false && NoteInfo.Text != "")
                {
                    String sqlQuery4 = "Update Note Set NoteBody = @NoteInfo WHERE NoteTitle = @NoteTitle";
                    SqlConnection sqlConnect4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand4 = new SqlCommand();
                    String NoteTitle = HttpUtility.HtmlEncode(NoteDDL.Text);
                    sqlCommand4.Parameters.AddWithValue("NoteInfo", HttpUtility.HtmlEncode(NoteInfo.Text));
                    sqlCommand4.Parameters.AddWithValue("NoteTitle", NoteTitle);


                    sqlCommand4.Connection = sqlConnect4;
                    sqlCommand4.CommandType = CommandType.Text;
                    sqlCommand4.CommandText = sqlQuery4;
                    sqlConnect4.Open();
                    SqlDataReader queryResults4 = sqlCommand4.ExecuteReader();
                    queryResults4.Close();
                    sqlConnect4.Close();
                    noteStatus.Text = "Record Updated";
                }
            }


            else
            {
                noteStatus.Text = "A note with this name already exists";
            }
        }
        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoggedinMainPage.aspx"); //links back to main page
        }
    }
}