using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
namespace BaiTapQuayVideo.Database
{
    public class ConnectDatabase
    {
        //biến để chứa chuỗi kết nối
        private readonly string? _connectionString;
        //hàm khởi tạo của ConnectDatabase
        public ConnectDatabase(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        //hàm trả về đối tượng kết nối
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
