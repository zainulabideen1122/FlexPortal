using System;
using System.Activities.Statements;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class student_feedback_course : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userData"] == null)
        {
            Debug.WriteLine("Session object is null.");
        }
        else
        {
            Debug.WriteLine("Not NULL");

            List<string> userData = (List<string>)Session["userData"];

            string arn = userData[7];
            
            string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT CourseTitle, SectionName, StudentsEnrollment.SectionID as sID FROM StudentsEnrollment JOIN Student ON StudentsEnrollment.StudentID= STUDENT.ARN  JOIN SECTIONS ON StudentsEnrollment.SectionID= SectionS.SectionID JOIN COURSE ON SECTIONS.CourseID = Course.CourseID WHERE Student.ARN = '" + arn + "'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@arn", arn);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            myGridView.DataSource = dt;
            myGridView.DataBind();
            
        }
        }
    protected void myGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

}