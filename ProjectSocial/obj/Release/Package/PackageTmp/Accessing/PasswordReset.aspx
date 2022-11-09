<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="ProjectSocial2.Accessing.PasswordReset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" SuccessPageUrl="~/Accessing/Login.aspx">
        </asp:PasswordRecovery>
    
    </div>
    </form>
</body>
</html>
