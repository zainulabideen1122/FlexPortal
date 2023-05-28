<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manageFaculty.aspx.cs" Inherits="pages_manageFaculty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Faculty Data</title>
    <link href="admin.css" rel="stylesheet" />
 <style>

     .flexLogo
     {
         width:10%;
         margin:1rem 0
     }
    .grid-column {
        font-size: 14px;
        color: #333;
        text-align: left;
        padding: 8px;
        border: 1px solid #ddd;
        text-align:center;
    }
    
     #Text1 {
         width: 106px;
     }
     #Text2 {
         width: 98px;
     }
     #Text3 {
         width: 112px;
     }
     #Text4 {
         width: 115px;
     }
     #Text5 {
         width: 126px;
     }
     #Text6 {
         width: 117px;
     }
     #Text7 {
         width: 100px;
     }
    .updateTextBox
    {
        border:1px solid black;
        padding:10px;
        margin :0 5px;
        border-radius:3px;
    }
    .button
    {
        border:none;
        background-color:mediumpurple;
        padding:10px 20px;
        color:white;
        font-weight:bold;
        cursor:pointer;
        
    }
    .genderDisplay
    {
        display:flex;
        flex-direction:row;
        margin-top:0.7rem;
        margin-left:45%;
    }
    .genderLbl
    {
        font-family:sans-serif;
        font-size:1.1rem;
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

    #showfaculty{
        position:relative;
        left:10%;
    }
    .table-condensed tr th {
        border: 0px solid mediumpurple;
        color: white;
        background-color: mediumpurple;
    }

    .table-condensed, .table-condensed tr td {
        border: 0px solid #000;
    }

    tr:nth-child(even) {
        background: #f8f7ff
    }

    tr:nth-child(odd) {
        background: #fff;
    }
    #updationMsg
    {
        color:green;
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

        
       <br />
               
        <center>
        
        <asp:TextBox ID="Text1" runat="server" placeholder="CNIC" type="text" class="updateTextBox" ></asp:TextBox>
        <asp:TextBox id="Text2" runat="server" type="text" placeholder="Password" class="updateTextBox"></asp:TextBox>
        <asp:TextBox id="Text3" runat="server" type="text" placeholder="Email" class="updateTextBox"></asp:TextBox>
        <asp:TextBox id="Text4" runat="server" type="text" placeholder="FirstName" class="updateTextBox"></asp:TextBox>
        <asp:TextBox id="Text5" runat="server" type="text" placeholder="LasrName" class="updateTextBox"></asp:TextBox>
        <asp:TextBox id="Text7" runat="server" type="text" placeholder="Rank" class="updateTextBox"></asp:TextBox>
       <asp:Button ID="updateDataBtn" runat="server" Text="Update" CssClass="button" OnClick="updateDataBtn_click" style="margin-left:0.6rem;cursor:pointer" />
       

            <div class="genderDisplay">
            <asp:Label runat="server" CssClass="genderLbl">Gender: </asp:Label>
            <asp:RadioButtonList ID="rGender" runat="server" RepeatColumns="2">
                <asp:ListItem Value="M">Male</asp:ListItem>
                <asp:ListItem Value="F">Female</asp:ListItem>
            </asp:RadioButtonList>
            </div>
         <asp:Label ID="updationMsg" runat="server" visible="false"><h3>Updation Successfull!</h3></asp:Label>
           
            <br />
           
            </center>
  <center>

        

        <fieldset id="showfaculty" style="margin-right:20%">
           <legend align="left" style="font-family:sans-serif"><h1>All Faculty Detail</h1></legend>
           <asp:Button ID="btnAddStudent" runat="server" Text="Add a new faculty member" CssClass="button" OnClick="addFacultyBtn" />
           <br /><br />
            <asp:Label ID="lbl_id1" runat="server" visible="false"></asp:Label>
           <asp:Label ID="lbl_id2" runat="server" visible="false"></asp:Label>
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowUpdating="grd_RowUpdating" CssClass="table table-condensed table-hover">
            <Columns >
				<asp:BoundField  DataField="USER_ID" HeaderText="ID" ItemStyle-CssClass="grid-column"/>
				<asp:BoundField  DataField="CNIC" HeaderText="CNIC" ItemStyle-CssClass="grid-column" />
				<asp:BoundField  DataField="PASSWORD" HeaderText="PASSWORD" ItemStyle-CssClass="grid-column" />
				<asp:BoundField  DataField="EMAIL" HeaderText="EMAIL" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="FIRST_NAME" HeaderText="First Name" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="LAST_NAME" HeaderText="Last Name" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="GENDER" HeaderText="Gender" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="InstructorID" HeaderText="I_ID" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="Rank" HeaderText="Rank" ItemStyle-CssClass="grid-column" />
                <asp:TemplateField HeaderText="Action" ItemStyle-Width="230px">
                    <ItemTemplate>
                        <asp:Button style="margin-left:1.3rem" ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click" CssClass="actionBtns" />
                        <asp:Button style="margin-left:1rem" ID="deleteBtn" runat="server" Text="Delete" OnClick="deleteBtn_Click" CssClass="actionBtns" />
                    </ItemTemplate>
                    
                </asp:TemplateField>
			</Columns>
           </asp:GridView>
           
       </fieldset>
    
    </center>
       
    
    
    </form>



</body>
</html>
