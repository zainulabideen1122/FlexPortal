using ASP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class student_feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }


    protected void Unnamed1_Click(object sender, EventArgs e)
    {

        List<string> userData = new List<string>();
        if (Session["UserData"] != null)
        {
            userData = (List<string>)Session["UserData"];
        }

        string selected1 = Request.Form["row-1"];
        string selected2 = Request.Form["row-2"];
        string selected3 = Request.Form["row-3"];
        string selected4 = Request.Form["row-4"];
        string selected5 = Request.Form["row-5"];
        string selected6 = Request.Form["c1row-1"];
        string selected7 = Request.Form["c1row-2"];
        string selected8 = Request.Form["c1row-3"];
        string selected9 = Request.Form["c1row-4"];
        string selected10 = Request.Form["c1row-5"];
        string selected11 = Request.Form["c2row-1"];
        string selected12 = Request.Form["c2row-2"];
        string selected13 = Request.Form["c2row-3"];
        string selected14 = Request.Form["c2row-4"];
        string selected15 = Request.Form["c2row-5"];
        string selected16 = Request.Form["c3row-1"];
        string selected17 = Request.Form["c3row-2"];
        string selected18 = Request.Form["c3row-3"];
        string selected19 = Request.Form["c3row-4"];
        string comment = comments.Value;
        string sid = Request.QueryString["id"];
        string arn = userData[7];
        string roll = userData[8];

        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Feedback VALUES (@arn, @sid, @selected1, @selected2, @selected3, @selected4, @selected5, @selected6, @selected7, @selected8, @selected9, @selected10, @selected11, @selected12, @selected13, @selected14, @selected15, @selected16, @selected17, @selected18, @selected19, @comment)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@arn", arn);
                command.Parameters.AddWithValue("@sid", sid);
                command.Parameters.AddWithValue("@selected1", selected1);
                command.Parameters.AddWithValue("@selected2", selected2);
                command.Parameters.AddWithValue("@selected3", selected3);
                command.Parameters.AddWithValue("@selected4", selected4);
                command.Parameters.AddWithValue("@selected5", selected5);
                command.Parameters.AddWithValue("@selected6", selected6);
                command.Parameters.AddWithValue("@selected7", selected7);
                command.Parameters.AddWithValue("@selected8", selected8);
                command.Parameters.AddWithValue("@selected9", selected9);
                command.Parameters.AddWithValue("@selected10", selected10);
                command.Parameters.AddWithValue("@selected11", selected11);
                command.Parameters.AddWithValue("@selected12", selected12);
                command.Parameters.AddWithValue("@selected13", selected13);
                command.Parameters.AddWithValue("@selected14", selected14);
                command.Parameters.AddWithValue("@selected15", selected15);
                command.Parameters.AddWithValue("@selected16", selected16);
                command.Parameters.AddWithValue("@selected17", selected17);
                command.Parameters.AddWithValue("@selected18", selected18);
                command.Parameters.AddWithValue("@selected19", selected19);
                command.Parameters.AddWithValue("@comment", comment);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                query = "Insert into AuditTable(auditAction,date) values('student "+ roll +" added feedback to the section" +sid+ "',GETDATE()) ";
                SqlCommand auditcommand = new SqlCommand(query, connection);
                int test = auditcommand.ExecuteNonQuery();
                connection.Close();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('Feedback Submitted');", true);
                Response.Redirect("./feedback_course.aspx");

            }
        }

        Debug.WriteLine(sid);
    }
  
}