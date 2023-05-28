using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;


public partial class student_transcript : System.Web.UI.Page
{
    public double totalGradePoints = 0;
    public double totalCreditHours = 0;
    public List<double> sgp = new List<double> { 0 };
    public List<double> sch = new List<double> { 0 };
    public List<double> sgpa = new List<double> {0};

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userData"] == null)
        {
            Debug.WriteLine("Session object is null.");
        }
        else
        {
            Debug.WriteLine("Not NULL");
            Dictionary<string, double> gradePointValues = new Dictionary<string, double>
            {   
                { "A+", 4.0 },
                { "A",  4.0 },
                { "A-", 3.7 },
                { "B+", 3.3 },
                { "B",  3.0 },
                { "B-", 2.7 },
                { "C+", 2.3 },
                { "C",  2.0 },
                { "C-", 1.7 },
                { "D+", 1.3 },
                { "D",  1.0 },
                { "F",  0.0 }
            };

            List<string> userData = (List<string>)Session["userData"];
            string arn = userData[7];
            string semester = userData[16];
            string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select course.CourseTitle,Course.CreditHours,Course.Semester ,Sections.SectionID,Grade from StudentsEnrollment join Sections on Sections.SectionID=StudentsEnrollment.SectionID join Course on Sections.CourseID= Course.CourseID where Studentid='" + arn + "'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            DataTable[] dts = new DataTable[8];
            for (int i = 0; i < dts.Length; i++)
            {
                dts[i] = new DataTable();

            }
            for (int i = 0; i < 8; i++)
            {
                dts[i].Columns.Add("CourseTitle");
                dts[i].Columns.Add("CreditHours");
                dts[i].Columns.Add("Grade");
            }
            while (reader.Read())
            {
                int sem = Convert.ToInt32(reader["Semester"].ToString());
                string Grade = reader["Grade"].ToString();

                int CreditHours = Convert.ToInt32(reader["CreditHours"].ToString());

                DataRow row = dts[sem - 1].NewRow();

                if (gradePointValues.ContainsKey(Grade))
                {
                    double gradePointValue = gradePointValues[Grade];
                    int creditHours = CreditHours;
                    double courseGradePoints = gradePointValue * creditHours;
                    totalGradePoints += courseGradePoints;
                    totalCreditHours += creditHours;
                    sgp[sem - 1] += courseGradePoints;
                    sch[sem - 1] += creditHours;

                }

                row["CourseTitle"] = reader["CourseTitle"].ToString();
                row["CreditHours"] = reader["CreditHours"].ToString();
                row["Grade"] = reader["Grade"].ToString();

                dts[sem - 1].Rows.Add(row);
            }
            reader.Close();
            GridView1.DataSource = dts[0];
            GridView2.DataSource = dts[1];
            GridView3.DataSource = dts[2];
            GridView4.DataSource = dts[3];
            GridView5.DataSource = dts[4];
            GridView6.DataSource = dts[5];
            GridView7.DataSource = dts[6];
            GridView8.DataSource = dts[7];

            if (!IsPostBack)
            {

                GridView1.DataBind();
                GridView2.DataBind();
                GridView3.DataBind();
                GridView4.DataBind();
                GridView5.DataBind();
                GridView6.DataBind();
                GridView7.DataBind();
                GridView8.DataBind();
                
                if (GridView1.Rows.Count > 0)
                {
                    sem1.InnerText = "Semester 1";
                    GridView1.Caption = "SGPA: "+(sgp[0] / sch[0]).ToString(); 
                }

                if (GridView2.Rows.Count > 0)
                {
                    sem2.InnerText = "Semester 2";
                    GridView2.Caption = "SGPA: " + (sgp[1] / sch[1]).ToString();

                }

                if (GridView3.Rows.Count > 0)
                {
                    sem3.InnerText = "Semester 3";
                    GridView3.Caption = "SGPA: " + (sgp[2] / sch[2]).ToString();

                }

                if (GridView4.Rows.Count > 0)
                {
                    sem4.InnerText = "Semester 4";
                    GridView4.Caption = "SGPA: " + (sgp[3] / sch[3]).ToString();

                }

                if (GridView5.Rows.Count > 0)
                {
                    sem5.InnerText = "Semester 5";
                    GridView5.Caption = "SGPA: " + (sgp[4] / sch[4]).ToString();

                }

                if (GridView6.Rows.Count > 0)
                {
                    sem6.InnerText = "Semester 6";
                    GridView6.Caption = "SGPA: " + (sgp[5] / sch[5]).ToString();

                }

                if (GridView7.Rows.Count > 0)
                {
                    sem7.InnerText = "Semester 7";
                    GridView7.Caption = "SGPA: " + (sgp[6] / sch[6]).ToString();
                        
                }

                if (GridView8.Rows.Count > 0)
                {
                    sem8.InnerText = "Semester 8";
                    GridView8.Caption = "SGPA: " + (sgp[7] / sch[7]).ToString();

                }
            }

        }
    }
}