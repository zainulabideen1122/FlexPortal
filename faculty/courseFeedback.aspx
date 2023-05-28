<%@ Page Language="C#" AutoEventWireup="true" CodeFile="courseFeedback.aspx.cs" Inherits="courseFeedback" %>


<%--<% 
    List<string> userData = new List<string>();
    if (Session["UserData"] != null)
    {
        userData = (List<string>)Session["UserData"];
    }
%>--%>






<% 
    List<string> userData = new List<string>();
    if (Session["UserData"] != null)
    {
        userData = (List<string>)Session["UserData"];
    }
%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous" />
    <title>Instructor Page</title>
    <link href="/StyleSheet.css" rel="stylesheet" />

</head>
<body>

    <nav class="nav">
        <br />
        <a>
            <img src="/Stock/user.png" alt="My Image" width="100" height="100" /></a>
        <br />
        <br />
        <a class="inactive" href="/faculty/Instructor.aspx">Home</a>
        <a class="inactive" href="/faculty/CourseAttendance.aspx">Attendance</a>
        <a class="inactive" href="/faculty/CourseMarks.aspx">Marks</a>
        <a class="active" href="/faculty/courseFeedback.aspx">Course Feedback</a>
    </nav>
    <div class="container">

            <div class="heading">
                <h3>Welcome <%= userData[4] %>👨🏼‍🏫!</h3>
            </div>
            <div class="userData">
                <form id="form2" runat="server">
                    <fieldset id="Courses" style="margin-right: 20%">
                        <fieldset id="allAssignment" style="margin-bottom: 2rem">
                            <legend align="left">
                                <h1>Course Feedback📃</h1>
                            </legend>
                            <asp:GridView ID="showAllAssignment" runat="server" class="gridview" AutoGenerateColumns="FALSE">
                                <Columns>
                                    <asp:BoundField DataField="CourseTitle" HeaderText="CourseTitle" />
                                    <asp:BoundField DataField="Section" HeaderText="Section Name" />
                                    <asp:TemplateField HeaderText="Course Info">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Course_Section" runat="server" Text="Click" NavigateUrl='<%# "feedbackResponses.aspx?SID=" + Eval("sectionID")  %>'></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </fieldset>
                    </fieldset>

                </form>
            </div>
        </div>
</body>
</html>


