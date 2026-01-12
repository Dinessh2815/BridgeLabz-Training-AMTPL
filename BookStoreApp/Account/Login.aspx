<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LMS.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login</title>
</head>
<body>
<form runat="server">
    <h2>Login</h2>

    <asp:TextBox ID="txtUsername" runat="server" Placeholder="Username" /><br /><br />
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Password" /><br /><br />

    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /><br /><br />

    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
</form>
</body>
</html>
