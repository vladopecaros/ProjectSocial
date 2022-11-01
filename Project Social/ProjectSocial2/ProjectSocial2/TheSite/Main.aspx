<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="ProjectSocial2.TheSite.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id ="Login">
    
        <asp:LoginName ID="LoginName1" runat="server" />
        <br />
        <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="Redirect" LogoutPageUrl="~/Accessing/Login.aspx" />
    
    </div>
        <div id="User">

            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

            <br />
            <asp:LoginView ID="LoginView1" runat="server">
                <RoleGroups>
                    <asp:RoleGroup Roles="Admin">
                        <ContentTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Administrative/SuperPass.aspx">Admin Login</asp:HyperLink>
                        </ContentTemplate>
                    </asp:RoleGroup>
                </RoleGroups>
            </asp:LoginView>

            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TheSite/Search.aspx">Search</asp:HyperLink>

            <br />
            <asp:HyperLink ID="hl_Profile" runat="server" NavigateUrl="~/TheSite/User.aspx">Profile</asp:HyperLink>

            <br />
            <asp:Button ID="btn_NewPost" runat="server" OnClick="NewPost_Click" Text="New Post" />

        </div>
        <div id ="NewPosts">

            <asp:Panel ID="pnl_newPostQ" runat="server">
            </asp:Panel>

        </div>
        <div id="Posts">
            <asp:Panel ID="pnl_posts" runat="server"></asp:Panel>
        </div>
    </form>
</body>
</html>
