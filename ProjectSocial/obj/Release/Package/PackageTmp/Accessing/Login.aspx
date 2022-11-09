<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectSocial2.Accessing.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Login ID="Login1" runat="server" CreateUserText="Do not have an account? Create one here" CreateUserUrl="~/Accessing/Register.aspx" DestinationPageUrl="~/TheSite/Main.aspx" PasswordRecoveryUrl="~/Accessing/PasswordReset.aspx">
        </asp:Login>
    
    </div>
    </form>
</body>
</html>
