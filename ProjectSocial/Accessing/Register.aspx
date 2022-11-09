
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ProjectSocial2.Accessing.Register" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../CSS/LoginPage.css" rel="stylesheet" />
    <title>Register</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" FinishDestinationPageUrl="~/Accessing/login.aspx" CancelDestinationPageUrl="~/Accessing/login.aspx" ContinueDestinationPageUrl="~/Accessing/login.aspx" DisplayCancelButton="True">
        <ContinueButtonStyle CssClass="TheButton" />
        <CreateUserButtonStyle CssClass="TheButton" />
        <TextBoxStyle CssClass="TextBox" />
    <WizardSteps>
        <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" />
        <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" />
    </WizardSteps>
        <CancelButtonStyle CssClass="TheButton" />
        <FinishCompleteButtonStyle CssClass="TheButton" />
        <FinishPreviousButtonStyle CssClass="TheButton" />
</asp:CreateUserWizard>
    </div>
    </form>
</body>
</html>
