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

public partial class student_attendance : System.Web.UI.Page
{
    public string student_Attend = " ";
    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> userData = new List<string>();
        if (Session["UserData"] != null)
        {
            userData = (List<string>)Session["UserData"];
        }
        string sid = Request.QueryString["id"];
        if (sid != null)
        {
            string arn = userData[7];
            string query = "SELECT CONVERT(varchar, Date, 106) as Date, ISPRESENT FROM ATTENDANCE WHERE STUDENTID ='" + arn + "' AND SECTIONID='" + sid + "' ";
            string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int i = 0;
            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Lecture");
            dt.Columns.Add("Date");
            
            dt.Columns.Add("Presence");
            while(reader.Read())
            {
                i++;
                DataRow row = dt.NewRow();
                row["Lecture"] = i;
                row["Date"] = reader["DATE"].ToString();
                Debug.WriteLine(reader["ISPRESENT"].ToString());
                
                if (reader["ISPRESENT"].ToString() == "True") 
                {
                    row["Presence"] = "P";
                }
                else
                {
                    row["Presence"] = "A";
                }
                dt.Rows.Add(row);
            }
            reader.Close();

            myGridView.DataSource = dt;
            

            if (!IsPostBack)
            {
                myGridView.DataBind();
            }

            query = "SELECT (SUM(CAST(isPresent as float))/count(*))*100 as percentage  FROM ATTENDANCE WHERE STUDENTID ='" + arn + "' AND SECTIONID='" + sid + "' ";
            SqlCommand command2 = new SqlCommand(query, connection);
            SqlDataReader reader2 = command2.ExecuteReader();
            
            
            if (reader2.Read()) 
            {
                student_Attend=reader2["percentage"].ToString();
            }

            pgbar.Style.Add("width",student_Attend.ToString()+"%");
        }

    }
    public string attendance_percantage()
    {
        return student_Attend;
    }

}
