<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addFaculty.aspx.cs" Inherits="pages_addFaculty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body { background:rgb(30,30,40); }
        form { max-width:70%; margin:50px auto; margin-top: 5rem;}
        #innerForm
        {
            position:relative;
            left:30%;
            font-weight:bold;
            font-size:1.3rem;
            width: 40%;
            color: rgba(255, 255, 255, 0.461);
        }
        #addnewFaculty
        {
            padding-bottom:5rem;
        }
        #addnewFaculty h1
        {
            color: rgba(255, 255, 255, 0.461);
            font-family:sans-serif;
        }
        #checkBox
        {
            font-weight:100;
            margin-left:3rem;
        }
        #addBtn, #Button1
        {
            border:none;
            padding:10px 30px;
           background-color:white;
            font-size:1.1rem;
            box-shadow:0px 0px 3px black;
            margin-top:2rem;
            font-weight:bolder;

              font-family: 'Montserrat', Arial, Helvetica, sans-serif;
              width: 100%;
              background:mediumpurple;
              border-radius:5px;
              border:0;
              cursor:pointer;
              color:white;
              font-size:24px;
              padding-top:10px;
              padding-bottom:10px;
              transition: all 0.3s;
              font-weight:700;
              margin-top: 2rem;
              letter-spacing:3px;

        }
        #Button1{
            background: rgba(243, 191, 113, 0.673);
        }
        .feedback-input {
            color: rgba(255, 255, 255, 0.461);
          font-family: Helvetica, Arial, sans-serif;
          font-weight:500;
          font-size: 18px;
          border-radius: 5px;
          line-height: 22px;
          background-color: transparent;
          border:2px solid rgba(147, 112, 216, 0.5);
          transition: all 0.3s;
          padding: 13px;
          margin-bottom: 15px;
          width:100%;
          box-sizing: border-box;
          outline:0;
        }
        .flexLogo
         {
             width:10%;
             background:none;
             margin-top:1rem;
         }
    </style>
</head>
<body id=",h`">

    <center>
        <a href="/admin/Home.aspx">
            <img class="flexLogo" src="https://flexstudent.nu.edu.pk/Assets/demo/demo3/media/img/logo/flex-logo-blue.png" />
        </a>
    </center>

    <form id="form1" runat="server">  

             <div id="innerForm">
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <br />
                 <br />
                  <asp:TextBox ID="TextBox4" runat="server" CssClass="feedback-input" placeholder="First Name"></asp:TextBox>
                  <asp:TextBox ID="TextBox5" runat="server" CssClass="feedback-input" placeholder="Last Name"></asp:TextBox>
                 <asp:TextBox ID="TextBox1" runat="server" CssClass="feedback-input" placeholder="CNIC"></asp:TextBox>

                 <asp:TextBox ID="TextBox2" runat="server" CssClass="feedback-input"  placeholder="Email"></asp:TextBox>
                   <asp:TextBox ID="TextBox3" runat="server" CssClass="feedback-input" placeholder="Password"></asp:TextBox>


                 <asp:TextBox ID="TextBox7" runat="server" CssClass="feedback-input" placeholder="Rank" ></asp:TextBox>

                  &nbsp;Gender <div id="checkBox" >
                      <div>
                            <asp:RadioButton ID="Option1" runat="server" GroupName="Options" Text="Male" />
                      </div>
                      <div>
                            <asp:RadioButton ID="Option2" runat="server" GroupName="Options" Text="Female" />
                      </div>
                  </div>
                 

                 <asp:Button runat="server" Text="ADD" ID="addBtn" OnClick="addFacultyBtn"></asp:Button>
                 <asp:Button runat="server" Text="Go Back" ID="Button1" OnClick="goBack"></asp:Button>
             </div>
             
        

    </form>

    
</body>
</html>
