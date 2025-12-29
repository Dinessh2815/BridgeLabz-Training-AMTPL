using BookStoreApp.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BookStoreApp.Pages
{
    public partial class Cart : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // BasePage ensures LoggedInEmail is set or redirects.
            if (!IsPostBack)
            {
                LoadCart();
            }
        }



        private int GetLoggedInUserId()
        {
            if (string.IsNullOrEmpty(LoggedInEmail))
                throw new Exception("LoggedInEmail is missing");

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT UserId FROM Users WHERE Email = @e", con);

                cmd.Parameters.AddWithValue("@e", LoggedInEmail);

                con.Open();
                object result = cmd.ExecuteScalar();

                if (result == null)
                    throw new Exception("User not found");

                return Convert.ToInt32(result);
            }
        }

        private void LoadCart()
        {
            int userId = GetLoggedInUserId();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter(@"
            SELECT 
                c.CartId,
                b.Title,
                b.Author,
                b.Price,
                c.Quantity,
                (b.Price * c.Quantity) AS ItemTotal
            FROM Cart c
            JOIN Books b ON c.BookId = b.BookId
            WHERE c.UserId = @u", con);

                da.SelectCommand.Parameters.AddWithValue("@u", userId);

                DataTable dt = new DataTable();
                da.Fill(dt);

                gvCart.DataSource = dt;
                gvCart.DataBind();

                // Grand total
                decimal grandTotal = 0;
                foreach (DataRow row in dt.Rows)
                {
                    grandTotal += Convert.ToDecimal(row["ItemTotal"]);
                }

                lblGrandTotal.Text = grandTotal.ToString("0.00");
            }
        }


        protected void gvCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int cartId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Increase")
            {
                UpdateQuantity(cartId, +1);
            }
            else if (e.CommandName == "Decrease")
            {
                UpdateQuantity(cartId, -1);
            }
            else if (e.CommandName == "Remove")
            {
                RemoveFromCart(cartId);
            }

            LoadCart();
        }


        private void RemoveFromCart(int cartId)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Cart WHERE CartId = @c", con);

                cmd.Parameters.AddWithValue("@c", cartId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void UpdateQuantity(int cartId, int change)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(@"
            UPDATE Cart
            SET Quantity = Quantity + @c
            WHERE CartId = @id", con);

                cmd.Parameters.AddWithValue("@c", change);
                cmd.Parameters.AddWithValue("@id", cartId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            RemoveZeroQuantity(cartId);
        }

        private void RemoveZeroQuantity(int cartId)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Cart WHERE CartId=@id AND Quantity <= 0", con);

                cmd.Parameters.AddWithValue("@id", cartId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            PlaceOrder();
            Response.Redirect("~/Pages/OrderHistory.aspx");
        }

        private void PlaceOrder()
        {
            int userId = GetLoggedInUserId();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();

                try
                {
                    // 1️⃣ Calculate total
                    SqlCommand cmdTotal = new SqlCommand(@"
                SELECT SUM(b.Price * c.Quantity)
                FROM Cart c
                JOIN Books b ON c.BookId = b.BookId
                WHERE c.UserId = @u", con, tx);

                    cmdTotal.Parameters.AddWithValue("@u", userId);
                    decimal total = Convert.ToDecimal(cmdTotal.ExecuteScalar());

                    // 2️⃣ Insert Order
                    SqlCommand cmdOrder = new SqlCommand(@"
                INSERT INTO Orders (UserId, TotalAmount)
                VALUES (@u, @t);
                SELECT SCOPE_IDENTITY();", con, tx);

                    cmdOrder.Parameters.AddWithValue("@u", userId);
                    cmdOrder.Parameters.AddWithValue("@t", total);

                    int orderId = Convert.ToInt32(cmdOrder.ExecuteScalar());

                    // 3️⃣ Insert OrderItems
                    SqlCommand cmdItems = new SqlCommand(@"
                INSERT INTO OrderItems (OrderId, BookId, Quantity, Price)
                SELECT @o, c.BookId, c.Quantity, b.Price
                FROM Cart c
                JOIN Books b ON c.BookId = b.BookId
                WHERE c.UserId = @u", con, tx);

                    cmdItems.Parameters.AddWithValue("@o", orderId);
                    cmdItems.Parameters.AddWithValue("@u", userId);
                    cmdItems.ExecuteNonQuery();

                    // 4️⃣ Clear Cart
                    SqlCommand cmdClear = new SqlCommand(
                        "DELETE FROM Cart WHERE UserId = @u", con, tx);

                    cmdClear.Parameters.AddWithValue("@u", userId);
                    cmdClear.ExecuteNonQuery();

                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }


    }
}