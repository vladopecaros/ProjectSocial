<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProblemsPage.aspx.cs" Inherits="ProjectSocial2.Administrative.ProblemsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Problems</title>
    <link href="../CSS/AdministrativePages.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Administrative/AdminHome.aspx">&lt;- Back</asp:HyperLink>

            <h1>
                Problems List
            </h1>
        </div>
        <div>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="Problems" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="FromUser" HeaderText="FromUser" SortExpression="FromUser" />
                    <asp:BoundField DataField="OnDate" HeaderText="OnDate" SortExpression="OnDate" />
                    <asp:BoundField DataField="Problem" HeaderText="Problem" SortExpression="Problem" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="Problems" runat="server" ConnectionString="Data Source=DESKTOP-P41DG8C\SQLEXPRESS;Initial Catalog=Administrative;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Problems] ORDER BY [OnDate]"></asp:SqlDataSource>
            <asp:TextBox ID="tb_ProblemId" runat="server" Enabled="False" CssClass="TextBox"></asp:TextBox><asp:Button ID="btn_delete" runat="server" Text="Delete" OnClick="btn_delete_Click" CssClass="Button" />

            <br />
            <asp:TextBox ID="tb_ProblemText" runat="server" Enabled="False" Height="54px" TextMode="MultiLine" Width="538px" CssClass="TextBox"></asp:TextBox>

        </div>
    </form>
</body>
</html>
