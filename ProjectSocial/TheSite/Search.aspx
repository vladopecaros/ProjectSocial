<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="ProjectSocial2.TheSite.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../CSS/SearchPage.css" rel="stylesheet" />
    <title>Search</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TheSite/Main.aspx">&lt;-Back</asp:HyperLink>
            <h1>Search</h1>
        </div>
        <div>

            <asp:TextBox ID="tb_search" runat="server" CssClass="TextBox"></asp:TextBox>
            <asp:Button ID="btn_search" runat="server" OnClick="btn_search_Click" Text="Search" CssClass="SearchButton" />
            <br />
            <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>
            <hr />
        </div>
    </form>
</body>
</html>
