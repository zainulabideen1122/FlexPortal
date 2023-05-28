using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Collections;

public partial class pages_approveCourses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();
        string query = "select s.SectionID, SectionName, CASE WHEN u.EMAIL IS NULL THEN 'None' ELSE u.EMAIL END AS Instructor, s.Status, CASE WHEN NoofStudents IS NULL THEN 0 ELSE NoofStudents END as NoofStudents, c.CourseID, c.CourseCode, c.CourseTitle, c.CreditHours, CASE WHEN c.PrereqCourseID IS NULL THEN -1 ELSE c.PrereqCourseID END AS PreReq_CourseID , c.Semester from Sections s left join (select count(*) as NoofStudents, s.SectionID from sections s join StudentsEnrollment e on s.SectionID=e.SectionID group by s.SectionID) as d on s.SectionID=d.SectionID join Course c on s.CourseID=c.CourseID left join Instructor ins on CourseInstruct_ID=InstructorID left join USERS u on u.USER_ID=ins.USER_ID join Course c2 on c.CourseID=c2.CourseID;";
        SqlDataAdapter sda = new SqlDataAdapter(query, connection);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        viewCoursesData.DataSource = dt;
        viewCoursesData.DataBind();

        foreach (GridViewRow row in viewCoursesData.Rows)
        {
            int noOfStudents = Convert.ToInt32(row.Cells[4].Text);
            Button approveBtn = (Button)row.FindControl("approveBtn");

            if (noOfStudents < 10)
            {
                approveBtn.Enabled = false;
                approveBtn.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                approveBtn.Enabled = true;
            }

            int sectionStatus = Convert.ToInt32(row.Cells[3].Text);
            if ( sectionStatus == 1)
            {
                approveBtn.Enabled = false;
                approveBtn.BackColor = System.Drawing.Color.Green;
            }

        }

    }


    protected void approveBtn_Click(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
        string sectionID = row.Cells[0].Text.ToString();

        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();
        String query = "Update Sections set Status=1 where SectionID=@sectionID;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@sectionID", sectionID);


        int rowsAffected = command.ExecuteNonQuery();

        query = "Insert into AuditTable(auditAction,date) values(' (admin) update the status to 1 of a section having sectionID "+ sectionID +"  ', GETDATE()) ";
        SqlCommand auditcommand = new SqlCommand(query, connection);
        int test = auditcommand.ExecuteNonQuery();
        connection.Close();

        if (rowsAffected > 0)
        {

            Response.Redirect("/admin/approveCourses.aspx");
        }

     }
}