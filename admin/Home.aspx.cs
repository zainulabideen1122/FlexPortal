using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Debug.WriteLine("Home Page load");

    }

    
    protected void logout_clicked(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("/login.aspx");
       

    }

    protected void showFacultyData(object sender, EventArgs e)
    {
        Debug.WriteLine("Manage faculty clicked!");
        Response.Redirect("/login.aspx");
    }

}