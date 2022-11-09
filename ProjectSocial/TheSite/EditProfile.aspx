<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="ProjectSocial2.TheSite.EditProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../JS/ShowHideDiv.js"></script>
    <link href="../CSS/EditProfilePage.css" rel="stylesheet" />
    <title>Edit Profile</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="hl_Profile" runat="server" NavigateUrl="~/TheSite/User.aspx">&lt;-Back</asp:HyperLink>
            <h1>Edit Profile
            </h1>
        </div>
        <div id="InputSection" class="ExpandingDiv">

            Username:
            <asp:TextBox ID="tb_UserName" runat="server" Width="162px" OnTextChanged="tb_UserName_TextChanged" CssClass="TextBox"></asp:TextBox>
            <br />
            Biography:
            <asp:TextBox ID="tb_Bio" runat="server" MaxLength="300" TextMode="MultiLine" Width="334px" CssClass="TextBox"></asp:TextBox>
            <br />
            
        
            <asp:Button ID="btn_cancel" runat="server" OnClick="btn_cancel_Click" Text="Cancel" CssClass="CancelBtn" />
            <input id="SaveButton" class="SaveBtn" type="button" value="Save" onclick="HideInput()" />
        </div>
        <div id="ConfirmationSection" class="ExpandingDiv">

            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <input id="CancelButton" class="CancelBtn" type="button" value="Cancel" onclick="ShowInput()" /><asp:Button ID="Save" runat="server" OnClick="Save_Click" Text="Save" CssClass="SaveBtn" />

        </div>
    </form>
</body>
</html>
