using BookStoreApp.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreApp.Pages
{
    public partial class OrderHistory : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadOrders();
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("JWT");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            Response.Redirect("~/Account/Login.aspx");
        }

        private void LoadOrders()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT 
                        o.OrderId,
                        o.OrderDate,
                        o.TotalAmount,
                        b.Title,
                        oi.Quantity,
                        oi.Price,
                        (oi.Quantity * oi.Price) AS ItemTotal
                    FROM Orders o
                    JOIN OrderItems oi ON o.OrderId = oi.OrderId
                    JOIN Books b ON oi.BookId = b.BookId
                    WHERE o.UserId = (
                        SELECT UserId FROM Users WHERE Email=@e
                    )
                    ORDER BY o.OrderDate DESC", con);

                da.SelectCommand.Parameters.AddWithValue("@e", LoggedInEmail);

                DataTable dt = new DataTable();
                da.Fill(dt);

                // Group by OrderId
                var orders = dt.AsEnumerable()
                    .GroupBy(r => new
                    {
                        OrderId = r["OrderId"],
                        OrderDate = r["OrderDate"],
                        TotalAmount = r["TotalAmount"]
                    })
                    .Select(g => new
                    {
                        g.Key.OrderId,
                        g.Key.OrderDate,
                        g.Key.TotalAmount,
                        Items = g.Select(r => new
                        {
                            Title = r["Title"],
                            Quantity = r["Quantity"],
                            Price = r["Price"],
                            ItemTotal = r["ItemTotal"]
                        }).ToList()
                    }).ToList();

                rptOrders.DataSource = orders;
                rptOrders.DataBind();
            }
        }
    }
}
