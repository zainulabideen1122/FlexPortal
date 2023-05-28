using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

public partial class Attendance : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> SECTION = new List<string>();
        if (Session["SECTION"] != null)
        {
            SECTION = (List<string>)Session["SECTION"];
        }

        string SID = Request.QueryString["SID"];
        string CID = Request.QueryString["CID"];

        /*Debug.WriteLine(SID);
        Debug.WriteLine(CID*/
        List<string> userData = new List<string>();
        if (Session["UserData"] != null)
        {
            userData = (List<string>)Session["UserData"];
        }

        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        string query = "Select ST.RollNum ,S.SectionName from Course C join Sections S on S.CourseID = C.CourseID join StudentsEnrollment SE on SE.SectionID = S.SectionID join Student ST on ST.ARN = SE.StudentID where C.CourseTitle = '" + CID + "' and S.SectionName = '" + SID + "' group by ST.RollNum ,S.SectionName;";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@CID", CID);
        command.Parameters.AddWithValue("@SID", SID);
        //Debug.WriteLine(query);

        SqlDataAdapter sda = new SqlDataAdapter(command);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        lblDate.DataBind();             //date show.
        GridView2.DataSource = dt;
        GridView2.DataBind();

    }

    protected void btn_Attendance(object sender, EventArgs e)
    {
        string connectionString = "Data Source=(local)\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        foreach (GridViewRow row in GridView2.Rows)
        {
            Debug.WriteLine("GOT ATTENDANCE");

            string rollNum = row.Cells[0].Text;
            string sectionName = row.Cells[1].Text;
            string CID = Request.QueryString["CID"];
            string Present = "0";
            CheckBox presentCheckBox = row.FindControl("PresentCheckBox") as CheckBox;
            if (presentCheckBox != null && presentCheckBox.Checked)
            {
                Present = "1";
            }
            string query = "Insert into Attendance (Date, SectionID, StudentID,CourseID ,IsPresent) Select getdate(),sectionID,Student.ARN,Course.CourseID,'" +  Present + "' from Student join Sections on SectionName='"+ sectionName +"' join Course on Course.CourseTitle='" + CID+ "' where Student.RollNum='" + rollNum + "'";
            Debug.WriteLine(query);
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
           
        }
        Debug.WriteLine("GOT ATTENDANCE 2");
        connection.Close();
        Response.Redirect(Request.RawUrl); // refresh the page after saving
    }


}