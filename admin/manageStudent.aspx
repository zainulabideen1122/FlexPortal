<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manageStudent.aspx.cs" Inherits="pages_manageStudent" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Data</title>
    <link href="/admin/admin.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
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
        padding: 8px 0;
        border: 1px solid #ddd;
        text-align:center;
    }
    
     #Text1 {
         width: 100px;
     }
     #Text2 {
         width: 100px;
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
        margin:10px;
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
        left:0%;
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
    .addFacultyBtnCss
    {
        position:relative;
        left:60%;
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
        <asp:TextBox id="Text7" runat="server" type="text" placeholder="Permission" class="updateTextBox"></asp:TextBox>
            <br />
        <asp:TextBox id="Text8" runat="server" type="text" placeholder="RollNumber" class="updateTextBox"></asp:TextBox>
        <asp:TextBox id="Text9" runat="server" type="text"  placeholder="Status" class="updateTextBox"></asp:TextBox>
        <asp:TextBox id="Text10" runat="server" type="text" placeholder="Batch" class="updateTextBox"></asp:TextBox>
        <asp:TextBox id="Text11" runat="server" type="text" placeholder="Country" class="updateTextBox"></asp:TextBox>
        <asp:TextBox id="Text12" runat="server" type="text" placeholder="BloodGroup" class="updateTextBox"></asp:TextBox>
        <asp:TextBox id="Text13" runat="server" type="text" placeholder="Phone#" class="updateTextBox"></asp:TextBox>
        <asp:TextBox id="Text14" runat="server" type="text" placeholder="City" class="updateTextBox"></asp:TextBox>
        <asp:TextBox id="Text15" runat="server" type="text" placeholder="Address" class="updateTextBox"></asp:TextBox>
        <asp:TextBox id="Text16" runat="server" type="text" placeholder="FatherCNIC" class="updateTextBox"></asp:TextBox>
        <asp:TextBox id="Text17" runat="server" type="text" placeholder="Semester" class="updateTextBox"></asp:TextBox>


       <asp:Button ID="updateDataBtn" runat="server" Text="Update" CssClass="button" OnClick="updateDataBtn_click" style="margin-left:0.6rem;cursor:pointer" />
       

            <div class="genderDisplay">
            <asp:Label runat="server" CssClass="genderLbl">Gender: </asp:Label>
            <asp:RadioButtonList ID="rGender" runat="server" RepeatColumns="2">
                <asp:ListItem Value="M">Male</asp:ListItem>
                <asp:ListItem Value="F">Female</asp:ListItem>
            </asp:RadioButtonList>
            </div>
        <br />
            </center>


        

        <fieldset id="showfaculty">
           <legend align="left" style="font-family:sans-serif;margin-left:6rem"><h1>All Student Detail</h1></legend>
           <asp:Button ID="btnAddStudent" runat="server" Text="Add a new Student" CssClass="button addFacultyBtnCss" OnClick="addFacultyBtn" />
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
                <asp:BoundField  DataField="PERMISSION" HeaderText="PERMISSION" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="ARN" HeaderText="ARN" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="ROLLNUM" HeaderText="ROLLNUM" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="STATUS" HeaderText="STATUS" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="BATCH" HeaderText="BATCH" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="COUNTRY" HeaderText="COUNTRY" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="BLOODGROUP" HeaderText="BLOODGROUP" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="MOBILENUM" HeaderText="MOBILENUM" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="CITY" HeaderText="CITY" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="ADDRESS" HeaderText="ADDRESS" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="FATHERCNIC" HeaderText="FATHERCNIC" ItemStyle-CssClass="grid-column" />
                <asp:BoundField  DataField="Semester" HeaderText="Semester" ItemStyle-CssClass="grid-column" />

                <asp:TemplateField HeaderText="Action" ItemStyle-Width="290px">
                    <ItemTemplate>
                        <asp:Button style="margin-left:1rem;margin-top:5px;" ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click" CssClass="actionBtns" />
                        <asp:Button style="margin-left:1rem;margin-top:5px;" ID="deleteBtn" runat="server" Text="Delete " OnClick="deleteBtn_Click" CssClass="actionBtns" />
                    </ItemTemplate>
                </asp:TemplateField>
			</Columns>

           </asp:GridView>
           
       </fieldset>
    
 
       
    
    
    </form>



</body>
</html>