<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ProjectSocial2.Accessing.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link href="../CSS/LoginPage.css" rel="stylesheet" />
    <script>
        history.forward();
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Login ID="Login1" runat="server" CreateUserText="Do not have an account? Create one here" CreateUserUrl="~/Accessing/Register.aspx" DestinationPageUrl="~/Accessing/Loading.aspx" PasswordRecoveryUrl="~/Accessing/PasswordReset.aspx">
            <LoginButtonStyle CssClass="TheButton" />
            <TextBoxStyle CssClass="TextBox" />
        </asp:Login>
    
        <br />
    
    </div>
    </form>
</body>
</html>
