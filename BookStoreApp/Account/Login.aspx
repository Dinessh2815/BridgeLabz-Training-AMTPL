<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs"
    Inherits="BookStoreApp.Account.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login</title>

    <style>
        body {
            font-family: Arial;
            background: #f4f6f8;
        }
        .container {
            width: 350px;
            margin: 100px auto;
            background: white;
            padding: 25px;
            border-radius: 6px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }
        h2 {
            text-align: center;
        }
        .input {
            width: 100%;
            padding: 8px;
            margin: 6px 0 12px 0;
        }
        .btn {
            width: 100%;
            padding: 8px;
            background: #007bff;
            color: white;
            border: none;
            cursor: pointer;
        }
        .btn:hover {
            background: #0056b3;
        }
        .link {
            text-align: center;
            margin-top: 10px;
        }
        .msg {
            text-align: center;
            margin-top: 10px;
        }
    </style>
</head>

<body>
    <form runat="server">
        <div class="container">

            <h2>Login</h2>

            <asp:Label Text="Email" runat="server" />
            <asp:TextBox ID="txtEmail" CssClass="input" runat="server" />

            <asp:Label Text="Password" runat="server" />
            <asp:TextBox ID="txtPassword" CssClass="input"
                runat="server" TextMode="Password" />

            <asp:Button ID="btnLogin" CssClass="btn"
                runat="server" Text="Login"
                OnClick="btnLogin_Click" />

            <div class="msg">
                <asp:Label ID="lblMsg" runat="server" />
            </div>

            <div class="link">
                <asp:HyperLink NavigateUrl="Register.aspx"
                    Text="New user? Register here"
                    runat="server" />
            </div>

        </div>
    </form>
</body>
</html>
