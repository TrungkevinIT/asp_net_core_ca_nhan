using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BaiTapQuayVideo.Models;
namespace BaiTapQuayVideo.Database
{
    // lớp này kế thừa từ lớp Dbcontext của EF Core
    public class ConnectDatabase:DbContext
    {
        //biến để chứa chuỗi kết nối
        private readonly string? _connectionString;
        //constructor này nhận vào DbDbContextOptions cho phép cấu hình Dbcontext từ bên ngoài
        public ConnectDatabase(DbContextOptions<ConnectDatabase> options):base(options) { 
        }
        //khai báo các DbSet tương ứng với các bảng trong database mà EF quản lý
        public DbSet<Product> Products { get; set; }
        public DbSet<StaffModel> Staffs { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Categories> Categories { get;set; }

    }
}
