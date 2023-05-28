<%@ Page Language="C#" AutoEventWireup="true" CodeFile="transcript.aspx.cs" Inherits="student_transcript" %>

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
</head>
<body>
    
    <nav class="nav">
        <a ><img alt="User Image" src="../Stock/user.png" width="100" height="100"  /></a>
        <br><br>
        <a class="inactive" href="./student.aspx">Home</a>
        <a class="inactive" href="./course_reg.aspx">Course Registrations</a>
        <a class="inactive" href="./course_attendance.aspx">Attendance</a>
        <a class="inactive" href="./course_marks.aspx">Marks</a>
        <a class="active" href="./transcript.aspx">Transcript</a>
        <a class="inactive" href="./feedback_course.aspx">Course Feedback</a>

    </nav>

       
    <div class="box-container">

        <div class="mainPage">
            <div class="heading">
                -
        <h3>Transcript  </h3>
            </div>

            <div class="box">
                <br />
                <form runat="server" id="form1">      
<!-- GridView 1 -->
                    <h4 runat="server" style="margin-left:40%" id="H1">CGPA: <%=totalGradePoints/totalCreditHours %></h4>
    <h3 runat="server" id="sem1"></h3>

<asp:GridView runat="server"  CssClass="table table-condensed table-hover" ID="GridView1" AutoGenerateColumns="false"> 
   
    <Columns>
    <asp:BoundField DataField="CourseTitle" HeaderText="Course Title" />
    <asp:BoundField DataField="CreditHours" HeaderText="Credit Hours" />
    <asp:BoundField DataField="Grade" HeaderText="Grade" />
  </Columns>

</asp:GridView>

                     <h3 runat="server" id="sem2"></h3>
<!-- GridView 2 -->
<asp:GridView runat="server"  CssClass="table table-condensed table-hover" ID="GridView2" AutoGenerateColumns="false"> 
  <Columns>
    <asp:BoundField DataField="CourseTitle" HeaderText="Course Title" />
    <asp:BoundField DataField="CreditHours" HeaderText="Credit Hours" />
    <asp:BoundField DataField="Grade" HeaderText="Grade" />
  </Columns>
</asp:GridView>

<!-- GridView 3 -->
<h3 runat="server" id="sem3"></h3>
<asp:GridView runat="server"  CssClass="table table-condensed table-hover" ID="GridView3" AutoGenerateColumns="false"> 

  <Columns>
    <asp:BoundField DataField="CourseTitle" HeaderText="Course Title" />
    <asp:BoundField DataField="CreditHours" HeaderText="Credit Hours" />
    <asp:BoundField DataField="Grade" HeaderText="Grade" />
  </Columns>
</asp:GridView>

<!-- GridView 4 -->
                                         <h3 runat="server" id="sem4"></h3>

<asp:GridView runat="server"  CssClass="table table-condensed table-hover" ID="GridView4" AutoGenerateColumns="false">  

  <Columns>
    <asp:BoundField DataField="CourseTitle" HeaderText="Course Title" />
    <asp:BoundField DataField="CreditHours" HeaderText="Credit Hours" />
    <asp:BoundField DataField="Grade" HeaderText="Grade" />
  </Columns>
</asp:GridView>

<!-- GridView 5 -->
                                         <h3 runat="server" id="sem5"></h3>

<asp:GridView runat="server"  CssClass="table table-condensed table-hover" ID="GridView5" AutoGenerateColumns="false"> 
    <Columns>
    <asp:BoundField DataField="CourseTitle" HeaderText="Course Title" />
    <asp:BoundField DataField="CreditHours" HeaderText="Credit Hours" />
    <asp:BoundField DataField="Grade" HeaderText="Grade" />
  </Columns>
</asp:GridView>

<!-- GridView 6 -->

                                         <h3 runat="server" id="sem6"></h3>

<asp:GridView runat="server"  CssClass="table table-condensed table-hover" ID="GridView6" AutoGenerateColumns="false">  
  <Columns>
    <asp:BoundField DataField="CourseTitle" HeaderText="Course Title" />
    <asp:BoundField DataField="CreditHours" HeaderText="Credit Hours" />
    <asp:BoundField DataField="Grade" HeaderText="Grade" />
  </Columns>
</asp:GridView>

                                         <h3 runat="server" id="sem7"></h3>

<!-- GridView 7 -->
<asp:GridView runat="server"  CssClass="table table-condensed table-hover" ID="GridView7" AutoGenerateColumns="false">  

  <Columns>
    <asp:BoundField DataField="CourseTitle" HeaderText="Course Title" />
    <asp:BoundField DataField="CreditHours" HeaderText="Credit Hours" />
    <asp:BoundField DataField="Grade" HeaderText="Grade" />
  </Columns>
</asp:GridView>
                                         <h3 runat="server" id="sem8"></h3>

<asp:GridView runat="server"  CssClass="table table-condensed table-hover" ID="GridView8" AutoGenerateColumns="false">  
   
    <Columns>
    <asp:BoundField DataField="CourseTitle" HeaderText="Course Title" />
    <asp:BoundField DataField="CreditHours" HeaderText="Credit Hours" />
    <asp:BoundField DataField="Grade" />
        </Columns>
</asp:GridView>

                    </form>
 
            </div>
        </div>
    </div>
</body>
</html>

