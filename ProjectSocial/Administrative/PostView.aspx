<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostView.aspx.cs" Inherits="ProjectSocial2.Administrative.PostFinder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Post Viewer</title>
    <link href="../CSS/AdministrativePages.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_User" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lbl_Content" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lbl_Date" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lbl_Likes" runat="server"></asp:Label>
            <br />
            <asp:Button ID="btn_delete" runat="server" OnClick="btn_delete_Click" Text="Delete" CssClass="Button" />
        </div>
    </form>
</body>
</html>
