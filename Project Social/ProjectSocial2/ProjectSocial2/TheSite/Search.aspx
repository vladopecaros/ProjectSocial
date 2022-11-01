<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="ProjectSocial2.TheSite.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Search</h1>
        </div>
        <div>

            <asp:TextBox ID="tb_search" runat="server"></asp:TextBox>
            <asp:Button ID="btn_search" runat="server" OnClick="btn_search_Click" Text="Search" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>
            <hr />
        </div>
    </form>
</body>
</html>
