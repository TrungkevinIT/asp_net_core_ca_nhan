using BaiTapQuayVideo.Models;
using BaiTapQuayVideo.Database;
using Microsoft.Data.SqlClient;
namespace BaiTapQuayVideo.Services
{
    public class CategoryServices
    {
        //khai báo biến tham chiếu đến ConnectDatabase
        private readonly ConnectDatabase _connectDatabase;
        //gán tham chiếu đó vào hàm khởi tạo của CategoryServices để CategoryServices có thể sử dụng phương thức trong ConnectDatabase
        public CategoryServices(ConnectDatabase connectDatabase)
        {
            _connectDatabase = connectDatabase;
        }
        //lấy ra tất cả danh sách trong danh mục
        public List<Categories> GetAllCategories()
        {
            var result=new List<Categories>();
            try
            {
                //ket noi
                //mo ket noi
                //viet cau truy van
                //thuc thi truy van
                //
                using (var connection = _connectDatabase.GetConnection())
                {
                    connection.Open();
                    string query = "select * from Categories";
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        using (var reader=cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(MapToCategories(reader));
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách danh mục", ex);
            }
            return result;
        }
        //hàm dùng để thêm danh mục
        public bool AddCategory(Categories categories)
        {
            try
            { //kết nối đến csdl

                using (var connection = _connectDatabase.GetConnection())
                {
                    //mở kết nối
                    connection.Open();
                    //câu lệnh thêm sản phẩm danh mục  @CategoryName, @States, @Slug sẽ được thêm vào Categories
                    string query = @"INSERT INTO Categories(CategoryName, States, Slug)VALUES
                                                           (@CategoryName, @States, @Slug)";
                    using (var cmd = new SqlCommand(query, connection))
                    {
                     
                        AddCommandCategory(cmd, categories);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách danh mục", ex);
            }
            

        }
        public Categories MapToCategories(SqlDataReader reader)
        {
            return new Categories
            {
                CategoryId = Convert.ToInt32(reader["CategoryId"]),
                CategoryName = reader["CategoryName"]?.ToString() ?? string.Empty,
                States = reader["States"] != DBNull.Value ? Convert.ToByte(reader["States"]) : (byte)1,
                Slug = reader["Slug"]?.ToString()
            };
        }
        private void AddCommandCategory(SqlCommand cmd, Categories category)
        {
            cmd.Parameters.AddWithValue("@CategoryName", (object?)category.CategoryName ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@States", category.States);
            cmd.Parameters.AddWithValue("@Slug", (object?)category.Slug ?? DBNull.Value);
        }
    }
}