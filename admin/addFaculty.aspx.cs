using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Security.Cryptography;

public partial class pages_addFaculty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void addFacultyBtn(object sender, EventArgs e)
    {
        //dafas
        string cnic, email, password, firstName, lastName, gender="", rank;
        cnic = TextBox1.Text;
        email = TextBox2.Text;
        password = TextBox3.Text;
        firstName = TextBox4.Text;
        lastName = TextBox5.Text;
        rank= TextBox7.Text;
        if (Option1.Checked)
        {
            gender = "M";
        }
        else if (Option2.Checked)
        {
            gender = "F";
        }

        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        string query = "select top(1) users.USER_ID  from USERS order by USER_ID desc;";
        SqlCommand command = new SqlCommand(query, connection);


        SqlDataReader reader = command.ExecuteReader();

        int userID = 0;

        if (reader.HasRows)
        {
            Debug.WriteLine("GOT DATA!");

            if (reader.Read())
            {
                userID = Convert.ToInt32(reader["USER_ID"]);
            }
        }
        userID++;

        reader.Close();

        query = "Insert into USERS (USER_ID, CNIC, PASSWORD, EMAIL, FIRST_NAME, LAST_NAME, GENDER, PERMISSION) values (@userID, @cnic,@password,@email,@firstName,@lastName,@gender,@permission)";

        //SqlTransaction transaction = connection.BeginTransaction();
        SqlCommand newCommand = new SqlCommand(query, connection);
        newCommand.Parameters.AddWithValue("@userID", userID);
        newCommand.Parameters.AddWithValue("@cnic", cnic);
        newCommand.Parameters.AddWithValue("@password", password);
        newCommand.Parameters.AddWithValue("@email", email);
        newCommand.Parameters.AddWithValue("@firstName", firstName);
        newCommand.Parameters.AddWithValue("@lastName", lastName);
        newCommand.Parameters.AddWithValue("@gender", gender);
        newCommand.Parameters.AddWithValue("@permission", 1);

        int rowsAffected = newCommand.ExecuteNonQuery();

        if (rowsAffected > 0)
        {
            query = "Insert into Instructor (USER_ID, Rank) values (@userID, @rank)";

            SqlCommand newCommand2 = new SqlCommand(query, connection);
            newCommand2.Parameters.AddWithValue("@userID", userID);
            newCommand2.Parameters.AddWithValue("@rank", rank);

            int rowsAffected2 = newCommand2.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                query = "Insert into AuditTable(auditAction,date) values('" + userID + " (admin) added new faculty member', GETDATE()) ";
                SqlCommand auditcommand = new SqlCommand(query, connection);
                int test = auditcommand.ExecuteNonQuery();
                connection.Close();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "newUserCreated", "alert('New user inserted successfully!');", true);
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
    protected void goBack(object sender, EventArgs e)
    {
        Response.Redirect("/admin/manageFaculty.aspx");
    }

}