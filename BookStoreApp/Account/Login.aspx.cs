using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using BookStoreApp.Helpers;

namespace BookStoreApp.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // No initialization needed for now
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                // Hash the entered password
                string hashedPassword = PasswordHelper.HashPassword(txtPassword.Text);

                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Users WHERE Email = @e AND Password = @p", con);

                cmd.Parameters.AddWithValue("@e", txtEmail.Text);
                cmd.Parameters.AddWithValue("@p", hashedPassword);

                con.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count == 1)
                {
                    // Generate JWT token
                    string token = JwtHelper.GenerateToken(txtEmail.Text);

                    // Store JWT in cookie
                    HttpCookie jwtCookie = new HttpCookie("JWT", token);
                    jwtCookie.HttpOnly = true;
                    jwtCookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(jwtCookie);

                    Response.Redirect("~/Pages/Books.aspx");

                    
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Invalid email or password";
                }
            }
        }
    }
}
