<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="ProjectSocial2.Accessing.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Admin Login</div>
        <div>

            <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Administrative/SuperPass.aspx" DisplayRememberMe="False">
            </asp:Login>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Accessing/login.aspx">Back to user login</asp:HyperLink>
            <br />

        </div>
    </form>
</body>
</html>
