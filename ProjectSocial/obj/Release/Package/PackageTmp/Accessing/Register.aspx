
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ProjectSocial2.Accessing.Register" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" FinishDestinationPageUrl="~/Accessing/Login.aspx" CancelDestinationPageUrl="~/Accessing/Login.aspx" ContinueDestinationPageUrl="~/Accessing/Login.aspx" DisplayCancelButton="True">
    <WizardSteps>
        <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" />
        <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" />
    </WizardSteps>
</asp:CreateUserWizard>
    </div>
    </form>
</body>
</html>
