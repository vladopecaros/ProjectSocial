<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuperPass.aspx.cs" Inherits="ProjectSocial2.Administrative.SuperPass_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../CSS/AdministrativePages.css" rel="stylesheet" />
    <title>SuperPass</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Hello
            <asp:LoginName ID="LoginName1" runat="server" />
            . Please input your SuperPassword bellow:</div>
        <div>

            <asp:TextBox ID="TextBox1" runat="server" Width="281px" CssClass="TextBox"></asp:TextBox>
            <br />
            <asp:Button ID="btn_login" runat="server" OnClick="btn_login_Click" Text="Login" CssClass="Button" />

            <br />
            <asp:Label ID="lbl_error" runat="server" Text="Waiting..."></asp:Label>

        </div>
    </form>
</body>
</html>
