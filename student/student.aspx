<%@ Page Language="C#" AutoEventWireup="true" CodeFile="student.aspx.cs" inherits="student"%>


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
    <style>
        #btnLogOut
        {
            float:right;
            margin-top:-2rem;
            border:none;
            background-color:#83783ac1;
            padding:8px 20px;
            color:white;
            font-weight:bold;
            cursor:pointer;
        }
    </style>
</head>
<body>
    
    <nav class="nav">
        <a ><img alt="User Image" src="../Stock/user.png" width="100" height="100"  /></a>
        <br><br>
        <a class="active" href="./student.aspx">Home</a>
        <a class="inactive" href="./course_reg.aspx">Course Registrations</a>
        <a class="inactive" href="./course_attendance.aspx">Attendance</a>
        <a class="inactive" href="./course_marks.aspx">Marks</a>
        <a class="inactive" href="./transcript.aspx">Transcript</a>
        <a class="inactive" href="./feedback_course.aspx">Course Feedback</a>

    </nav>

    <div class="container">

       <div class="mainPage">
    <div class="heading">-
        <h3>Welcome <%= userData[4] %>! <span> <Form runat="server"> <asp:Button runat="server" Text="Logout" ID="btnLogOut" CssClass="btn" onClick="logout_clicked"></asp:Button></Form></span> </h3>
    </div>
    <div class="userData">
         <h1 class="bioHeading">Personal Information</h1>
  <div class="bio">
    <div class="row align-items-start">
    <div class="col"><p>Email: <span><%= userData[3] %></span></p></div>
    <div class="col"> <p>CNIC: <span class="bioValues"><%= userData[1] %></span></p></div>
  </div>
  <div class="row align-items-start">
    <div class="col"><p>First Name: <span class="bioValues"><%= userData[4] %></span></p></div>
    <div class="col"><p>Last Name: <span class="bioValues"><%= userData[5] %></span></p></div>
  </div>
    <div class="row align-items-start">
    <div class="col">    <p>Gender: <span class="bioValues"><%= userData[6] %></span></p>  </div>
    <div class="col">   <p>ARN: <span class="bioValues"><%= userData[7] %></span></p></div>
  </div>    
  <div class="row align-items-start">
    <div class="col"> <p>Roll No: <span class="bioValues"><%= userData[8] %></span></p>  </div>
    <div class="col"><p>Batch No: <span class="bioValues"><%= userData[9] %></span> </p></div>
  </div>
  <div class="row align-items-start">
    <div class="col">    <p>Country: <span class="bioValues"><%= userData[10] %></span> </p></div>
    <div class="col"> <p>Blood Group: <span class="bioValues"><%= userData[11] %></span> </p></div>     
  </div>
  <div class="row align-items-start">
    <div class="col"><p>Phone No: <span class="bioValues"><%= userData[12] %></span>    </p></div>
    <div class="col"><p>City: <span class="bioValues"><%= userData[13] %></span> </p></div>
  </div>
 
  <div class="row align-items-start">
    <div class="col"><p>Address: <span class="bioValues"><%= userData[14] %></span> </p></div>
    <div class="col"><p>Father CNIC: <span class="bioValues"><%= userData[15] %></span> </p></div>
  </div>
     
            
        </div>
    </div>
    </div>
    </div>
</body>
</html>
