<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="ProjectSocial2.Administrative.AdminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Welcome to the Administrative HomePage
            <asp:LoginName ID="LoginName1" runat="server" />
            <br />
            <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutPageUrl="~/login.aspx" />
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="Users" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="ComplaintId" HeaderText="ComplaintId" SortExpression="ComplaintId" />
                    <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
                    <asp:BoundField DataField="OnUserId" HeaderText="OnUserId" SortExpression="OnUserId" />
                    <asp:BoundField DataField="OnPostId" HeaderText="OnPostId" SortExpression="OnPostId" />
                    <asp:BoundField DataField="OnDate" HeaderText="OnDate" SortExpression="OnDate" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="Users" runat="server" ConnectionString="Data Source=PC-PC\SQLEXPRESS;Initial Catalog=Administrative;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Complaints] ORDER BY [OnDate]"></asp:SqlDataSource>
            Complaint Id:
            <asp:TextBox ID="tb_CompId" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Button ID="btn_DeleteCom" runat="server" Text="Delete Complaint" />
            <br />
            From User:<asp:TextBox ID="tb_FromUser" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Button ID="btn_ShowFromUser" runat="server" Text="Show User" />
            <br />
            On User:<asp:TextBox ID="tb_OnUser" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Button ID="btn_ShowOnUser" runat="server" Text="Show User" />
            <br />
            OnPost:<asp:TextBox ID="tb_OnPost" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Button ID="btn_ShowPost" runat="server" Text="Show Post" />
            <br />
            Date:<asp:TextBox ID="tb_Date" runat="server" ReadOnly="True" TextMode="DateTime"></asp:TextBox>
        </div>
    </form>
</body>
</html>
