using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class feedbackResponses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sectionID = Request.QueryString["SID"];

        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        string query = "SELECT \r\n  COUNT(CASE WHEN Option1 = 1 THEN 1 ELSE NULL END) AS Option1_Count,\r\n  COUNT(CASE WHEN Option2 = 1 THEN 1 ELSE NULL END) AS Option2_Count,\r\n  COUNT(CASE WHEN Option3 = 1 THEN 1 ELSE NULL END) AS Option3_Count,\r\n  COUNT(CASE WHEN Option4 = 1 THEN 1 ELSE NULL END) AS Option4_Count,\r\n  COUNT(CASE WHEN Option5 = 1 THEN 1 ELSE NULL END) AS Option5_Count,\r\n  COUNT(CASE WHEN Option6 = 1 THEN 1 ELSE NULL END) AS Option6_Count,\r\n  COUNT(CASE WHEN Option7 = 1 THEN 1 ELSE NULL END) AS Option7_Count,\r\n  COUNT(CASE WHEN Option8 = 1 THEN 1 ELSE NULL END) AS Option8_Count,\r\n  COUNT(CASE WHEN Option9 = 1 THEN 1 ELSE NULL END) AS Option9_Count,\r\n  COUNT(CASE WHEN Option10 = 1 THEN 1 ELSE NULL END) AS Option10_Count,\r\n  COUNT(CASE WHEN Option11 = 1 THEN 1 ELSE NULL END) AS Option11_Count,\r\n  COUNT(CASE WHEN Option12 = 1 THEN 1 ELSE NULL END) AS Option12_Count,\r\n  COUNT(CASE WHEN Option13 = 1 THEN 1 ELSE NULL END) AS Option13_Count,\r\n  COUNT(CASE WHEN Option14 = 1 THEN 1 ELSE NULL END) AS Option14_Count,\r\n  COUNT(CASE WHEN Option15 = 1 THEN 1 ELSE NULL END) AS Option15_Count,\r\n  COUNT(CASE WHEN Option16 = 1 THEN 1 ELSE NULL END) AS Option16_Count,\r\n  COUNT(CASE WHEN Option17 = 1 THEN 1 ELSE NULL END) AS Option17_Count,\r\n  COUNT(CASE WHEN Option18 = 1 THEN 1 ELSE NULL END) AS Option18_Count,\r\n  COUNT(CASE WHEN Option19 = 1 THEN 1 ELSE NULL END) AS Option19_Count,\r\n  COUNT(CASE WHEN Option1 = 2 THEN 1 ELSE NULL END) AS Option1_Count_2,\r\n  COUNT(CASE WHEN Option2 = 2 THEN 1 ELSE NULL END) AS Option2_Count_2,\r\n  COUNT(CASE WHEN Option3 = 2 THEN 1 ELSE NULL END) AS Option3_Count_2,\r\n  COUNT(CASE WHEN Option4 = 2 THEN 1 ELSE NULL END) AS Option4_Count_2,\r\n  COUNT(CASE WHEN Option5 = 2 THEN 1 ELSE NULL END) AS Option5_Count_2,\r\n  COUNT(CASE WHEN Option6 = 2 THEN 1 ELSE NULL END) AS Option6_Count_2,\r\n  COUNT(CASE WHEN Option7 = 2 THEN 1 ELSE NULL END) AS Option7_Count_2,\r\n  COUNT(CASE WHEN Option8 = 2 THEN 1 ELSE NULL END) AS Option8_Count_2,\r\n  COUNT(CASE WHEN Option9 = 2 THEN 1 ELSE NULL END) AS Option9_Count_2,\r\n  COUNT(CASE WHEN Option10 = 2 THEN 1 ELSE NULL END) AS Option10_Count_2,\r\nCOUNT(CASE WHEN Option11 = 2 THEN 1 ELSE NULL END) AS Option11_Count_2,\r\nCOUNT(CASE WHEN Option12 = 2 THEN 1 ELSE NULL END) AS Option12_Count_2,\r\nCOUNT(CASE WHEN Option13 = 2 THEN 1 ELSE NULL END) AS Option13_Count_2,\r\nCOUNT(CASE WHEN Option14 = 2 THEN 1 ELSE NULL END) AS Option14_Count_2,\r\nCOUNT(CASE WHEN Option15 = 2 THEN 1 ELSE NULL END) AS Option15_Count_2,\r\nCOUNT(CASE WHEN Option16 = 2 THEN 1 ELSE NULL END) AS Option16_Count_2,\r\nCOUNT(CASE WHEN Option17 = 2 THEN 1 ELSE NULL END) AS Option17_Count_2,\r\nCOUNT(CASE WHEN Option18 = 2 THEN 1 ELSE NULL END) AS Option18_Count_2,\r\nCOUNT(CASE WHEN Option19 = 2 THEN 1 ELSE NULL END) AS Option19_Count_2,\r\nCOUNT(CASE WHEN Option1 = 3 THEN 1 ELSE NULL END) AS Option1_Count_3,\r\nCOUNT(CASE WHEN Option2 = 3 THEN 1 ELSE NULL END) AS Option2_Count_3,\r\nCOUNT(CASE WHEN Option3 = 3 THEN 1 ELSE NULL END) AS Option3_Count_3,\r\nCOUNT(CASE WHEN Option4 = 3 THEN 1 ELSE NULL END) AS Option4_Count_3,\r\nCOUNT(CASE WHEN Option5 = 3 THEN 1 ELSE NULL END) AS Option5_Count_3,\r\nCOUNT(CASE WHEN Option6 = 3 THEN 1 ELSE NULL END) AS Option6_Count_3,\r\nCOUNT(CASE WHEN Option7 = 3 THEN 1 ELSE NULL END) AS Option7_Count_3,\r\nCOUNT(CASE WHEN Option8 = 3 THEN 1 ELSE NULL END) AS Option8_Count_3,\r\nCOUNT(CASE WHEN Option9 = 3 THEN 1 ELSE NULL END) AS Option9_Count_3,\r\nCOUNT(CASE WHEN Option10 = 3 THEN 1 ELSE NULL END) AS Option10_Count_3,\r\nCOUNT(CASE WHEN Option11 = 3 THEN 1 ELSE NULL END) AS Option11_Count_3,\r\nCOUNT(CASE WHEN Option12 = 3 THEN 1 ELSE NULL END) AS Option12_Count_3,\r\nCOUNT(CASE WHEN Option13 = 3 THEN 1 ELSE NULL END) AS Option13_Count_3,\r\nCOUNT(CASE WHEN Option14 = 3 THEN 1 ELSE NULL END) AS Option14_Count_3,\r\nCOUNT(CASE WHEN Option15 = 3 THEN 1 ELSE NULL END) AS Option15_Count_3,\r\nCOUNT(CASE WHEN Option16 = 3 THEN 1 ELSE NULL END) AS Option16_Count_3,\r\nCOUNT(CASE WHEN Option17 = 3 THEN 1 ELSE NULL END) AS Option17_Count_3,\r\nCOUNT(CASE WHEN Option18 = 3 THEN 1 ELSE NULL END) AS Option18_Count_3,\r\nCOUNT(CASE WHEN Option19 = 3 THEN 1 ELSE NULL END) AS Option19_Count_3,\r\nCOUNT(CASE WHEN Option1 = 4 THEN 1 ELSE NULL END) AS Option1_Count_4,\r\nCOUNT(CASE WHEN Option2 = 4 THEN 1 ELSE NULL END) AS Option2_Count_4,\r\nCOUNT(CASE WHEN Option3 = 4 THEN 1 ELSE NULL END) AS Option3_Count_4,\r\nCOUNT(CASE WHEN Option4 = 4 THEN 1 ELSE NULL END) AS Option4_Count_4,\r\nCOUNT(CASE WHEN Option5 = 4 THEN 1 ELSE NULL END) AS Option5_Count_4,\r\nCOUNT(CASE WHEN Option6 = 4 THEN 1 ELSE NULL END) AS Option6_Count_4,\r\nCOUNT(CASE WHEN Option7 = 4 THEN 1 ELSE NULL END) AS Option7_Count_4,\r\nCOUNT(CASE WHEN Option8 = 4 THEN 1 ELSE NULL END) AS Option8_Count_4,\r\nCOUNT(CASE WHEN Option9 = 4 THEN 1 ELSE NULL END) AS Option9_Count_4,\r\nCOUNT(CASE WHEN Option10 = 4 THEN 1 ELSE NULL END) AS Option10_Count_4,\r\nCOUNT(CASE WHEN Option11 = 4 THEN 1 ELSE NULL END) AS Option11_Count_4,\r\nCOUNT(CASE WHEN Option12 = 4 THEN 1 ELSE NULL END) AS Option12_Count_4,\r\nCOUNT(CASE WHEN Option13 = 4 THEN 1 ELSE NULL END) AS Option13_Count_4,\r\nCOUNT(CASE WHEN Option14 = 4 THEN 1 ELSE NULL END) AS Option14_Count_4,\r\nCOUNT(CASE WHEN Option15 = 4 THEN 1 ELSE NULL END) AS Option15_Count_4,\r\nCOUNT(CASE WHEN Option16 = 4 THEN 1 ELSE NULL END) AS Option16_Count_4,\r\nCOUNT(CASE WHEN Option17 = 4 THEN 1 ELSE NULL END) AS Option17_Count_4,\r\nCOUNT(CASE WHEN Option18 = 4 THEN 1 ELSE NULL END) AS Option18_Count_4,\r\nCOUNT(CASE WHEN Option19 = 4 THEN 1 ELSE NULL END) AS Option19_Count_4,\r\nCOUNT(CASE WHEN Option1 = 5 THEN 1 ELSE NULL END) AS Option1_Count_5,\r\nCOUNT(CASE WHEN Option2 = 5 THEN 1 ELSE NULL END) AS Option2_Count_5,\r\nCOUNT(CASE WHEN Option3 = 5 THEN 1 ELSE NULL END) AS Option3_Count_5,\r\nCOUNT(CASE WHEN Option4 = 5 THEN 1 ELSE NULL END) AS Option4_Count_5,\r\nCOUNT(CASE WHEN Option5 = 5 THEN 1 ELSE NULL END) AS Option5_Count_5,\r\nCOUNT(CASE WHEN Option6 = 5 THEN 1 ELSE NULL END) AS Option6_Count_5,\r\nCOUNT(CASE WHEN Option7 = 5 THEN 1 ELSE NULL END) AS Option7_Count_5,\r\nCOUNT(CASE WHEN Option8 = 5 THEN 1 ELSE NULL END) AS Option8_Count_5,\r\nCOUNT(CASE WHEN Option9 = 5 THEN 1 ELSE NULL END) AS Option9_Count_5,\r\nCOUNT(CASE WHEN Option10 = 5 THEN 1 ELSE NULL END) AS Option10_Count_5,\r\nCOUNT(CASE WHEN Option11 = 5 THEN 1 ELSE NULL END) AS Option11_Count_5,\r\nCOUNT(CASE WHEN Option12 = 5 THEN 1 ELSE NULL END) AS Option12_Count_5,\r\nCOUNT(CASE WHEN Option13 = 5 THEN 1 ELSE NULL END) AS Option13_Count_5,\r\nCOUNT(CASE WHEN Option14 = 5 THEN 1 ELSE NULL END) AS Option14_Count_5,\r\nCOUNT(CASE WHEN Option15 = 5 THEN 1 ELSE NULL END) AS Option15_Count_5,\r\nCOUNT(CASE WHEN Option16 = 5 THEN 1 ELSE NULL END) AS Option16_Count_5,\r\nCOUNT(CASE WHEN Option17 = 5 THEN 1 ELSE NULL END) AS Option17_Count_5,\r\nCOUNT(CASE WHEN Option18 = 5 THEN 1 ELSE NULL END) AS Option18_Count_5,\r\nCOUNT(CASE WHEN Option19 = 5 THEN 1 ELSE NULL END) AS Option19_Count_5\r\nFROM Feedback\r\nwhere section_ID=@sid\r\nGroup by SECTION_ID";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@sid", sectionID);
        connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            
            o1c1.Text = reader["Option1_Count"].ToString() + " chooses";
            o1c2.Text = reader["Option1_Count_2"].ToString() + " chooses";
            o1c3.Text = reader["Option1_Count_3"].ToString() + " chooses";
            o1c4.Text = reader["Option1_Count_4"].ToString() + " chooses";
            o1c5.Text = reader["Option1_Count_5"].ToString() + " chooses";
            o2c1.Text = reader["Option2_Count"].ToString() + " chooses";
            o2c2.Text = reader["Option2_Count_2"].ToString() + " chooses";
            o2c3.Text = reader["Option2_Count_3"].ToString() + " chooses";
            o2c4.Text = reader["Option2_Count_4"].ToString() + " chooses";
            o2c5.Text = reader["Option2_Count_5"].ToString() + " chooses";
            o3c1.Text = reader["Option3_Count"].ToString() + " chooses";
            o3c2.Text = reader["Option3_Count_2"].ToString() + " chooses";
            o3c3.Text = reader["Option3_Count_3"].ToString() + " chooses";
            o3c4.Text = reader["Option3_Count_4"].ToString() + " chooses";
            o3c5.Text = reader["Option3_Count_5"].ToString() + " chooses";
            o4c1.Text = reader["Option4_Count"].ToString() + " chooses";
            o4c2.Text = reader["Option4_Count_2"].ToString() + " chooses";
            o4c3.Text = reader["Option4_Count_3"].ToString() + " chooses";
            o4c4.Text = reader["Option4_Count_4"].ToString() + " chooses";
            o4c5.Text = reader["Option4_Count_5"].ToString() + " chooses";
            o5c1.Text = reader["Option5_Count"].ToString() + " chooses";
            o5c2.Text = reader["Option5_Count_2"].ToString() + " chooses";
            o5c3.Text = reader["Option5_Count_3"].ToString() + " chooses";
            o5c4.Text = reader["Option5_Count_4"].ToString() + " chooses";
            o5c5.Text = reader["Option5_Count_5"].ToString() + " chooses";
            o6c1.Text = reader["Option6_Count"].ToString() + " chooses";
            o6c2.Text = reader["Option6_Count_2"].ToString() + " chooses";
            o6c3.Text = reader["Option6_Count_3"].ToString() + " chooses";
            o6c4.Text = reader["Option6_Count_4"].ToString() + " chooses";
            o6c5.Text = reader["Option6_Count_5"].ToString() + " chooses";
            o7c1.Text = reader["Option7_Count"].ToString() + " chooses";
            o7c2.Text = reader["Option7_Count_2"].ToString() + " chooses";
            o7c3.Text = reader["Option7_Count_3"].ToString() + " chooses";
            o7c4.Text = reader["Option7_Count_4"].ToString() + " chooses";
            o7c5.Text = reader["Option7_Count_5"].ToString() + " chooses";
            o8c1.Text = reader["Option8_Count"].ToString() + " chooses";
            o8c2.Text = reader["Option8_Count_2"].ToString() + " chooses";
            o8c3.Text = reader["Option8_Count_3"].ToString() + " chooses";
            o8c4.Text = reader["Option8_Count_4"].ToString() + " chooses";
            o8c5.Text = reader["Option8_Count_5"].ToString() + " chooses";
            o9c1.Text = reader["Option9_Count"].ToString() + " chooses";
            o9c2.Text = reader["Option9_Count_2"].ToString() + " chooses";
            o9c3.Text = reader["Option9_Count_3"].ToString() + " chooses";
            o9c4.Text = reader["Option9_Count_4"].ToString() + " chooses";
            o9c5.Text = reader["Option9_Count_5"].ToString() + " chooses";
            o10c1.Text = reader["Option10_Count"].ToString() + " chooses";
            o10c2.Text = reader["Option10_Count_2"].ToString() + " chooses";
            o10c3.Text = reader["Option10_Count_3"].ToString() + " chooses";
            o10c4.Text = reader["Option10_Count_4"].ToString() + " chooses";
            o10c5.Text = reader["Option10_Count_5"].ToString() + " chooses";
            o11c1.Text = reader["Option11_Count"].ToString() + " chooses";
            o11c2.Text = reader["Option11_Count_2"].ToString() + " chooses";
            o11c3.Text = reader["Option11_Count_3"].ToString() + " chooses";
            o11c4.Text = reader["Option11_Count_4"].ToString() + " chooses";
            o11c5.Text = reader["Option11_Count_5"].ToString() + " chooses";
            o12c1.Text = reader["Option12_Count"].ToString() + " chooses";
            o12c2.Text = reader["Option12_Count_2"].ToString() + " chooses";
            o12c3.Text = reader["Option12_Count_3"].ToString() + " chooses";
            o12c4.Text = reader["Option12_Count_4"].ToString() + " chooses";
            o12c5.Text = reader["Option12_Count_5"].ToString() + " chooses";
            o13c1.Text = reader["Option13_Count"].ToString() + " chooses";
            o13c2.Text = reader["Option13_Count_2"].ToString() + " chooses";
            o13c3.Text = reader["Option13_Count_3"].ToString() + " chooses";
            o13c4.Text = reader["Option13_Count_4"].ToString() + " chooses";
            o13c5.Text = reader["Option13_Count_5"].ToString() + " chooses";
            o14c1.Text = reader["Option14_Count"].ToString() + " chooses";
            o14c2.Text = reader["Option14_Count_2"].ToString() + " chooses";
            o14c3.Text = reader["Option14_Count_3"].ToString() + " chooses";
            o14c4.Text = reader["Option14_Count_4"].ToString() + " chooses";
            o14c5.Text = reader["Option14_Count_5"].ToString() + " chooses";
            o15c1.Text = reader["Option15_Count"].ToString() + " chooses";
            o15c2.Text = reader["Option15_Count_2"].ToString() + " chooses";
            o15c3.Text = reader["Option15_Count_3"].ToString() + " chooses";
            o15c4.Text = reader["Option15_Count_4"].ToString() + " chooses";
            o15c5.Text = reader["Option15_Count_5"].ToString() + " chooses";
            o16c1.Text = reader["Option16_Count"].ToString() + " chooses";
            o16c2.Text = reader["Option16_Count_2"].ToString() + " chooses";
            o16c3.Text = reader["Option16_Count_3"].ToString() + " chooses";
            o16c4.Text = reader["Option16_Count_4"].ToString() + " chooses";
            o16c5.Text = reader["Option16_Count_5"].ToString() + " chooses";
            o17c1.Text = reader["Option17_Count"].ToString() + " chooses";
            o17c2.Text = reader["Option17_Count_2"].ToString() + " chooses";
            o17c3.Text = reader["Option17_Count_3"].ToString() + " chooses";
            o17c4.Text = reader["Option17_Count_4"].ToString() + " chooses";
            o17c5.Text = reader["Option17_Count_5"].ToString() + " chooses";
            o18c1.Text = reader["Option18_Count"].ToString() + " chooses";
            o18c2.Text = reader["Option18_Count_2"].ToString() + " chooses";
            o18c3.Text = reader["Option18_Count_3"].ToString() + " chooses";
            o18c4.Text = reader["Option18_Count_4"].ToString() + " chooses";
            o18c5.Text = reader["Option18_Count_5"].ToString() + " chooses";
            o19c1.Text = reader["Option19_Count"].ToString() + " chooses";
            o19c2.Text = reader["Option19_Count_2"].ToString() + " chooses";
            o19c3.Text = reader["Option19_Count_3"].ToString() + " chooses";
            o19c4.Text = reader["Option19_Count_4"].ToString() + " chooses";
            o19c5.Text = reader["Option19_Count_5"].ToString() + " chooses";
        }

        reader.Close();

        query = "select Comments from Feedback where SECTION_ID=@sid";
        SqlCommand command1 = new SqlCommand(query, connection);
        command1.Parameters.AddWithValue("@sid", sectionID);

        SqlDataAdapter adapter = new SqlDataAdapter(command1);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        showComments.DataSource = dt;
        showComments.DataBind();
        connection.Close();
    }
}