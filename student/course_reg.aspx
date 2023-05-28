<%@ Page Language="C#" AutoEventWireup="true" CodeFile="course_reg.aspx.cs" Inherits="student_course_reg" %>

<% 
    List<string> userData = new List<string>();
    if (Session["UserData"] != null)
    {
        userData = (List<string>)Session["UserData"];
    }
%>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
    
    <title>Student</title>
    <link href="Student.css" rel="stylesheet" />    
<style>.my-dropdown {
  background-color: #fff;
  color: #333;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-size: 16px;
  font-family: Arial, sans-serif;
  width: 100px;
  box-sizing: border-box;
}

.my-dropdown option {
  background-color: #fff;
  color: #333;
  padding: 5px;
  font-size: 16px;
  font-family: Arial, sans-serif;
}</style>
</head>
    
<body>
    
    <nav class="nav">
        <a ><img alt="User Image" src="../Stock/user.png" width="100" height="100"  /></a>
        <br><br>
        <a class="inactive" href="./student.aspx">Home</a>
        <a class="active" href="./course_reg.aspx">Course Registrations</a>
        <a class="inactive" href="./course_attendance.aspx">Attendance</a>
        <a class="inactive" href="./course_marks.aspx">Marks</a>
        <a class="inactive" href="./transcript.aspx">Transcript</a>
        <a class="inactive" href="./feedback_course.aspx">Course Feedback</a>

    </nav>
    
    <div class="box-container">

        <div class="mainPage">
            <div class="heading">
                -
     <h3>Course Registeration</h3>
            </div>

            <div class="box">
                <br />
                <span ><b>Credit Hours: </b><%=total_cr_registered%></span> <span style="margin-left:30px;"><b>Allowed:</b> 18</span>  
                <form runat="server" id="form1">

                <asp:Button ID="registerCourse"  style="margin-left:35vw;" runat="server"  Text="RegisterCourses" OnClick="registerCourse_Click" CausesValidation="false"/>
 
                
                <br />
                <br />

                    <asp:GridView CssClass="table table-condensed table-hover" runat="server" ID="myGridView" AutoGenerateColumns="false"  OnRowCommand="myGridView_RowCommand" OnRowCreated="myGridView_RowCreated" OnRowDataBound="myGridView_RowDataBound">
                        
                        <Columns>
                            <asp:BoundField DataField="courseCode" HeaderText="Code" />
                            <asp:BoundField DataField="courseTitle" HeaderText="Title" />
                            <asp:BoundField DataField="CourseType" HeaderText="Type" />
                            <asp:BoundField DataField="CreditHours" HeaderText="Hours" />

                            <asp:TemplateField HeaderText=" ">


                                <ItemTemplate>
                                    <asp:DropDownList CssClass="my-dropdown" ID="ddlSections" runat="server"></asp:DropDownList>
                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText=" ">


                                <ItemTemplate>

                                    <asp:Button ID="Button1" runat="server"
                                        CommandName="RegCourse" Text="Register" CausesValidation="false" />

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" ">

                                <ItemTemplate>

                                    <asp:Button ID="Button2" runat="server"
                                        CommandName="Drop" Text="Drop" CausesValidation="false" />

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </form>

            </div>
        </div>
    </div>
        
</body>
</html>
