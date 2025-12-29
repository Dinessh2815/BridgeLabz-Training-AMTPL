<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="OrderHistory.aspx.cs"
    Inherits="BookStoreApp.Pages.OrderHistory" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Order History</title>

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
            width: 85%;
            margin: 30px auto;
            background: white;
            padding: 20px;
            border-radius: 6px;
        }

        .order-box {
            border: 1px solid #ddd;
            margin-bottom: 25px;
            border-radius: 6px;
        }

        .order-header {
            background: #f1f1f1;
            padding: 10px;
            font-weight: bold;
        }

        .grid {
            width: 100%;
            border-collapse: collapse;
        }

        .grid th {
            background: #eaeaea;
            padding: 8px;
            text-align: left;
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
        <a href="~/Pages/OrderHistory.aspx" runat="server">Orders</a>
        <asp:LinkButton runat="server" Text="Logout" OnClick="Logout_Click" />
    </div>

    <!-- CONTENT -->
    <div class="container">
        <h2>My Order History</h2>

        <asp:Repeater ID="rptOrders" runat="server">
            <ItemTemplate>

                <div class="order-box">

                    <div class="order-header">
                        Order #<%# Eval("OrderId") %>
                        | Date: <%# Eval("OrderDate", "{0:dd-MMM-yyyy}") %>
                        | Total: ₹<%# Eval("TotalAmount") %>
                    </div>

                    <asp:GridView runat="server"
                        CssClass="grid"
                        AutoGenerateColumns="false"
                        DataSource='<%# Eval("Items") %>'>

                        <Columns>
                            <asp:BoundField DataField="Title" HeaderText="Book" />
                            <asp:BoundField DataField="Quantity" HeaderText="Qty" />
                            <asp:BoundField DataField="Price" HeaderText="Price" />
                            <asp:BoundField DataField="ItemTotal" HeaderText="Total" />
                        </Columns>

                    </asp:GridView>

                </div>

            </ItemTemplate>
        </asp:Repeater>

    </div>

</form>
</body>
</html>
