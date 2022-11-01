<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="ProjectSocial2.TheSite.EditProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Edit Profile
            </h1>
        </div>
        <div>

            Username:
            <asp:TextBox ID="tb_UserName" runat="server" Width="162px" OnTextChanged="tb_UserName_TextChanged"></asp:TextBox>
            <br />
            Biography:
            <asp:TextBox ID="tb_Bio" runat="server" MaxLength="300" TextMode="MultiLine" Width="257px"></asp:TextBox>
            <br />
            <asp:Button ID="btn_cancel" runat="server" OnClick="btn_cancel_Click" Text="Cancel" />

            <asp:Button ID="Save" runat="server" OnClick="Save_Click" Text="Save" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        </div>
    </form>
</body>
</html>
