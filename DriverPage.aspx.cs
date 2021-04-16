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
    public partial class DriverPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (MoveDDL.Items.Count == 0)
            {


                { //This block of code fills a dropdown list with the info it needs
                    string email = Session["UserName"].ToString();
                    String sqlQuery = "Select  s.ServiceName, e.EmployeeEmail, w.EndDate FROM Service s, Workflow w, Employee e WHERE e.EmployeeID = w.EmployeeID AND e.EmployeeEmail = @emploEmail AND s.ServiceID = w.ServiceID";
                    SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Parameters.AddWithValue("emploEmail", email);
                    sqlCommand.Connection = sqlConnect;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = sqlQuery;
                    sqlConnect.Open();
                    SqlDataReader queryResults = sqlCommand.ExecuteReader();

                    string empEmail = "";
                    string ServiceName = "";
                    while (queryResults.Read())
                    {
                        empEmail = queryResults["EmployeeEmail"].ToString();
                       
                        ServiceName = queryResults["ServiceName"].ToString();
                        DateTime serviceEnd = DateTime.Parse(queryResults["EndDate"].ToString());
                        if (email == empEmail)
                        {

                            if (MoveDDL.Items.Contains(new ListItem(ServiceName))) //this makes sure it doesnt display the eqp name multiple times, as it pulls each eqp multiple times from the eqp rent table
                            {
                                //do nothing
                            }
                            else
                            {
                                if (serviceEnd >= DateTime.Now)
                                {
                                    MoveDDL.Items.Add(ServiceName);
                                }

                            }

                        }


                    }
                    queryResults.Close();
                    sqlConnect.Close();
                    SpecificGV.Visible = true;

                    VehicleGV.Visible = true;

                    SqlConnection sqlConnectA = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                    sqlConnectA.Open();

                    // Retrieve the selected ServiceID from dropdown
                    String sidCheck = "SELECT ServiceID FROM SERVICE WHERE ServiceName = @ServiceName";
                    SqlCommand sCheck = new SqlCommand(sidCheck, sqlConnectA);
                    sCheck.Parameters.AddWithValue("@ServiceName", MoveDDL.SelectedValue.ToString());
                    int ySID = Convert.ToInt32(sCheck.ExecuteScalar());

                    using (SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))

                    {
                        // Populate Gridview based off SID
                        sqlConnect1.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT ServiceName, ServiceDate, Origin, Destination, EstHours, Mileage, Fuel FROM Service WHERE ServiceID = " + ySID, sqlConnect1);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        SpecificGV.DataSource = dt;
                        SpecificGV.DataBind();

                    }

                    using (SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))

                    {
                        // Populate Gridview based off SID
                        sqlConnect2.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT Equipment.EquipmentName, EquipmentRent.RentDate, EquipmentRent.RentCondition " + 
                            "FROM Equipment INNER JOIN EquipmentRent ON Equipment.EquipmentID = EquipmentRent.EquipmentID INNER JOIN Service ON EquipmentRent.ServiceID = Service.ServiceID " + 
                            "WHERE Service.ServiceID = " + ySID, sqlConnect2);
                        DataTable dt1 = new DataTable();
                        adapter.Fill(dt1);
                        VehicleGV.DataSource = dt1;
                        VehicleGV.DataBind();

                    }

                }


            }
        }


    }
}