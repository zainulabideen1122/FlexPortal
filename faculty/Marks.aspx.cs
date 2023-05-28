using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class Marks : System.Web.UI.Page
{
    public static string maxA = "", maxQ = "", maxM1 = "", maxM2 = "", maxF = "";
    public List<string> TOTALMARKS = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userData"] == null)
        {
            Debug.WriteLine("Session object is null.");
        }
        else
        {

            //Debug.WriteLine("Not NULL");

            List<string> userData = (List<string>)Session["userData"];

            string SID = Request.QueryString["SID"];
            string CID = Request.QueryString["CID"];

            string connectionString = "Data Source=(local)\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            string marksDistributionQuery = "SELECT M.StudentID, M.AssignmentWeight, M.QuizzesWeight, M.Mid1Weight, M.Mid2Weight,M.FinalWeight,M.SectionID FROM StudentEvaluations M inner join Course C on C.CourseID = M.CourseID inner join Sections S on S.SectionID = M.SectionID where C.CourseTitle = '" + CID + "' and S.SectionName = '" + SID + "';";
            SqlCommand marksDistributionCommand = new SqlCommand(marksDistributionQuery, connection);

            connection.Open();
            Debug.WriteLine(marksDistributionQuery);

            SqlDataReader reader = marksDistributionCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("StudentID");
            dt.Columns.Add("AssignmentWeight");
            dt.Columns.Add("QuizzesWeight");
            dt.Columns.Add("Mid1Weight");
            dt.Columns.Add("Mid2Weight");
            dt.Columns.Add("FinalWeight");

            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                row["StudentID"] = reader["StudentID"].ToString();
                row["AssignmentWeight"] = reader["AssignmentWeight"].ToString();
                row["QuizzesWeight"] = reader["QuizzesWeight"].ToString();
                row["Mid1Weight"] = reader["Mid1Weight"].ToString();
                row["Mid2Weight"] = reader["Mid2Weight"].ToString();
                row["FinalWeight"] = reader["FinalWeight"].ToString();
                dt.Rows.Add(row);
                maxA = reader["AssignmentWeight"].ToString();
                maxQ = reader["QuizzesWeight"].ToString();
                maxM1 = reader["Mid1Weight"].ToString();
                maxM2 = reader["Mid2Weight"].ToString();
                maxF = reader["FinalWeight"].ToString();
                Debug.WriteLine(maxA + " " + maxQ + " " + maxM1 + " " + " " + maxM2 + " " + maxF);
                Debug.WriteLine(reader["SectionID"].ToString());
            }

            reader.Close();

            // Bind the DataTable to the GridView
            GridViewMarks.DataSource = dt;
            //GridViewMarks.DataBind();

            string marksDistributionQuery1 = "SELECT M.AssignmentWeight, M.QuizzesWeight, M.Mid1Weight, M.Mid2Weight,M.FinalWeight FROM MarksDistribution M inner join Course C on C.CourseID = M.CourseID inner join Sections S on S.SectionID = M.SectionID  where C.CourseTitle = '" + CID + "' and S.SectionName = '" + SID + "';";
            SqlCommand cm = new SqlCommand(marksDistributionQuery1, connection);

            SqlDataReader reader2 = cm.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("StudentID");
            dt2.Columns.Add("AssignmentWeight");
            dt2.Columns.Add("QuizzesWeight");
            dt2.Columns.Add("Mid1Weight");
            dt2.Columns.Add("Mid2Weight");
            dt2.Columns.Add("FinalWeight");

            while (reader2.Read())
            {
                DataRow row = dt2.NewRow();
                row["AssignmentWeight"] = reader2["AssignmentWeight"].ToString();
                row["QuizzesWeight"] = reader2["QuizzesWeight"].ToString();
                row["Mid1Weight"] = reader2["Mid1Weight"].ToString();
                row["Mid2Weight"] = reader2["Mid2Weight"].ToString();
                row["FinalWeight"] = reader2["FinalWeight"].ToString();
                dt2.Rows.Add(row);
                maxA = reader2["AssignmentWeight"].ToString();
                maxQ = reader2["QuizzesWeight"].ToString();
                maxM1 = reader2["Mid1Weight"].ToString();
                maxM2 = reader2["Mid2Weight"].ToString();
                maxF = reader2["FinalWeight"].ToString();
                Debug.WriteLine(maxA + " " + maxQ + " " + maxM1 + " " + " " + maxM2 + " " + maxF);
            }
            reader2.Close();


            // Bind the DataTable to the GridView
            GridViewEvaluations.DataSource = dt2;
            if (!IsPostBack)
            {
                GridViewEvaluations.DataBind();
                GridViewMarks.DataBind();
            }
            string query3 = "UPDATE StudentEvaluations SET TotalMarks = AssignmentWeight + QuizzesWeight + Mid1Weight + Mid2Weight + FinalWeight ; ";

            SqlCommand cmd1 = new SqlCommand(query3, connection);
            cmd1.ExecuteNonQuery();

            string query2 = "SELECT Student.ARN, " +
               "CASE " +
               "WHEN StudentEvaluations.TotalMarks >= 90 THEN 'A+' " +
               "WHEN StudentEvaluations.TotalMarks >= 86 AND StudentEvaluations.TotalMarks <= 89 THEN 'A' " +
               "WHEN StudentEvaluations.TotalMarks >= 82 AND StudentEvaluations.TotalMarks <= 85 THEN 'A-' " +
               "WHEN StudentEvaluations.TotalMarks >= 78 AND StudentEvaluations.TotalMarks <= 81 THEN 'B+' " +
               "WHEN StudentEvaluations.TotalMarks >= 74 AND StudentEvaluations.TotalMarks <= 77 THEN 'B' " +
               "WHEN StudentEvaluations.TotalMarks >= 70 AND StudentEvaluations.TotalMarks <= 73 THEN 'B-' " +
               "WHEN StudentEvaluations.TotalMarks >= 66 AND StudentEvaluations.TotalMarks <= 69 THEN 'C+' " +
               "WHEN StudentEvaluations.TotalMarks >= 62 AND StudentEvaluations.TotalMarks <= 65 THEN 'C' " +
               "WHEN StudentEvaluations.TotalMarks >= 58 AND StudentEvaluations.TotalMarks <= 61 THEN 'C-' " +
               "WHEN StudentEvaluations.TotalMarks >= 54 AND StudentEvaluations.TotalMarks <= 57 THEN 'D+' " +
               "WHEN StudentEvaluations.TotalMarks >= 50 AND StudentEvaluations.TotalMarks <= 53 THEN 'D' " +
               "ELSE 'F' " +
               "END AS Grade " +
               "FROM Student " +
               "JOIN StudentEvaluations ON Student.ARN = StudentEvaluations.StudentID " +
               "JOIN Sections ON StudentEvaluations.SectionID = Sections.SectionID " +
               "JOIN Course ON Sections.CourseID = Course.CourseID " +
               "WHERE Course.CourseTitle = '" + CID + "' and Sections.SectionName = '" + SID + "';";

            SqlCommand cmd = new SqlCommand(query2, connection);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);

            GridViewStudents.DataSource = dt1;
            GridViewStudents.DataBind();

            connection.Close();
        }

    }
    protected void btnAddRow_Click(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int rowCount = GridViewEvaluations.Rows.Count;
        int sum = 0;

        for (int i = 0; i < rowCount; i++)
        {
            TextBox txtAssignment = (TextBox)GridViewEvaluations.Rows[i].FindControl("TextBox0");
            TextBox txtQuizzes = (TextBox)GridViewEvaluations.Rows[i].FindControl("TextBox1");
            TextBox txtMid1 = (TextBox)GridViewEvaluations.Rows[i].FindControl("TextBox2");
            TextBox txtMid2 = (TextBox)GridViewEvaluations.Rows[i].FindControl("TextBox3");
            TextBox txtFinal = (TextBox)GridViewEvaluations.Rows[i].FindControl("TextBox4");

            Debug.WriteLine("ASSSS " + txtAssignment.Text);

            sum = Convert.ToInt32(txtAssignment.Text) + Convert.ToInt32(txtQuizzes.Text) + Convert.ToInt32(txtMid1.Text) + Convert.ToInt32(txtMid2.Text) + Convert.ToInt32(txtFinal.Text);

            if (sum > 100)
            {
                lblError.Text = "Weightage selected > 100";
                break;
            }
        }

        if (sum <= 100)
        {
            Debug.WriteLine(sum);
            string connectionString = "Data Source=(local)\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            string SID = Request.QueryString["SID"];
            string CID = Request.QueryString["CID"];

            float totalWeight = 0;
            foreach (GridViewRow row in GridViewEvaluations.Rows)
            {
                float weight = float.Parse((row.FindControl("TextBox0") as TextBox).Text)
                    + float.Parse((row.FindControl("TextBox1") as TextBox).Text)
                    + float.Parse((row.FindControl("TextBox2") as TextBox).Text)
                    + float.Parse((row.FindControl("TextBox3") as TextBox).Text)
                    + float.Parse((row.FindControl("TextBox4") as TextBox).Text);
                totalWeight += weight;

                // Update the weight values in the database for this row

                string updateQuery = "UPDATE MarksDistribution SET AssignmentWeight=@AssignmentWeight, QuizzesWeight=@QuizzesWeight, Mid1Weight=@Mid1Weight, Mid2Weight=@Mid2Weight, FinalWeight=@FinalWeight WHERE CourseID IN ( SELECT CourseID FROM Course WHERE CourseTitle = '" + CID + "'  ) AND SectionID IN ( SELECT SectionID FROM Sections WHERE SectionName = '" + SID + "' );";

                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@AssignmentWeight", float.Parse((row.FindControl("TextBox0") as TextBox).Text));
                updateCommand.Parameters.AddWithValue("@QuizzesWeight", float.Parse((row.FindControl("TextBox1") as TextBox).Text));
                updateCommand.Parameters.AddWithValue("@Mid1Weight", float.Parse((row.FindControl("TextBox2") as TextBox).Text));
                updateCommand.Parameters.AddWithValue("@Mid2Weight", float.Parse((row.FindControl("TextBox3") as TextBox).Text));
                updateCommand.Parameters.AddWithValue("@FinalWeight", float.Parse((row.FindControl("TextBox4") as TextBox).Text));
                connection.Open();
                updateCommand.ExecuteNonQuery();
                connection.Close();
            }

            lblError.Text = "Data saved successfully.";
            Response.Redirect(Request.RawUrl);
        }
    }

    protected void btnSave_Click1(object sender, EventArgs e)
    {
        int rowCount = GridViewMarks.Rows.Count;

        string connectionString = "Data Source=(local)\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        string SID = Request.QueryString["SID"];
        string CID = Request.QueryString["CID"];

        foreach (GridViewRow row in GridViewMarks.Rows)
        {

            // Update the weight values in the database for this row

            string updateQuery = "UPDATE StudentEvaluations SET AssignmentWeight=@AssignmentWeight, QuizzesWeight=@QuizzesWeight, Mid1Weight=@Mid1Weight, Mid2Weight=@Mid2Weight, FinalWeight=@FinalWeight FROM StudentEvaluations SE JOIN Course C ON SE.CourseID = C.CourseID JOIN Sections S ON SE.SectionID = S.SectionID WHERE C.CourseTitle = '" + CID + "'  AND S.SectionName = '" + SID + "' and SE.StudentID = @SD;";
            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
            updateCommand.Parameters.AddWithValue("@SD", float.Parse((row.FindControl("sid") as TextBox).Text));
            updateCommand.Parameters.AddWithValue("@AssignmentWeight", float.Parse((row.FindControl("txtAssignment") as TextBox).Text));
            updateCommand.Parameters.AddWithValue("@QuizzesWeight", float.Parse((row.FindControl("txtQuizMarks") as TextBox).Text));
            updateCommand.Parameters.AddWithValue("@Mid1Weight", float.Parse((row.FindControl("txtMid1Marks") as TextBox).Text));
            updateCommand.Parameters.AddWithValue("@Mid2Weight", float.Parse((row.FindControl("txtMid2Marks") as TextBox).Text));
            updateCommand.Parameters.AddWithValue("@FinalWeight", float.Parse((row.FindControl("txtFinalExamMarks") as TextBox).Text));
            Debug.WriteLine(updateQuery);

            connection.Open();

            updateCommand.ExecuteNonQuery();

            connection.Close();
        }

        lblError.Text = "Data saved successfully.";
        Response.Redirect(Request.RawUrl);
    }
    public string calculate_total(string a, string b, string c, string d, string e)
    {
        return (float.Parse(a) + float.Parse(b) + float.Parse(c) + float.Parse(d) + float.Parse(e)).ToString();
    }

}