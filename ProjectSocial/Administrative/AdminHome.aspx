<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="ProjectSocial2.Administrative.AdminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../CSS/AdministrativePages.css" rel="stylesheet" />
    <title>Admin Home</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Welcome to the Administrative HomePage
            <asp:LoginName ID="LoginName1" runat="server" />
            <br />
            <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutPageUrl="~/login.aspx" LogoutAction="RedirectToLoginPage" />
            <br />
            <asp:HyperLink ID="hl_Problems" runat="server" NavigateUrl="~/Administrative/ProblemsPage.aspx">Problems List</asp:HyperLink>
        </div>
        <div>
            
            <asp:SqlDataSource ID="Users" runat="server" ConnectionString="Data Source=DESKTOP-P41DG8C\SQLEXPRESS;Initial Catalog=Administrative;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Complaints] ORDER BY [OnDate]"></asp:SqlDataSource>
            Complaint Id:
            <asp:TextBox ID="tb_CompId" runat="server" ReadOnly="True" CssClass="TextBox"></asp:TextBox>
            <asp:Button ID="btn_DeleteCom" runat="server" Text="Delete Complaint" OnClick="btn_DeleteCom_Click" CssClass="Button" />
            <br />
            From User:<asp:TextBox ID="tb_FromUser" runat="server" ReadOnly="True" CssClass="TextBox"></asp:TextBox>
            <asp:Button ID="btn_ShowFromUser" runat="server" Text="Show User" OnClick="btn_ShowFromUser_Click" CssClass="Button" />
            <br />
            On User:<asp:TextBox ID="tb_OnUser" runat="server" ReadOnly="True" CssClass="TextBox"></asp:TextBox>
            <asp:Button ID="btn_ShowOnUser" runat="server" Text="Show User" OnClick="btn_ShowOnUser_Click" CssClass="Button" />
            <br />
            OnPost:<asp:TextBox ID="tb_OnPost" runat="server" ReadOnly="True" CssClass="TextBox"></asp:TextBox>
            <asp:Button ID="btn_ShowPost" runat="server" Text="Show Post" OnClick="btn_ShowPost_Click" CssClass="Button" />
            <br />
            Date:<asp:TextBox ID="tb_Date" runat="server" ReadOnly="True" TextMode="DateTime" CssClass="TextBox"></asp:TextBox>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataSourceID="Users">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="ComplaintId" HeaderText="ComplaintId" InsertVisible="False" ReadOnly="True" SortExpression="ComplaintId" />
                    <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
                    <asp:BoundField DataField="OnUserId" HeaderText="OnUserId" SortExpression="OnUserId" />
                    <asp:BoundField DataField="OnPostId" HeaderText="OnPostId" SortExpression="OnPostId" />
                    <asp:BoundField DataField="OnDate" HeaderText="OnDate" SortExpression="OnDate" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
