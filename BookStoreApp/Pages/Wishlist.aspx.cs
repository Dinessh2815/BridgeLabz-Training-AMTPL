using BookStoreApp.Helpers;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace BookStoreApp.Pages
{
    public partial class Wishlist : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadWishlist();
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("JWT");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            Response.Redirect("~/Account/Login.aspx");
        }

        private void LoadWishlist()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT 
                        w.WishlistId,
                        b.BookId,
                        b.Title,
                        b.Author,
                        b.Price
                    FROM Wishlist w
                    JOIN Books b ON w.BookId = b.BookId
                    WHERE w.UserId = (
                        SELECT UserId FROM Users WHERE Email=@e
                    )", con);

                da.SelectCommand.Parameters.AddWithValue("@e", LoggedInEmail);

                DataTable dt = new DataTable();
                da.Fill(dt);

                gvWishlist.DataSource = dt;
                gvWishlist.DataBind();
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

        protected void gvWishlist_RowCommand(object sender,
            System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int userId = GetLoggedInUserId();

            if (e.CommandName == "MoveToCart")
            {
                int bookId = Convert.ToInt32(e.CommandArgument);
                AddBookToCart(userId, bookId);
                RemoveFromWishlistByBook(bookId);
            }
            else if (e.CommandName == "Remove")
            {
                int wishlistId = Convert.ToInt32(e.CommandArgument);
                RemoveFromWishlist(wishlistId);
            }

            LoadWishlist();
        }

        private void AddBookToCart(int userId, int bookId)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(@"
                    IF EXISTS (SELECT 1 FROM Cart WHERE UserId=@u AND BookId=@b)
                        UPDATE Cart SET Quantity = Quantity + 1
                        WHERE UserId=@u AND BookId=@b
                    ELSE
                        INSERT INTO Cart (UserId, BookId, Quantity)
                        VALUES (@u, @b, 1)", con);

                cmd.Parameters.AddWithValue("@u", userId);
                cmd.Parameters.AddWithValue("@b", bookId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void RemoveFromWishlist(int wishlistId)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Wishlist WHERE WishlistId=@id", con);

                cmd.Parameters.AddWithValue("@id", wishlistId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void RemoveFromWishlistByBook(int bookId)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(@"
                    DELETE FROM Wishlist
                    WHERE BookId=@b
                    AND UserId = (
                        SELECT UserId FROM Users WHERE Email=@e
                    )", con);

                cmd.Parameters.AddWithValue("@b", bookId);
                cmd.Parameters.AddWithValue("@e", LoggedInEmail);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
