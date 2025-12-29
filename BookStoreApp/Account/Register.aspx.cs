using BookStoreApp.Helpers;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Xml.Linq;

namespace BookStoreApp.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                // Hash password before storing
                string hashedPassword = PasswordHelper.HashPassword(txtPassword.Text);

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Users (FullName, Email, Password) VALUES (@n, @e, @p)", con);

                cmd.Parameters.AddWithValue("@n", txtName.Text);
                cmd.Parameters.AddWithValue("@e", txtEmail.Text);
                cmd.Parameters.AddWithValue("@p", hashedPassword);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = "Registered successfully";
        }
    }
}
