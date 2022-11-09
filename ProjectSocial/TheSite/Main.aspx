<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="ProjectSocial2.TheSite.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../CSS/MainPage.css" rel="stylesheet" />
    <title>MainPage</title>
    <script src="../JS/Problem&NewPost_Btn.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id ="Login">
    
        <asp:LoginName ID="LoginName1" runat="server" />
        <br />
        <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="Redirect" LogoutPageUrl="~/Accessing/Login.aspx" />
    
    </div>
        <div id="User">

            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/TheSite/Notifications.aspx">Notifications</asp:HyperLink>

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
            <input id="btn_NewPost" class="DivButton" type="button" value="New Post" onclick="DissableEnable(2)"/>
            <input id="btn_Problem" class="DivButton" type="button" value="Report Problem" onclick="DissableEnable(1)"/>

        </div>
        <div id="ProblemDiv" class="ExpandingDiv">
        <br />
            <asp:TextBox ID="tb_ProblemText" runat="server" Height="57px" MaxLength="249" TextMode="MultiLine" Width="301px" CssClass="TextBox"></asp:TextBox>
            <asp:Button ID="btn_ReportProblem" runat="server" Text="Report Problem" OnClick="btn_ReportProblem_Click" CssClass="PostButton" />
        </div>
        <div id="NewPostDiv" class="ExpandingDiv">
        <br />
            <asp:TextBox ID="tb_PostText" runat="server" Height="86px" MaxLength="500" TextMode="MultiLine" Width="298px" CssClass="TextBox"/>
            <asp:Button ID="btn_PostPost" runat="server" OnClick="btn_PostPost_Click" Text="Post" CssClass="PostButton" />
        </div>
        <br />
        <div id="Posts">
            <asp:Panel ID="pnl_posts" runat="server"></asp:Panel>
        </div>
    </form>
</body>
</html>
