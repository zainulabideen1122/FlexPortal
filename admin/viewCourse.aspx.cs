using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Messaging;
using System.Reflection;

public partial class pages_viewCourse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        string query = "select s.SectionID, SectionName, CASE WHEN u.EMAIL IS NULL THEN 'None' ELSE u.EMAIL END AS Instructor, s.Status, CASE WHEN NoofStudents IS NULL THEN 0 ELSE NoofStudents END as NoodStudents, c.CourseID, c.CourseCode, c.CourseTitle, c.CreditHours, CASE WHEN c.PrereqCourseID IS NULL THEN 'None' ELSE c.CourseTitle END AS PreReq_CourseID , c.Semester from Sections s left join (select count(*) as NoofStudents, s.SectionID from sections s join StudentsEnrollment e on s.SectionID=e.SectionID group by s.SectionID) as d on s.SectionID=d.SectionID join Course c on s.CourseID=c.CourseID left join Instructor ins on CourseInstruct_ID=InstructorID left join USERS u on u.USER_ID=ins.USER_ID join Course c2 on c.CourseID=c2.CourseID order by c2.CourseTitle;";
        SqlCommand command = new SqlCommand(query, connection);

        SqlDataAdapter viewC = new SqlDataAdapter();
        viewC.SelectCommand = command;
        DataTable viewDataSet = new DataTable();
        viewC.Fill(viewDataSet);
        viewCourseSections.DataSource = viewDataSet;
        viewCourseSections.DataBind();


        foreach (GridViewRow row in viewCourseSections.Rows)
        {
            int status = Convert.ToInt32(row.Cells[3].Text);
            Button deleteButton = (Button)row.FindControl("deleteBtn");

            if (status != 0)
            {
                deleteButton.Enabled = false;
                deleteButton.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                deleteButton.Enabled = true;
                deleteButton.BackColor = System.Drawing.Color.Red;
            }

        }



        connection.Open();
        query = "select courseTitle,courseID  from Course;";
        SqlCommand newCommand = new SqlCommand(query, connection);

        SqlDataReader reader = newCommand.ExecuteReader();

        while (reader.Read())
        {
            ListItem courseCodes = new ListItem();
            courseCodes.Text = reader["courseTitle"].ToString();
            courseCodes.Value = reader["courseID"].ToString();
            viewCourseCodes.Items.Add(courseCodes);
        }

        reader.Close();


        query = "select EMAIL, InstructorID from users, (select * from Instructor) as data where users.USER_ID=data.USER_ID;";
        SqlCommand newCommand1 = new SqlCommand(query, connection);

        SqlDataReader reader1 = newCommand1.ExecuteReader();

        while (reader1.Read())
        {
            ListItem instructorEmails = new ListItem();
            instructorEmails.Text = reader1["EMAIL"].ToString();
            instructorEmails.Value = reader1["InstructorID"].ToString();
            assignViewCourseCode.Items.Add(instructorEmails);
        }

        reader1.Close();

        

    }
    protected void addSection_Click(object sender, EventArgs e)
    {

        ListItem selectedCourse = viewCourseCodes.SelectedItem as ListItem;
        string sectionN = sectionName.Text;
        if (selectedCourse != null)
        {
            string selectedCourseCode = selectedCourse.Text;
            string CourseID = selectedCourse.Value;

           

            // Use the selectedCourseCode and selectedCourseID values as needed

            Debug.WriteLine(CourseID);

            string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "Insert into Sections (SectionName, CourseID, CourseInstruct_ID, Status) values (@sectionName, @courseID, NULL, 0);";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@sectionName", sectionN);
            command.Parameters.AddWithValue("@courseID", CourseID);

            int rowsAffected = command.ExecuteNonQuery();

            query = "Insert into AuditTable(auditAction,date) values(' (admin) creates a new section having sectionName "+sectionN+" of a course having courseID "+CourseID+" ', GETDATE()) ";
            SqlCommand auditcommand = new SqlCommand(query, connection);
            int test = auditcommand.ExecuteNonQuery();
            connection.Close();

            if (rowsAffected > 0)
            {
                Response.Redirect("/admin/viewCourse.aspx");
            }
        }

        
    }

    protected void assignCourseCode_Selected(object sender, EventArgs e)
    {
        Debug.WriteLine(assignViewCourseCode.SelectedValue);
        string instructorID = assignViewCourseCode.SelectedValue;

        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        string query = "select courseTitle, SectionID, SectionName, Status, CourseCoordinator from CourseInstructors ci join Sections s on s.CourseID=ci.CourseID and InstructorID=@instructorID and s.Status=0 left join Course c on ci.CourseID=c.CourseID";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@instructorID", instructorID);

        SqlDataAdapter viewC = new SqlDataAdapter();
        viewC.SelectCommand = command;
        DataTable viewDataSet = new DataTable();
        viewC.Fill(viewDataSet);
        selectSection.DataSource = viewDataSet;
        selectSection.DataTextField = "SectionName";

        if (viewDataSet.Rows.Count > 0)
        {
            showCourseTitle.Text = viewDataSet.Rows[0]["courseTitle"].ToString();
            showCourseTitle.Visible = true;
        }
        else
        {
            showCourseTitle.Visible = false;
        }

        selectSection.DataValueField = "SectionID";
        selectSection.DataBind();
        

    }

    

    protected void assignSection_Click(object sender, EventArgs e)
    {

        string instructorID = assignViewCourseCode.SelectedValue;
        string sectionID = selectSection.SelectedValue;
        string courseInstructorID = "";
        string courseID = "";

        Debug.WriteLine(instructorID + " " + sectionID);

        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        string query = "select CourseInstruct_ID, courseID from CourseInstructors where InstructorID=@instructorID";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@instructorID", instructorID);
        SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            courseInstructorID = reader["CourseInstruct_ID"].ToString();
            courseID = reader["courseID"].ToString();
        }
        reader.Close();

        if (selectSection.SelectedIndex != -1)
        {
            
            query = "Update Sections set CourseInstruct_ID=@courseInstructID where SectionID=@sectionID";
            SqlCommand command1 = new SqlCommand(query, connection);
            command1.Parameters.AddWithValue("@sectionID", selectSection.SelectedValue);
            command1.Parameters.AddWithValue("@courseInstructID", courseInstructorID);
            int rowsAffected = command1.ExecuteNonQuery();

            if (rowsAffected > 0)
            {

                query = "Insert into MarksDistribution (CourseID, SectionID, AssignmentWeight, QuizzesWeight, Mid1Weight, Mid2Weight, FinalWeight) values (@courseID, @sectionID, 15, 15, 15, 15, 40);";

                //SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand newCommand = new SqlCommand(query, connection);
                newCommand.Parameters.AddWithValue("@courseID", courseID);
                newCommand.Parameters.AddWithValue("@sectionID", sectionID);

                int rowsAffected1 = newCommand.ExecuteNonQuery();



                query = "Insert into AuditTable(auditAction,date) values(' (admin) assign a section "+sectionID+" of a course "+courseID+" to the instructor " + courseInstructorID + " ', GETDATE()) ";
                SqlCommand auditcommand = new SqlCommand(query, connection);
                int test = auditcommand.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                {
                    Response.Redirect("/admin/viewCourse.aspx");
                }
     
            }
        }



    }


    protected void deleteSection_click(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
       
        int sectionID = Convert.ToInt32(row.Cells[0].Text);
        Debug.WriteLine(sectionID);

        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        string query = "Delete from Evaluations where SectionID=@sectionID;";
        SqlCommand pastCommand = new SqlCommand(query, connection);
        pastCommand.Parameters.AddWithValue("@sectionID", sectionID);
        int rowsAffected1 = pastCommand.ExecuteNonQuery();


        query = "Delete from StudentsEnrollment where sectionID=@sectionID;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@sectionID", sectionID);
        int rowsAffected = command.ExecuteNonQuery();



        query = "Delete from Sections where sectionID=@sectionID;";
        SqlCommand newCommand = new SqlCommand(query, connection);
        newCommand.Parameters.AddWithValue("@sectionID", sectionID);

        int rowsAffected2 = newCommand.ExecuteNonQuery();

        query = "Insert into AuditTable(auditAction,date) values(' (admin) delete the section having sectionID " + sectionID + " ', GETDATE()) ";
        SqlCommand auditcommand = new SqlCommand(query, connection);
        int test = auditcommand.ExecuteNonQuery();
        connection.Close();

        if (rowsAffected > 0)
        {
            Response.Redirect("/admin/viewCourse.aspx");
        }
        else
        {
            Debug.WriteLine("Error: No rows were affected.");
        }


        //connection.Close();

    }



}