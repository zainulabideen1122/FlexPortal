using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CourseAttendance : System.Web.UI.Page
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

            string IDD = userData[8];
            string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select CC.CourseTitle, S.SectionName as Section,  CONCAT(U.FIRST_NAME, ' ', U.LAST_NAME) as Teacher from CourseInstructors CI join Sections S on CI.CourseID = S.CourseID and CI.InstructorID = @IDD and CI.InstructorID = S.CourseInstruct_ID join Course CC on CC.CourseID = S.CourseID join Instructor I on CI.InstructorID = I.InstructorID join USERS U on U.USER_ID = I.USER_ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IDD", IDD);
            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            showAllAssignment.DataSource = dt;
            showAllAssignment.DataBind();
            connection.Close();

        }
    }
}