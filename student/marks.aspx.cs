using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student_marks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userData"] == null)
        {

            Debug.WriteLine("Session object is null.");
        }
        else
        {
            string sid = Request.QueryString["id"];
            Debug.WriteLine("Not NULL");

            List<string> userData = (List<string>)Session["userData"];

            string arn = userData[7];
            string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select* from StudentEvaluations where SectionID='" + sid + "' and StudentID='" + arn + "'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@arn", arn);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();

            dt.Columns.Add("TYPE");
            dt.Columns.Add("AssignmentWeight");
            dt.Columns.Add("QuizzesWeight");
            dt.Columns.Add("Mid1Weight");
            dt.Columns.Add("Mid2Weight");
            dt.Columns.Add("FinalWeight");
            dt.Columns.Add("Total");
            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                double aw = Convert.ToDouble(reader["AssignmentWeight"].ToString());
                double aq = Convert.ToDouble(reader["QuizzesWeight"].ToString());
                double am1 = Convert.ToDouble(reader["Mid1Weight"].ToString());
                double am2 = Convert.ToDouble(reader["Mid2Weight"].ToString());
                double final = Convert.ToDouble(reader["FinalWeight"].ToString());
                row["AssignmentWeight"] = reader["AssignmentWeight"].ToString();
                row["QuizzesWeight"] = reader["QuizzesWeight"].ToString();
                row["Mid1Weight"] = reader["Mid1Weight"].ToString();
                row["Mid2Weight"] = reader["Mid2Weight"].ToString();
                row["FinalWeight"] = reader["FinalWeight"].ToString();
                row["Total"] = (aw + aq + am1 + am2 + final).ToString();
                row["TYPE"] = "Obtained Marks";
                dt.Rows.Add(row);
            }
            reader.Close();

            query = "select * from MarksDistribution where SectionID='"+sid+"'";
            SqlCommand command2 = new SqlCommand(query, connection);

            SqlDataReader reader2 = command2.ExecuteReader();

            while(reader2.Read())
            {
                DataRow row = dt.NewRow();

                double aw = Convert.ToDouble(reader2["AssignmentWeight"].ToString());
                double aq = Convert.ToDouble(reader2["QuizzesWeight"].ToString());
                double am1 = Convert.ToDouble(reader2["Mid1Weight"].ToString());
                double am2 = Convert.ToDouble(reader2["Mid2Weight"].ToString());
                double final = Convert.ToDouble(reader2["FinalWeight"].ToString());
                row["AssignmentWeight"] = reader2["AssignmentWeight"].ToString();
                row["QuizzesWeight"] = reader2["QuizzesWeight"].ToString();
                row["Mid1Weight"] = reader2["Mid1Weight"].ToString();
                row["Mid2Weight"] = reader2["Mid2Weight"].ToString();
                row["FinalWeight"] = reader2["FinalWeight"].ToString();
                row["Total"] = (aw + aq + am1 + am2 + final).ToString();
                row["TYPE"] = "Total";
                dt.Rows.Add(row);
            }
            reader2.Close();


            myGridView.DataSource = dt;
            myGridView.DataBind();
            connection.Close();

        }
    }
}
