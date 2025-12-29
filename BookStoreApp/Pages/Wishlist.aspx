<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Wishlist.aspx.cs"
    Inherits="BookStoreApp.Pages.Wishlist" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Wishlist</title>

    <style>
        body {
            font-family: Arial;
            background: #f4f6f8;
            margin: 0;
        }

        .header {
            background: #2c3e50;
            padding: 15px;
            color: white;
        }

        .header a {
            color: white;
            margin-right: 20px;
            text-decoration: none;
            font-weight: bold;
        }

        .container {
            width: 80%;
            margin: 30px auto;
            background: white;
            padding: 20px;
            border-radius: 6px;
        }

        .grid {
            width: 100%;
            border-collapse: collapse;
        }

        .grid th {
            background: #eee;
            padding: 8px;
        }

        .grid td {
            padding: 8px;
        }
    </style>
</head>

<body>
<form runat="server">

    <!-- HEADER -->
    <div class="header">
        <a href="~/Pages/Books.aspx" runat="server">Books</a>
        <a href="~/Pages/Cart.aspx" runat="server">Cart</a>
        <a href="~/Pages/Wishlist.aspx" runat="server">Wishlist</a>
        <a href="~/Pages/OrderHistory.aspx" runat="server">Orders</a>

        <asp:LinkButton runat="server" Text="Logout"
            OnClick="Logout_Click"
            style="float:right;color:white;" />
    </div>

    <!-- CONTENT -->
    <div class="container">
        <h2>My Wishlist</h2>

        <asp:GridView ID="gvWishlist" runat="server"
            CssClass="grid"
            AutoGenerateColumns="false"
            OnRowCommand="gvWishlist_RowCommand">

            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Author" HeaderText="Author" />
                <asp:BoundField DataField="Price" HeaderText="Price" />

                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>

                        <asp:Button
                            Text="Move to Cart"
                            runat="server"
                            CommandName="MoveToCart"
                            CommandArgument='<%# Eval("BookId") %>' />

                        <asp:Button
                            Text="Remove"
                            runat="server"
                            CommandName="Remove"
                            CommandArgument='<%# Eval("WishlistId") %>' />

                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>
    </div>

</form>
</body>
</html>
