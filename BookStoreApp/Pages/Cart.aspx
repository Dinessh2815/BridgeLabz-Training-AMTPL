<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Cart.aspx.cs"
    Inherits="BookStoreApp.Pages.Cart" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>My Cart</title>

    <style>
        body {
            font-family: Arial;
            background: #f4f6f8;
        }

        .container {
            width: 70%;
            margin: 40px auto;
            background: white;
            padding: 20px;
            border-radius: 6px;
        }

        h2 {
            text-align: center;
        }

        .grid {
            width: 100%;
            margin-top: 20px;
        }

        .btn-remove {
            background: #dc3545;
            color: white;
            border: none;
            padding: 5px 10px;
            cursor: pointer;
        }

        .nav {
            text-align: right;
            margin-bottom: 10px;
        }

        .nav a {
            margin-left: 10px;
        }
    </style>
</head>

<body>
<form runat="server">
    <div class="container">

        <div class="nav">
            <asp:HyperLink NavigateUrl="~/Pages/Books.aspx"
                Text="← Continue Shopping"
                runat="server" />
        </div>

        <h2>My Cart</h2>

        <asp:GridView ID="gvCart" runat="server"
            AutoGenerateColumns="false"
            OnRowCommand="gvCart_RowCommand"
            CssClass="grid">

            <Columns>

                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Author" HeaderText="Author" />
                <asp:BoundField DataField="Price" HeaderText="Price (₹)" />
                <asp:BoundField DataField="Quantity" HeaderText="Qty" />
                <asp:BoundField DataField="ItemTotal" HeaderText="Total (₹)" />

                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>

                        <asp:Button 
                            Text="−"
                            runat="server"
                            CommandName="Decrease"
                            CommandArgument='<%# Eval("CartId") %>' />

                        <asp:Button 
                            Text="+"
                            runat="server"
                            CommandName="Increase"
                            CommandArgument='<%# Eval("CartId") %>' />

                        <asp:Button 
                            Text="Remove"
                            runat="server"
                            CommandName="Remove"
                            CommandArgument='<%# Eval("CartId") %>' />

                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

        <br />

        <b>Grand Total: ₹</b>
        <asp:Label ID="lblGrandTotal" runat="server" />

        <asp:Label ID="lblMsg" runat="server" />

        <br /><br />

        <asp:Button 
            ID="btnPlaceOrder"
            runat="server"
            Text="Place Order"
            OnClick="btnPlaceOrder_Click"
            BackColor="Green"
            ForeColor="White" />


    </div>
</form>
</body>
</html>
