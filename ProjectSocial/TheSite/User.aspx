<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="ProjectSocial2.TheSite.User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../CSS/User.css" rel="stylesheet" />
    <title>User View</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Username">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TheSite/Main.aspx">&lt;-Back</asp:HyperLink>
            <h1>
                <asp:Label ID="lbl_user" runat="server"></asp:Label>
            </h1>
        </div>
        <div id="UserDetails">
            Followers:
            <asp:Label ID="lbl_Followers" runat="server"></asp:Label>
            <br />
            Following:
            <asp:Label ID="lbl_Following" runat="server"></asp:Label>
            <br />
            Posts:
            <asp:Label ID="lbl_Posts" runat="server"></asp:Label>
            <br />
            Biography:
            <br />
            <asp:Label ID="lbl_bio" runat="server"></asp:Label>

            <br />
            <asp:Button ID="btn_function" runat="server" Text="Button" CssClass="MFButton" />
            <hr />

        </div>
        <div id="UserPosts">


            <asp:Panel ID="pnl_posts" runat="server">
            </asp:Panel>


        </div>
    </form>
</body>
</html>
