using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace BookStoreApp.Pages
{
    public partial class Books : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // JWT protection
            if (Request.Cookies["JWT"] == null || string.IsNullOrEmpty(Request.Cookies["JWT"].Value))
            {
                Response.Redirect("~/Account/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                lblWelcome.Text = "Hi, " + GetLoggedInUserFullName();
                LoadBooks();
            }
        }

        private void LoadBooks()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT BookId, Title, Author, Price FROM Books", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                gvBooks.DataSource = dt;
                gvBooks.DataBind();
            }
        }

        private string GetLoggedInUserEmail()
        {
            HttpCookie jwtCookie = Request.Cookies["JWT"];
            if (jwtCookie == null || string.IsNullOrEmpty(jwtCookie.Value))
            {
                // Token missing → force login
                Response.Redirect("~/Account/Login.aspx");
                return "";
            }
            string token = Request.Cookies["JWT"].Value;

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var emailClaim = jwtToken.Claims
                .FirstOrDefault(c => c.Type == "email");

            return emailClaim != null ? emailClaim.Value : "";
        }

        // Read user from JWT
        private string GetLoggedInUserFullName()
        {
            string email = GetLoggedInUserEmail();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT FullName FROM Users WHERE Email = @e", con);

                cmd.Parameters.AddWithValue("@e", email);

                con.Open();
                object result = cmd.ExecuteScalar();

                return result != null ? result.ToString() : "User";
            }
        }

        private int GetLoggedInUserId()
        {
            string email = GetLoggedInUserEmail();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT UserId FROM Users WHERE Email = @e", con);

                cmd.Parameters.AddWithValue("@e", email);

                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }



        // Handle GridView buttons
        protected void gvBooks_RowCommand(object sender,
            System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int bookId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "AddToCart")
            {
                int userId = GetLoggedInUserId();
                AddBookToCart(userId, bookId);
            }
            else if (e.CommandName == "AddToWishlist")
            {
                int userId = GetLoggedInUserId();
                AddToWishlist(userId, bookId);
            }
        }

        private void AddToWishlist(int userId, int bookId)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(@"
            IF NOT EXISTS
            (
                SELECT 1 FROM Wishlist 
                WHERE UserId = @u AND BookId = @b
            )
            INSERT INTO Wishlist (UserId, BookId)
            VALUES (@u, @b)", con);

                cmd.Parameters.AddWithValue("@u", userId);
                cmd.Parameters.AddWithValue("@b", bookId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
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
                VALUES (@u, @b, 1)
        ", con);

                cmd.Parameters.AddWithValue("@u", userId);
                cmd.Parameters.AddWithValue("@b", bookId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }



        // Logout
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["JWT"] != null)
            {
                HttpCookie cookie = new HttpCookie("JWT");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            Response.Redirect("~/Account/Login.aspx");
        }

        
    }
}
