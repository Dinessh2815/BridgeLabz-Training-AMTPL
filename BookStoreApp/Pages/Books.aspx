<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Books.aspx.cs"
    Inherits="BookStoreApp.Pages.Books" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Books</title>

    <style>
        body {
            font-family: Arial;
            background: #f4f6f8;
        }

        .header {
            background: #343a40;
            color: white;
            padding: 15px 30px;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }

        .header a {
            color: white;
            text-decoration: none;
            margin-left: 15px;
        }

        .container {
            width: 85%;
            margin: 30px auto;
            background: white;
            padding: 20px;
            border-radius: 6px;
        }

        h2 {
            text-align: center;
        }

        .grid {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .grid th {
            background: #007bff;
            color: white;
            padding: 8px;
        }

        .grid td {
            padding: 8px;
            text-align: center;
        }

        .btn-cart {
            background: #28a745;
            color: white;
            border: none;
            padding: 5px 10px;
            cursor: pointer;
        }

        .btn-wishlist {
            background: #ffc107;
            border: none;
            padding: 5px 10px;
            cursor: pointer;
        }
    </style>
</head>

<body>
<form runat="server">

    <!-- Header -->
    <div class="header">
    <div>
        <asp:Label ID="lblWelcome" runat="server" />
    </div>
    <div>
        <asp:HyperLink 
            NavigateUrl="Cart.aspx"
            Text="View Cart"
            runat="server" />

        &nbsp;&nbsp;

        <asp:HyperLink 
            NavigateUrl="Wishlist.aspx"
            Text="Wishlist"
            runat="server" />

        &nbsp;&nbsp;

        <asp:LinkButton 
            ID="btnLogout" 
            runat="server"
            OnClick="btnLogout_Click">
            Logout
        </asp:LinkButton>
    </div>
    </div>


    <!-- Content -->
    <div class="container">
        <h2>Available Books</h2>

        <asp:GridView ID="gvBooks" runat="server"
            CssClass="grid"
            AutoGenerateColumns="false"
            OnRowCommand="gvBooks_RowCommand">

            <Columns>
                <asp:BoundField DataField="BookId" HeaderText="ID" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Author" HeaderText="Author" />
                <asp:BoundField DataField="Price" HeaderText="Price (₹)" />

                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button
                            Text="Add to Cart"
                            CssClass="btn-cart"
                            runat="server"
                            CommandName="AddToCart"
                            CommandArgument='<%# Eval("BookId") %>' />

                        &nbsp;

                        <asp:Button
                            Text="Wishlist"
                            CssClass="btn-wishlist"
                            runat="server"
                            CommandName="AddToWishlist"
                            CommandArgument='<%# Eval("BookId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>
    </div>

</form>
</body>
</html>
