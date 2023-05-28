<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewCourse.aspx.cs" Inherits="pages_viewCourse" MaintainScrollPositionOnPostback="true" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Sections</title>

    <style>
        .updateTextBox
            {
                border:1px solid black;
                padding:10px;
                margin :0 5px;
                border-radius:3px;
                margin:10px;
            }
        #viewCourse,#assignCourseToInstructor
        {
            display:flex;
            flex-direction:column;
            align-items:center;
            justify-content:center;
            text-align:center;
               
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
                padding: 15px 0;
            }

            tr:nth-child(even) {
                background: #f8f7ff
            }

            tr:nth-child(odd) {
                background: #fff;
            }

           #viewCourse, #assignCourseToInstructor
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
            #showCourseTitle
            {
                color:red;
                font-family:'Agency FB';
                font-weight:bold;
            }
            #deleteBtn
            {
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

            <fieldset id="viewCourse" style="margin-right:20%">
                <legend align="left"><h1>Course Sections</h1></legend>

                <asp:GridView ID="viewCourseSections" runat="server" AutoGenerateColumns="false" CssClass="table table-condensed table-hover">
                <Columns>

                <asp:BoundField  DataField="SectionID" HeaderText="SectionID" ItemStyle-CssClass="grid-column"/> 
				<asp:BoundField  DataField="SectionName" HeaderText="SectionName" ItemStyle-CssClass="grid-column" />
				<asp:BoundField  DataField="Instructor" HeaderText="Instructor" ItemStyle-CssClass="grid-column" />
				<asp:BoundField  DataField="Status" HeaderText="Status" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="NoodStudents" HeaderText="NoofStudents" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="CourseID" HeaderText="CourseID" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="CourseCode" HeaderText="CourseCode" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="CourseTitle" HeaderText="CourseCode" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="CreditHours" HeaderText="CreditHours" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="PreReq_CourseID" HeaderText="Pre-req" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="Semester" HeaderText="Semester" ItemStyle-CssClass="grid-column" />

                    <asp:TemplateField HeaderText="Actions" ItemStyle-Width="290px">
                    <ItemTemplate>
                        <asp:Button ID="deleteBtn" runat="server" Text="Delete" onclick="deleteSection_click" CssClass="actionBtns" />
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns> 
                </asp:GridView>

                <br /><br />
                <fieldset id="assignCourseToInstructor" style="margin-right:20%">
                    <legend align="left"><h1>Assign a section to the Instructor</h1></legend>
                    &nbsp;Select Course:<br /><br />
                   <asp:DropDownList ID="assignViewCourseCode" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="assignCourseCode_Selected" onchange="javascript:__doPostBack()" >
                    </asp:DropDownList>
                   <br />
                    &nbsp;Select Section:<br /><br />
                   <asp:DropDownList ID="selectSection" runat="server"  AutoPostBack="true" >
                    </asp:DropDownList><br />
                    <asp:Label ID="showCourseTitle" runat="server" Text="OK!" visible="false"></asp:Label>
                    <br />
                    </asp:DropDownList>
                    <asp:Button ID="Button2" runat="server" Text="Assign Section" OnClick="assignSection_Click" CssClass="actionBtns" />
                </fieldset>

                <fieldset id="viewCourse" style="margin-right:20%">
                <legend align="left"><h1>Create new section of a Course</h1></legend>
                &nbsp;Select Course:<br /><br />
               <asp:DropDownList ID="viewCourseCodes" runat="server"  AutoPostBack="true" >
                </asp:DropDownList>
               <br />
               <asp:TextBox style="text-align:center;" ID="sectionName" runat="server" placeholder="Section Name" type="text" class="updateTextBox" ></asp:TextBox>
               </asp:DropDownList>
                <asp:Button ID="Button1" runat="server" Text="Add Section" OnClick="addSection_Click" CssClass="actionBtns" />
            </fieldset>

                
                <br /><br /><br />
                 
         </fieldset>


            

    </form>
</body>
</html>

