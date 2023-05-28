<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>


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
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
    

    <title>Admin|</title>
    <link href="/admin/admin.css" rel="stylesheet" />

    <style>
        .nav {
        display: flex;
        flex-direction: column;
        text-align: center;
        width: 12%;
        height: 100vh;
        position: fixed;
        background: #122143;
        overflow: hidden;
    }

    .nav a {
            margin: 10px 0;
            cursor: pointer;
            padding: 20px 0;
            color: white;
            text-decoration: none;
        }

    .navi i {
        margin-right: 15px;
        color: #5584ff;
    }
    
    .active {
            background: #122143 none repeat scroll 0 0;
            border-left: 5px solid #5584ff;
            display: block;
            padding-left: 15px;
        }

    .nav a.inactive:hover {
        background: #122143 none repeat scroll 0 0;
        border-left: 5px solid #5584ff;
        display: block;
        padding-left: 15px;
    }

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
        <a><img alt="User Image" src="../Stock/user.png" width="50" height="50" style="margin-bottom:-2rem" /></a>
        <br><br>
        <a class="active" href="/admin/Home.aspx">Home</a>
        <a class="inactive" href="/admin/courseReg.aspx">Course Registrations</a>
        <a class="inactive" href="/admin/manageFaculty.aspx">Manage Faculty</a>
        <a class="inactive" href="/admin/manageStudent.aspx">Manage Students</a>
        <a class="inactive" href="/admin/viewCourse.aspx">Manage Sections</a>
        <a class="inactive" href="/admin/approveCourses.aspx">Approve Courses</a>
        <a class="inactive" href="/showAudit.aspx">Show audit trails (activity)</a>


    </nav>

   <div class="mainPage">
    <div class="heading">
        <h3>Wellcome <%= userData[4] %>!  <span> <Form runat="server"> <asp:Button runat="server" Text="Logout" ID="btnLogOut" CssClass="btn" onClick="logout_clicked"></asp:Button></Form></span> </h3>
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
              </div>  
            
         </div>
       </div>




</div>


</body>
</html>



