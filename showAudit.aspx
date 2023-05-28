<%@ Page Language="C#" AutoEventWireup="true" CodeFile="showAudit.aspx.cs" Inherits="showAudit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Show Audit</title>

    <style>
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
   
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="showAudits" runat="server" CssClass="table table-condensed table-hover">
         </asp:GridView>
    </form>
</body>
</html>
