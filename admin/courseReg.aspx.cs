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
using System.Runtime.Remoting.Messaging;
using System.Activities.Statements;


public partial class pages_courseReg : System.Web.UI.Page
{

    public static List<string> courseData = new List<string>();

    protected void Page_Load(object sender, EventArgs e)
    {

        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();


        string query = "SELECT c.CourseID, c.CourseCode, c.CourseTitle, c.CreditHours, c.Semester,CASE WHEN p.CourseCode IS NULL THEN 'None' ELSE p.CourseCode END AS PrereqCourseCode FROM Course c LEFT JOIN Course p ON c.PrereqCourseID = p.CourseID;";
        SqlDataAdapter sda = new SqlDataAdapter(query, connection);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();

        query = "select CourseTitle,CourseCode from Course;";
        SqlCommand command = new SqlCommand(query, connection);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            ListItem courseCodes = new ListItem();
            courseCodes.Text = reader["CourseTitle"].ToString();
            courseCodes.Value = reader["CourseCode"].ToString();
            courseCodesDDL.Items.Add(courseCodes);
        }

        reader.Close();

        query = "select EMAIL from instructor join (select InstructorID,count(*) as course_count from CourseInstructors\r\ngroup by InstructorID) as insCount on insCount.InstructorID=Instructor.InstructorID\r\njoin USERS on Instructor.USER_ID=USERS.USER_ID\r\nwhere course_count < 3\r\nunion\r\nselect email from Instructor left outer join CourseInstructors on Instructor.InstructorID=CourseInstructors.InstructorID\r\njoin USERS on Instructor.USER_ID=USERS.USER_ID\r\nwhere CourseID is NULL;";
        SqlCommand newCommand = new SqlCommand(query, connection);

        SqlDataReader reader2 = newCommand.ExecuteReader();
        while (reader2.Read())
        {
            ListItem instructorEmails = new ListItem();
            instructorEmails.Text = reader2["EMAIL"].ToString();
            instructorEmails.Value = reader2["EMAIL"].ToString();
            ProfessorEmails.Items.Add(instructorEmails);
        }
        reader2.Close();


        query = "SELECT i.instructorID, c.CourseCode, u.EMAIL AS InstructorEmail FROM CourseInstructors ci JOIN Course c ON ci.CourseID = c.CourseID JOIN Instructor i ON ci.InstructorID = i.InstructorID JOIN Users u ON i.USER_ID = u.USER_ID;";
        SqlDataAdapter sqlAdap = new SqlDataAdapter(query, connection);
        DataTable dataTab = new DataTable();
        sqlAdap.Fill(dataTab);
        showAllAssignment.DataSource = dataTab;
        showAllAssignment.DataBind();

        connection.Close();



    }
    protected void AssignButton_Click(object sender, EventArgs e)
    {
        string courseCode = courseCodesDDL.Text;
        string instructEmail = ProfessorEmails.Text;
        int courseID = 0, instructorID = 0;

        Debug.WriteLine(courseCode + instructEmail);


        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();


        string query = "select CourseID from course where CourseCode=@courseCode";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@courseCode", courseCode);

        SqlDataReader reader = command.ExecuteReader();

        if(reader.Read())
        {
            courseID = Convert.ToInt32(reader["CourseID"]);
        }
        reader.Close();

        query = "select InstructorID from USERS, Instructor where USERS.USER_ID=Instructor.USER_ID and EMAIL=@email;";
        SqlCommand newCommand = new SqlCommand(query, connection);
        newCommand.Parameters.AddWithValue("@email", instructEmail);

        SqlDataReader reader2 = newCommand.ExecuteReader();

        if (reader2.Read())
        {
            instructorID = Convert.ToInt32(reader2["InstructorID"]);
        }
        reader2.Close();



        query = "Insert into CourseInstructors(CourseID, InstructorID) values (@courseID, @instructorID)";
        SqlCommand newCommand2 = new SqlCommand(query, connection);
        newCommand2.Parameters.AddWithValue("@courseID", courseID);
        newCommand2.Parameters.AddWithValue("@instructorID", instructorID);
        int rowsAffected = newCommand2.ExecuteNonQuery();


        query = "Insert into AuditTable(auditAction,date) values(' (admin) assign the course to a teacher having instructorEMail  "+ instructEmail+" and courseID "+ courseID +" ', GETDATE()) ";
        SqlCommand auditcommand = new SqlCommand(query, connection);
        int test = auditcommand.ExecuteNonQuery();
        connection.Close();



        if (rowsAffected > 0)
        {
            Response.Redirect("/admin/courseReg.aspx");    
        }
        else
        {
            Debug.WriteLine("Error: No rows were affected.");
        }

        Debug.WriteLine(courseID+ " " + instructorID);


    }
    protected void viewBtn_Click(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;

        string CourseID = row.Cells[0].Text.ToString(); //0              
        string CourseCode = row.Cells[1].Text.ToString();//1
        string CourseTitle = row.Cells[2].Text.ToString();//2
        string CreditHours = row.Cells[3].Text.ToString();//3
        string Semester = row.Cells[4].Text.ToString();//4
        string Prereq = row.Cells[5].Text.ToString();//5


        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);


        string query = "Select SectionID, SectionName, Course.CourseID, CourseCode, CourseTitle, CreditHours,Semester  from Sections join Course on sections.CourseID=Course.CourseID and Course.CourseID=@courseID;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@courseID", CourseID);


        
        SqlDataAdapter viewC = new SqlDataAdapter();
        viewC.SelectCommand = command;
        DataTable viewDataSet = new DataTable();
        viewC.Fill(viewDataSet);
        showCourseSections.DataSource = viewDataSet;
        showCourseSections.DataBind();

        if(viewDataSet.Rows.Count > 0)
            noRecordFound.Visible = false;
        else
            noRecordFound.Visible = true;

    }



}
