using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_manageStudent : System.Web.UI.Page
{
    String userID, InstructorID;
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();
        string query = "select * from USERS, Student  where USERS.USER_ID=Student.User_ID;";
        SqlDataAdapter sda = new SqlDataAdapter(query, connection);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();


    }

    protected void addFacultyBtn(object sender, EventArgs e)
    {
        // Add code here to perform the desired action when the button is clicked
        Response.Redirect("/admin/addStudent.aspx");
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
        Text7.Text = row.Cells[7].Text; //permission
        lbl_id2.Text = row.Cells[8].Text; //arn
        Text8.Text = row.Cells[9].Text; //rollNum
        Text9.Text = row.Cells[10].Text; //status
        Text10.Text = row.Cells[11].Text; //Batch
        Text11.Text = row.Cells[12].Text; //Country
        Text12.Text = row.Cells[13].Text; //Blood group
        Text13.Text = row.Cells[14].Text; // Phone#
        Text14.Text = row.Cells[15].Text; //City
        Text15.Text = row.Cells[16].Text; //Address
        Text16.Text = row.Cells[17].Text; //FatherCnic
        Text17.Text = row.Cells[18].Text; //semester

    }



    protected void updateDataBtn_click(object sender, EventArgs e)
    {

        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();
        string query = "Update USERS set CNIC=@cnic, PASSWORD=@Password, EMAIL=@email, FIRST_NAME=@firstName, LAST_NAME=@lastName, GENDER=@gender, PERMISSION=@permission  where USER_ID=@userID;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@cnic", Text1.Text);
        command.Parameters.AddWithValue("@Password", Text2.Text);
        command.Parameters.AddWithValue("@email", Text3.Text);
        command.Parameters.AddWithValue("@firstName", Text4.Text);
        command.Parameters.AddWithValue("@lastName", Text5.Text);
        command.Parameters.AddWithValue("@gender", rGender.SelectedValue);
        command.Parameters.AddWithValue("@userID", lbl_id1.Text);
        command.Parameters.AddWithValue("@permission", Text7.Text);

        int rowsAffected = command.ExecuteNonQuery();

        if (rowsAffected > 0)
        {
            query = "Update Student set RollNum=@rollNum, Status=@status, Batch=@batch, Country=@country, BloodGroup=@bloodGroup, MobileNum=@phoneNum, City=@city, Address=@address, FatherCNIC=@fatherCnic where ARN=@arn";

            SqlCommand newCommand = new SqlCommand(query, connection);
            newCommand.Parameters.AddWithValue("@rollNum", Text8.Text);
            newCommand.Parameters.AddWithValue("@status", Text9.Text);
            newCommand.Parameters.AddWithValue("@batch", Text10.Text);
            newCommand.Parameters.AddWithValue("@country", Text11.Text);
            newCommand.Parameters.AddWithValue("@bloodGroup", Text12.Text);
            newCommand.Parameters.AddWithValue("@phoneNum", Text13.Text);
            newCommand.Parameters.AddWithValue("@city", Text14.Text);
            newCommand.Parameters.AddWithValue("@address", Text15.Text);
            newCommand.Parameters.AddWithValue("@fatherCnic", Text16.Text);
            newCommand.Parameters.AddWithValue("@arn", lbl_id2.Text);

            int rowsAffected2 = newCommand.ExecuteNonQuery();


            query = "Insert into AuditTable(auditAction,date) values(' (admin) update the student information', GETDATE()) ";
            SqlCommand auditcommand = new SqlCommand(query, connection);
            int test = auditcommand.ExecuteNonQuery();
            connection.Close();

            if (rowsAffected > 0)
            {
                Response.Redirect("/admin/manageStudent.aspx");
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

        string query = "Delete from Evaluations where StudentID=@arn;";
        SqlCommand pastCommand = new SqlCommand(query, connection);
        pastCommand.Parameters.AddWithValue("@arn", lbl_id2.Text);
        int rowsAffected1 = pastCommand.ExecuteNonQuery();


        query = "Delete from StudentEnrollment where StudentID=@arn;";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@arn", lbl_id2.Text);
        int rowsAffected2 = command.ExecuteNonQuery();


        query = "Delete from Student where User_ID=@userID;";
        SqlCommand newCommand1 = new SqlCommand(query, connection);
        newCommand1.Parameters.AddWithValue("@userID", lbl_id1.Text);
        int rowsAffected3 = newCommand1.ExecuteNonQuery();


        query = "Delete from USERS where USER_ID=@userID;";
        SqlCommand newCommand = new SqlCommand(query, connection);
        newCommand.Parameters.AddWithValue("@userID", lbl_id1.Text);
        
        int rowsAffected = newCommand.ExecuteNonQuery();


        query = "Insert into AuditTable(auditAction,date) values(' (admin) delete the student having arn "+ lbl_id2.Text + " ', GETDATE()) ";
        SqlCommand auditcommand = new SqlCommand(query, connection);
        int test = auditcommand.ExecuteNonQuery();
        connection.Close();

        if (rowsAffected > 0)
        {
            Response.Redirect("/admin/manageStudent.aspx");
        }
        else
        {
            Debug.WriteLine("Error: No rows were affected.");
        }


        connection.Close();


    }

}