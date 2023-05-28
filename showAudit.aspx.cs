using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class showAudit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = "Data Source=ZAIN\\SQLEXPRESS01;Initial Catalog=FlexDatabase;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        string query = "select * from AuditTable";
        SqlDataAdapter sda = new SqlDataAdapter(query, connection);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        showAudits.DataSource = dt;
        showAudits.DataBind();
    }
}