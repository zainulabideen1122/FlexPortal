using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Activities.Statements;
using System.Reflection;
using System.Security.Cryptography;


public partial class student_course_reg : System.Web.UI.Page
{
    public static List<int> registered_list = new List<int> { };
    public static List<string> registered_courses= new List<string> { };
    public int total_cr_registered;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userData"] == null)
        {
            Debug.WriteLine("Session object is null.");
            total_cr_registered = 0;

        }
        else
        {
            Debug.WriteLine("Not NULL");
            total_cr_registered = 0;

            List<string> userData = (List<string>)Session["userData"];
            string arn = userData[7];
            string semester = userData[16];
            string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from Course join Student on Course.Semester=Student.Semester WHERE Student.Semester='" + semester+ "'AND ARN='" + arn + "'";

            SqlCommand command = new SqlCommand(query, connection);
            
            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            myGridView.DataSource = dt;

            if (!IsPostBack)
            {
                myGridView.DataBind();
            }

            int cr=0;

            query = "SELECT CourseCode FROM STUDENTSENROLLMENT JOIN SECTIONS ON STUDENTSENROLLMENT.SECTIONID = SECTIONS.SECTIONID JOIN Course ON Course.CourseID = Sections.CourseID WHERE STUDENTID = '" + arn + "';";
            SqlCommand command2 = new SqlCommand(query, connection);
            SqlDataReader reader = command2.ExecuteReader();

            while (reader.Read())
            {
                registered_courses.Add(reader["CourseCode"].ToString());
            }
           
            foreach (int index in registered_list) 
            {
                if (index >= 0)
                {
                    cr = Convert.ToInt32(myGridView.Rows[index].Cells[3].Text);
                    total_cr_registered += cr;
                    Debug.WriteLine("uwu");
                }
            }


            foreach(GridViewRow gvr in myGridView.Rows) 
            {
                Button register_button = (Button)gvr.FindControl("Button1");
                Button drop_button = (Button)gvr.FindControl("Button2");
                string coursecode = gvr.Cells[0].Text.ToString();

                DropDownList ddl = (DropDownList)gvr.FindControl("ddlSections");
                
                if (total_cr_registered > 18)
                {
                    register_button.Enabled = false;
                    register_button.BackColor = Color.Gray;
                }

                if (registered_courses.Contains(coursecode))
                {
                    //Debug.WriteLine(gvr.Cells[3].Text);
                    cr = Convert.ToInt32(gvr.Cells[3].Text);
                    total_cr_registered += cr;
                    register_button.Enabled = false;
                    register_button.BackColor = Color.Gray;
                    drop_button.Enabled = false;
                    drop_button.BackColor = Color.Gray;
                }

                else if (ddl.Items.Count == 0) 
                {
                    register_button.Enabled = false;
                    register_button.BackColor = Color.Gray;

                    drop_button.Enabled = false;
                    drop_button.BackColor = Color.Gray;
                }


                else if (registered_list.Contains(gvr.RowIndex)) 
                {
                    register_button.Enabled = false;
                    register_button.BackColor = Color.Gray;

                    drop_button.Enabled = true;
                    drop_button.BackColor = Color.MediumPurple;

                }
                else
                {
                    register_button.Enabled = true;
                    register_button.BackColor = Color.MediumPurple;
                    drop_button.Enabled = false;
                    drop_button.BackColor = Color.Gray;

                }
            }
        }
    }
    protected void myGridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void myGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int cr = 0;
        if (e.CommandName== "RegCourse")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selected_row =myGridView.Rows[index];
            Button register_button = (Button)selected_row.FindControl("Button1");
            register_button.Enabled = false;
            register_button.BackColor = Color.Gray;
            registered_list.Add(index);
            cr = Convert.ToInt32(myGridView.Rows[index].Cells[3].Text);
            total_cr_registered += cr;
            Button drop_button = (Button)selected_row.FindControl("Button2");
            drop_button.Enabled = true;
            drop_button.BackColor = Color.MediumPurple;

        }
        else if (e.CommandName == "Drop")
        {
            Debug.WriteLine("dropped");
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selected_row = myGridView.Rows[index];
            Button register_button = (Button)selected_row.FindControl("Button1");
            register_button.Enabled = true;
            register_button.BackColor = Color.MediumPurple;
            registered_list.Remove(index);
            cr = Convert.ToInt32(myGridView.Rows[index].Cells[3].Text);
            total_cr_registered -= cr;
            Button drop_button = (Button)selected_row.FindControl("Button2");
            drop_button.Enabled = false;
            drop_button.BackColor = Color.Gray;


        }

    }

    protected void myGridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button register_button = (Button)e.Row.FindControl("Button1");
            register_button.CommandArgument = e.Row.RowIndex.ToString();

            Button drop_button = (Button)e.Row.FindControl("Button2");
            drop_button.CommandArgument = e.Row.RowIndex.ToString();
        }
    }

    protected void registerCourse_Click(object sender, EventArgs e)
    {
        List<string> userData = (List<string>)Session["userData"];
        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        string arn = userData[7];
        connection.Open();

        foreach (int index in registered_list)
        {
            string course_code = myGridView.Rows[index].Cells[0].Text.ToString();
            DropDownList ddl = (DropDownList)myGridView.Rows[index].FindControl("ddlSections");
            string section_name = ddl.SelectedValue;
            string query = "insert into StudentsEnrollment(StudentID,SectionID) select '" + arn +"', SectionID from Course  join Sections on Course.CourseID=Sections.CourseID where CourseCode='"+ course_code +"' and SectionName='"+ section_name +"';";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();

            query = "Insert into AuditTable(auditAction,date) values('student " + arn + " registered course " + course_code + "',GETDATE()) ";
            SqlCommand auditcommand = new SqlCommand(query, connection);
            int test = auditcommand.ExecuteNonQuery();
            connection.Close();

            Debug.WriteLine(query);
        }
        registered_list.Clear();
        connection.Close();
        Response.Redirect("/student/course_reg.aspx");
        


    }

    protected void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }

        DropDownList ddl = (DropDownList)e.Row.FindControl("ddlSections");
        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        string course_code = e.Row.Cells[0].Text.ToString();
    
        string query = "SELECT SECTIONNAME FROM SECTIONS Left OUTER JOIN(SELECT SECTIONID, COUNT(*) AS STUDENTS  FROM STUDENTSENROLLMENT GROUP BY SECTIONID) AS STUDENTCOUNT ON SECTIONS.SECTIONID = STUDENTCOUNT.SECTIONID JOIN COURSE ON SECTIONS.COURSEID = COURSE.COURSEID WHERE COURSECODE = '"+course_code+"' AND (STUDENTS < 50 OR  STUDENTS is NULL)";
        SqlCommand command = new SqlCommand(query, connection);
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            ddl.Items.Add(reader["SECTIONNAME"].ToString());
        }
        reader.Close();
        connection.Close();

    }
}