using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;


public partial class pages_manageFaculty : System.Web.UI.Page
{
    String userID, InstructorID;
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();
        string query = "select * from USERS ,(select * from Instructor) as data where data.USER_ID=USERS.USER_ID;";
        SqlDataAdapter sda = new SqlDataAdapter(query, connection);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();


    }

    protected void addFacultyBtn(object sender, EventArgs e)
    {
        // Add code here to perform the desired action when the button is clicked
        Response.Redirect("/admin/addFaculty.aspx");
    }

    protected void grd_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Get the updated data from the GridViewRow object that triggered the event
        string cnic = e.NewValues["CNIC"].ToString();
        string password = e.NewValues["PASSWORD"].ToString();
        string email = e.NewValues["EMAIL"].ToString();
        string firstName = e.NewValues["FIRST_NAME"].ToString();
        string lastName = e.NewValues["LAST_NAME"].ToString();
        string gender = e.NewValues["GENDER"].ToString();
        string instructorID = e.NewValues["InstructorID"].ToString();
        string rank = e.NewValues["Rank"].ToString();

        Debug.WriteLine(cnic + email);
    }

    protected void updateBtn_Click(object sender, EventArgs e)
    {
        // Get the row that contains the clicked "Update" button
        GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;

        // Get the values of the cells in the row
        lbl_id1.Text = row.Cells[0].Text;
        Text1.Text = row.Cells[1].Text; //cnic
        Text2.Text = row.Cells[2].Text; //password
        Text3.Text = row.Cells[3].Text; //email
        Text4.Text = row.Cells[4].Text; // firstName
        Text5.Text = row.Cells[5].Text; //LastName
        rGender.SelectedValue = row.Cells[6].Text; //gender
        lbl_id2.Text = row.Cells[7].Text; //IID
        Text7.Text = row.Cells[8].Text; //rank

    }



    protected void updateDataBtn_click(object sender, EventArgs e)
    {

        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();
        string query = "Update USERS set CNIC=@cnic, PASSWORD=@Password, EMAIL=@email, FIRST_NAME=@firstName, LAST_NAME=@lastName, GENDER=@gender  where USER_ID=@userID;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@cnic", Text1.Text);
        command.Parameters.AddWithValue("@Password", Text2.Text);
        command.Parameters.AddWithValue("@email", Text3.Text);
        command.Parameters.AddWithValue("@firstName", Text4.Text);
        command.Parameters.AddWithValue("@lastName", Text5.Text);
        command.Parameters.AddWithValue("@gender", rGender.SelectedValue);
        command.Parameters.AddWithValue("@userID", lbl_id1.Text);
        int rowsAffected = command.ExecuteNonQuery();

        

        if (rowsAffected > 0)
        {
            query = "Update Instructor set Rank=@rank where InstructorID=@i_id";

            SqlCommand newCommand = new SqlCommand(query, connection);
            newCommand.Parameters.AddWithValue("@rank", Text7.Text);
            newCommand.Parameters.AddWithValue("@i_id", lbl_id2.Text);

            int rowsAffected2 = newCommand.ExecuteNonQuery();

            query = "Insert into AuditTable(auditAction,date) values(' (admin) update the faculty information ', GETDATE()) ";
            SqlCommand auditcommand = new SqlCommand(query, connection);
            int test = auditcommand.ExecuteNonQuery();
            connection.Close();

            if (rowsAffected > 0)
            {
                Response.Redirect("/admin/manageFaculty.aspx");
            }
            else
            {
                Debug.WriteLine("Error: No rows were affected.");
            }

        }
        else
        {
            Debug.WriteLine("Error: No rows were affected.");
        }

        connection.Close();
    }
    protected void deleteBtn_Click(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
        lbl_id1.Text = row.Cells[0].Text; //user_id
        lbl_id2.Text = row.Cells[7].Text; //IID

        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        string query = "Delete from CourseInstructors where InstructorID=@i_id;";
        SqlCommand pastCommand = new SqlCommand(query, connection);
        pastCommand.Parameters.AddWithValue("@i_id", lbl_id2.Text);
        int rowsAffected1 = pastCommand.ExecuteNonQuery();


            query = "Delete from Instructor where InstructorID=@i_id;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@i_id", lbl_id2.Text);
            int rowsAffected = command.ExecuteNonQuery();



            query = "Delete from USERS where USER_ID=@userID;";
            SqlCommand newCommand = new SqlCommand(query, connection);
            newCommand.Parameters.AddWithValue("@userID", lbl_id1.Text);

            int rowsAffected2 = newCommand.ExecuteNonQuery();

        query = "Insert into AuditTable(auditAction,date) values(' (admin) delete the faculty member having facultyID "+ lbl_id2.Text + " ', GETDATE()) ";
        SqlCommand auditcommand = new SqlCommand(query, connection);
        int test = auditcommand.ExecuteNonQuery();
        connection.Close();

        if (rowsAffected > 0)
            {
                 Response.Redirect("/admin/manageFaculty.aspx");
            }
            else
            {
               Debug.WriteLine("Error: No rows were affected.");
            }

            
        connection.Close();


    }

}