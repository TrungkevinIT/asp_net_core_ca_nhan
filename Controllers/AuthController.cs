using BaiTapQuayVideo.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BaiTapQuayVideo.Controllers
{
    public class AuthController : Controller
    {
        private readonly ConnectDatabase _connection;
        public AuthController(ConnectDatabase connection)
        {
            _connection = connection;
        }
        // chỉ hiện ra giao diện login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        // xử lý form đăng nhập
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            string hashedPassword = password;
            using (var connection = _connection.GetConnection())
            {
                // mở kết nối csdl
                connection.Open();
                //chuỗi truy vấn lấy ra dòng dữ liệu về email HashedPassword và States
                string querystaff = "SELECT * FROM Staffs WHERE Email = @Email AND HashedPassword = @HashedPassword AND States = 1";
                // thực thi câu truy vấn
                SqlCommand cmd = new SqlCommand(querystaff, connection);
                 //gán giá trị của email và HashedPassword lần lược vào @Email và @HasPassword dùng để kiểm tra điều kiện
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@HashedPassword", hashedPassword);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    //lay 2 gia tri nay luu vao session
                    int role = Convert.ToInt32(reader["Roles"]);
                    string? username = reader["username"].ToString();
                    HttpContext.Session.SetString("username", username);
                    HttpContext.Session.SetString("Role", role.ToString());
                    reader.Close();
                    if (role == 0) {
                        return RedirectToAction("ProductManagement", "Admin", new { area = "Admin" });
                    }
                   
                }
                reader.Close();
                //cũng giống như Admin này dùng để kiểm tra nếu là tài khoản khách hàng thì sẽ được chuyển đến trang chủ của trang web phía người dùng
                string queryCustomer = "SELECT * FROM Customers WHERE Email = @Email AND HashedPassword = @HashedPassword AND States = 1";
                SqlCommand cmdCustomer = new SqlCommand(queryCustomer, connection);
                cmdCustomer.Parameters.AddWithValue("@Email", email);
                cmdCustomer.Parameters.AddWithValue("@HashedPassword", hashedPassword);
                SqlDataReader anotherReader = cmdCustomer.ExecuteReader();

                if (anotherReader.Read())
                {
                    string? name = anotherReader["CustomerName"].ToString();
                    HttpContext.Session.SetString("Username", name);
                    HttpContext.Session.SetString("Role", "Customer");
                    anotherReader.Close();
                    return RedirectToAction("Index", "Home",new {area="Customer"});
                }
                anotherReader.Close();
                //nếu tài khoản không tồn tại thì nó sẽ nội dung này cùng với điều kiện
                ViewBag.Error = "Email hoặc mật khẩu không đúng!";
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
