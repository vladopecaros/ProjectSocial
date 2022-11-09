<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="ProjectSocial2.TheSite.Notifications" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../CSS/NotificationsPage.css" rel="stylesheet" />
    <title>Notifications</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TheSite/Main.aspx">&lt;-Back</asp:HyperLink>
            <h1>Notifications</h1>
        </div>
        <div>

            <asp:Panel ID="Panel1" runat="server">
                <br />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
