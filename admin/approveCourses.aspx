<%@ Page Language="C#" AutoEventWireup="true" CodeFile="approveCourses.aspx.cs" Inherits="pages_approveCourses" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        .table-condensed tr th {
            border: 0px solid mediumpurple;
            color: white;
            background-color: mediumpurple;
            padding:5px;
        }
        .actionBtns
        {
                border:none;
                background-color:darkred;
                padding:10px 20px;
                color:white;
                font-weight:bold;
                cursor:pointer;
         }
        .actionBtns:hover
        {
            background-color:#8b0000af;
        }
        .flexLogo
        {
            width:10%;
            margin:1rem 0
        }

    .table-condensed, .table-condensed tr td {
        border: 0px solid #000;padding:10px 0 ;
    }

    tr:nth-child(even) {
        background: #f8f7ff
    }

    tr:nth-child(odd) {
        background: #fff;
    }
    #ApproveSections{
        display:flex;
        align-items:center;
        justify-content:center;
        text-align:center;
        width:80%;
        position:relative;
        left:10%;
    }
    </style>

</head>
<body>


    <center>
        <a href="/admin/Home.aspx">
            <img class="flexLogo" src="https://flexstudent.nu.edu.pk/Assets/demo/demo3/media/img/logo/flex-logo-blue.png" />
        </a>
    </center>


    <form id="form1" runat="server">
        
        <fieldset id="ApproveSections" style="margin-bottom:2rem">
                <legend align="left"><h1>Approve Sections</h1></legend>
                 <asp:GridView ID="viewCoursesData" runat="server" AutoGenerateColumns="false" CssClass="table table-condensed table-hover">
                    <Columns>
                     <asp:BoundField  DataField="SectionID" HeaderText="SectionID" ItemStyle-CssClass="grid-column"/> 
                     <asp:BoundField  DataField="SectionName" HeaderText="SectionName" ItemStyle-CssClass="grid-column"/> 
                     <asp:BoundField  DataField="Instructor" HeaderText="Instructor" ItemStyle-CssClass="grid-column"/> 
                     <asp:BoundField  DataField="Status" HeaderText="Status" ItemStyle-CssClass="grid-column"/> 
                     <asp:BoundField  DataField="NoofStudents" HeaderText="NoofStudents" ItemStyle-CssClass="grid-column"/> 
                     <asp:BoundField  DataField="CourseID" HeaderText="CourseID" ItemStyle-CssClass="grid-column"/> 
                     <asp:BoundField  DataField="CourseCode" HeaderText="CourseCode" ItemStyle-CssClass="grid-column"/> 
                     <asp:BoundField  DataField="CourseTitle" HeaderText="CourseTitle" ItemStyle-CssClass="grid-column"/> 
                     <asp:BoundField  DataField="CreditHours" HeaderText="CreditHours" ItemStyle-CssClass="grid-column"/> 
                     <asp:BoundField  DataField="PreReq_CourseID" HeaderText="Pre-req Course" ItemStyle-CssClass="grid-column"/> 
                     <asp:BoundField  DataField="Semester" HeaderText="Semester#" ItemStyle-CssClass="grid-column"/> 
                     
                     <asp:TemplateField HeaderText="Actions" ItemStyle-Width="290px">
                        <ItemTemplate>
                            <asp:Button style="margin-left:1rem;margin-top:5px;" ID="approveBtn" runat="server" Text="Approve Section" OnClick="approveBtn_Click" CssClass="actionBtns" PostBackUrl="#viewCourse" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    </Columns>

                 </asp:GridView>
             </fieldset>

    </form>
</body>
</html>                      