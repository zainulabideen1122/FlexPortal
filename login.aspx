<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_Default" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN FORM</title>
    
    <style>
        #checkBox{
            display:inline-flex;
            color: #7f8c8d;
        }

        body
        {
            background: linear-gradient(to right, #36d1dc,#5b86e5);  
            background-repeat: no-repeat;
            height: 100vh;
        }
        .loginContainer
        {
            font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            display:flex;
            flex-direction: column;
            width: 30%;
            background-color: rgba(255, 255, 255, 0.906);
            padding: 5rem 0;
            padding-bottom: 7rem;
            position: relative;
            top: 25vh;
            justify-content: center;
            align-items: center;
        }
        .inputHolder, .btn, #txtUsername
        {
            border: none;
            width: 70%;
            padding: 10px;
            margin-bottom:1rem ;
            color: #7f8c8d;
        }

        .inputHolder::placeholder
        {
            color: #bdc3c7;
        }
        .inputHolder:focus
        {
            outline: none;
        }
        .btn
        {
            background-color: #5b86e5;
            color: white;
            width: 80%;
            position:relative;
            left:10%
            
        }
        .btn:hover{
            cursor:pointer;
        }
        input[type='radio'] {
            accent-color: #7f8c8d;
        }

    </style>
</head>
<body>
    <center>
    <form id="form1" runat="server" class="loginContainer">
        <div>
            <img class="flexLogo" src="https://flexstudent.nu.edu.pk/Assets/demo/demo3/media/img/logo/flex-logo-blue.png" style="width: 20%;margin-right: 1rem;" />
            <h1>Sign In</h1>
            <div>
                <asp:TextBox ID="txtUsername" runat="server" placeholder="Email Address" CssClass="inputHolder"></asp:TextBox>
            </div>
            
            <div>
                <input   runat="server" id="txtPassword" type="password" placeholder="Password" class="inputHolder" />

            </div>
            
        <div id="checkBox" >
            <div>
        <asp:RadioButton ID="Option1" runat="server" GroupName="Options" Text="Admin" />
    </div>
    <div>
        <asp:RadioButton ID="Option2" runat="server" GroupName="Options" Text="Faculty" />
    </div>
    <div>
        <asp:RadioButton ID="Option3" runat="server" GroupName="Options" Text="Student" />
    </div>
            </div>


            <br /><br /><br />
            <div style="display: flex; align-items:center;">
                <asp:Button runat="server" Text="Login" ID="btnLogin" OnClick="btnLogin_Click" CssClass="btn"></asp:Button>
                
            </div>
        </div>
    </form>
        </center>
</body>
</html>







