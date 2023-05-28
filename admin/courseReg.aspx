<%@ Page Language="C#" AutoEventWireup="true" CodeFile="courseReg.aspx.cs" Inherits="pages_courseReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Page</title>

       <style>
           #Courses{
               margin-bottom:5rem;
           }
           #showCourses, #CourseSection, #allAssignment{
               display:flex;
               align-items:center;
               justify-content:center;
               text-align:center;
           }
           #Courses, #viewCourse
           {
               display:flex;
               flex-direction:column;
               align-items:center;
               justify-content:center;
               text-align:center;
               
           }
           #allAssignment
           {
               width:60%;
           }
           #showCourses, #Courses, #CourseSection,#viewCourse
           {
               width:80%;
               position:relative;
               left:10%;

           }
           .actionBtns
            {
                border:none;
                background-color:#83783ac1;
                padding:10px 20px;
                color:white;
                font-weight:bold;
                cursor:pointer;
            }
           .flexLogo
           {
                width:10%;
                margin:1rem 0
           }
           .table
           {
               position:relative;
               left:auto;
           }
           .table-condensed tr th {
                border: 0px solid mediumpurple;
                color: white;
                background-color: mediumpurple;
                text-align:center;
                padding:5px;
            }

            .table-condensed, .table-condensed tr td {
                border: 0px solid #000;
                padding:8px 0;
                padding:10px 0;
            }

            tr:nth-child(even) {
                background: #f8f7ff
            }

            tr:nth-child(odd) {
                background: #fff;
            }
            #noRecordFound
            {
                font-size:1.5rem;
                font-family:'Agency FB';
                font-weight:bolder;
                color:red;
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
        
       <fieldset id="showCourses" style="margin-right:20%">
           <legend align="left"><h1>All Courses Detail</h1></legend>
           <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="table table-condensed table-hover">
               <Columns>
				<asp:BoundField  DataField="CourseID" HeaderText="CourseID" ItemStyle-CssClass="grid-column"/> 
				<asp:BoundField  DataField="CourseCode" HeaderText="CourseCode" ItemStyle-CssClass="grid-column" />
				<asp:BoundField  DataField="CourseTitle" HeaderText="CourseTitle" ItemStyle-CssClass="grid-column" />
				<asp:BoundField  DataField="CreditHours" HeaderText="CreditHours" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="Semester" HeaderText="Semester" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="PrereqCourseCode" HeaderText="Pre-req" ItemStyle-CssClass="grid-column" />

                <asp:TemplateField HeaderText="Actions" ItemStyle-Width="290px">
                    <ItemTemplate>
                        <asp:Button style="margin-left:1rem;margin-top:5px;" ID="updateBtn" runat="server" Text="View" OnClick="viewBtn_Click" CssClass="actionBtns" PostBackUrl="#viewCourse" />
                    </ItemTemplate>
                </asp:TemplateField>


			</Columns>

               </asp:GridView>

           </fieldset>


        <fieldset id="Courses" style="margin-right:20%">
           <legend align="left"><h1>Assign a Course</h1></legend>

             <fieldset id="allAssignment" style="margin-bottom:2rem">
                <legend align="left"><h1>All Assignments</h1></legend>
                 <asp:GridView ID="showAllAssignment" runat="server" CssClass="table table-condensed table-hover">
                  </asp:GridView>
             </fieldset>

            &nbsp;Select Course:<br /><br />
           <asp:DropDownList ID="courseCodesDDL" runat="server">
            </asp:DropDownList>
           <br /><br />
            &nbsp;Select Professor:<br /><br />
           <asp:DropDownList ID="ProfessorEmails" runat="server">
           </asp:DropDownList>
           <br /><br />
           <asp:Button ID="AssignButton" runat="server" Text="Assign" OnClick="AssignButton_Click" CssClass="actionBtns" />
       </fieldset>





        <fieldset id="viewCourse" style="margin-right:20%">
           <legend align="left"><h1>Course Sections</h1></legend>

            <asp:GridView ID="showCourseSections" runat="server" CssClass="table table-condensed table-hover">
             </asp:GridView>

            <asp:Label ID="noRecordFound" runat="server" Text="No Record Found!" visible="true"></asp:Label>

            <br /><br />
             
         </fieldset>
        <br /><br />

    </form>


</body>
</html>
