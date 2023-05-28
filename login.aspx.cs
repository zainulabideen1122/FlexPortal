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

public partial class _Default : System.Web.UI.Page
{
    public static List<string> userData = new List<string>();
    List<string> passData = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
    }


    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);


        string email = txtUsername.Text;
        string password = txtPassword.Value.ToString();
        string query = "";
        if (Option1.Checked)
        {
            query = "SELECT * FROM Users WHERE email=@userEmail AND Password=@pass;";
        }
        else if (Option2.Checked)
        {
            query = "SELECT USERS.*,Instructor.InstructorID,Instructor.Rank,Instructor.USER_ID AS ID FROM USERS JOIN Instructor ON USERS.USER_ID=Instructor.USER_ID  and EMAIL=@userEmail and PASSWORD=@pass;";
        }
        else if (Option3.Checked)
        {
            query = "select Student.*,USERS.CNIC,USERS.EMAIL,USERS.PASSWORD,USERS.FIRST_NAME,USERS.LAST_NAME,USERS.GENDER,USERS.PERMISSION from Student join USERS on Student.User_ID=USERS.User_ID AND USERS.EMAIL='" + email + "' AND USERS.PASSWORD='" + password + "' ;";
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "notCheckedAlert", "alert('Please select admin, or faculty or student');", true);
            Debug.WriteLine("not checked alert!");
            Response.Redirect("login.aspx");
        }

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@userEmail", email);
        command.Parameters.AddWithValue("@pass", password);


        connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        userData.Clear();
        if (reader.HasRows)
        {
            Debug.WriteLine("GOT DATA!");
            if (Option1.Checked)
            {
                Debug.WriteLine("Option1Checked");

                if (reader.Read())
                {
                    userData.Add(reader["USER_ID"].ToString());
                    userData.Add(reader["CNIC"].ToString());
                    userData.Add(reader["PASSWORD"].ToString());
                    userData.Add(reader["EMAIL"].ToString());
                    userData.Add(reader["FIRST_NAME"].ToString());
                    userData.Add(reader["LAST_NAME"].ToString());
                    userData.Add(reader["GENDER"].ToString());
                    userData.Add(reader["PERMISSION"].ToString());
                }
                if (userData[3] == email && userData[2] == password)
                {
                    Session["UserData"] = userData;
                    Response.Redirect("/admin/Home.aspx");
                }
                else
                {
                    Debug.WriteLine(txtUsername.Text );
                    Debug.WriteLine(txtPassword.Value);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('Wrong Email or password, Please try again with different email or password!');", true);
                    txtUsername.Text = "";
                    txtPassword.Value = "";
                }
            }
            

            if (Option2.Checked)
            {
                Debug.WriteLine("Option2Checked");
                if (reader.Read())
                {
                    userData.Add(reader["USER_ID"].ToString());
                    userData.Add(reader["CNIC"].ToString());
                    userData.Add(reader["PASSWORD"].ToString());
                    userData.Add(reader["EMAIL"].ToString());
                    userData.Add(reader["FIRST_NAME"].ToString());
                    userData.Add(reader["LAST_NAME"].ToString());
                    userData.Add(reader["GENDER"].ToString());
                    userData.Add(reader["PERMISSION"].ToString());
                    userData.Add(reader["InstructorID"].ToString());
                    userData.Add(reader["Rank"].ToString());
                    userData.Add(reader["id"].ToString());
                }
                if (userData[3] == email && userData[2] == password)
                {
                    Session["UserData"] = userData;
                    Response.Redirect("/faculty/Instructor.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('Wrong Email or password, Please try again with different email or password!');", true);
                    txtUsername.Text = "";
                    txtPassword.Value = "";
                }
            }
            
            if (Option3.Checked)
            {
                Debug.WriteLine("Option3Checked");
                if (reader.Read())
                {
                    userData.Add(reader["USER_ID"].ToString());
                    userData.Add(reader["CNIC"].ToString());
                    userData.Add(reader["PASSWORD"].ToString());
                    userData.Add(reader["EMAIL"].ToString());
                    userData.Add(reader["FIRST_NAME"].ToString());
                    userData.Add(reader["LAST_NAME"].ToString());
                    userData.Add(reader["GENDER"].ToString());
                    userData.Add(reader["ARN"].ToString());
                    userData.Add(reader["RollNum"].ToString());
                    userData.Add(reader["Batch"].ToString());
                    userData.Add(reader["Country"].ToString());
                    userData.Add(reader["BloodGroup"].ToString());
                    userData.Add(reader["MobileNum"].ToString());
                    userData.Add(reader["City"].ToString());
                    userData.Add(reader["Address"].ToString());
                    userData.Add(reader["FatherCNIC"].ToString());
                    userData.Add(reader["Semester"].ToString());
                }
                if (userData[3] == email && userData[2] == password)
                {
                    Session["UserData"] = userData;
                    //Response.Redirect("student/student.aspx");
                    Response.Redirect("student/student.aspx");
                }
                else
                {
                    Debug.WriteLine(txtUsername.Text);
                    Debug.WriteLine(txtPassword.Value);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('Wrong Email or password, Please try again with different email or password!');", true);
                    txtUsername.Text = "";
                    txtPassword.Value = "";
                }
            }
            else
            {
                Debug.WriteLine("Option3 is not checked!");
            }

        }
        else
        {
            Debug.WriteLine("No data found.");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('Wrong Email or password, Please try again with different email or password!');", true);
            txtUsername.Text = "";
            txtPassword.Value = "";
        }


        connection.Close();
        
    }

}

