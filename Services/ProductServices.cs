using BaiTapQuayVideo.Models;
using BaiTapQuayVideo.Database;
using Microsoft.Data.SqlClient;
namespace BaiTapQuayVideo.Services
{
    public class ProductServices 
    {
        //khai báo biến tham chiếu đến ConnectDatabase
        private readonly ConnectDatabase _connectDatabase;
        //gán biến trên vào Hàm khởi tạo ProductServices để có thể sử dụng các phương thức của ConnectDatabase
        public ProductServices(ConnectDatabase connectDatabase)
        {
            _connectDatabase = connectDatabase;
        }
        public List<Product> GetAllProducts()
        {
            var result = new List<Product>();
            try
            {
                
                using (var connection = _connectDatabase.GetConnection())// lấy ra chuỗi kết nối đến csdl
                {
                   
                    connection.Open();
                    //chuỗi truy vấn
                    
                    string query = "select * from Products";
                    using (var cmd = new SqlCommand(query, connection))// thực hiện câu truy vấn
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //đọc qua từng dòng dữ liệu
                            while (reader.Read())
                            {
                                result.Add(MapToProduct(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm", ex);
            }
            return result;
        }
       
        public bool AddProducts(Product product)
        {
            try
            { //kết nối đến csdl
                using (var connection = _connectDatabase.GetConnection())
                {
                    //mở kết nối
                    connection.Open();
                    //câu lệnh thêm sản phẩm product 
                    string queryProduct = @"INSERT INTO Products
                                (ProductName, ImageUrl, Price, PromotionPrice, ProductDescription, TagName, CategoryId, States, ProductType)
                                VALUES
                                (@ProductName, @ImageUrl, @Price, @PromotionPrice, @ProductDescription, @TagName, @CategoryId, @States, @ProductType)";
                    using (var cmd = new SqlCommand(queryProduct, connection))
                    {
                        AddCommandCategory(cmd, product);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách san pham", ex);
            }
        }
        public List<Product> GetTop6RanDomProducts()
        {
            var result = new List<Product>();
            try
            {
                using (var connection = _connectDatabase.GetConnection())// lấy ra chuỗi kết nối đến csdl
                {
                    connection.Open(); // mở kết nối
                    //chuỗi truy vấn

                    string query = "select Top 3 * from Products where ProductType like N'Bike' ORDER BY NEWID()";  
                    using (var cmd = new SqlCommand(query, connection))// thực hiện câu truy vấn
                    {
                       
                        using (var reader = cmd.ExecuteReader())
                        {
                            //đọc qua từng dòng dữ liệu
                            while (reader.Read())
                            {
                                result.Add(MapToProduct(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm", ex);
            }
            return result;
        }
        // dọc một dòng dữ liệu trong product
        private Product MapToProduct(SqlDataReader reader)
        {
            return new Product
            {
                ProductId = Convert.ToInt32(reader["ProductId"]),
                ProductName = reader["ProductName"]?.ToString(),
                Price = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : 0,
                PromotionPrice = reader["PromotionPrice"] != DBNull.Value ? Convert.ToDecimal(reader["PromotionPrice"]) : 0,
                ProductDescription = reader["ProductDescription"]?.ToString(),
                TagName = reader["TagName"]?.ToString(),
                CategoryId = reader["CategoryId"] != DBNull.Value ? Convert.ToInt32(reader["CategoryId"]) : 0,
                States = reader["States"] != DBNull.Value ? Convert.ToInt32(reader["States"]) : 0,
                ImageUrl = reader["ImageUrl"]?.ToString(),
                ProductType = reader["ProductType"]?.ToString()
            };
        }
        private void AddCommandCategory(SqlCommand command, Product product)
        {
            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@ImageUrl", (object?)product.ImageUrl ?? DBNull.Value);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@PromotionPrice", product.PromotionPrice);
            command.Parameters.AddWithValue("@ProductDescription", (object?)product.ProductDescription ?? DBNull.Value);
            command.Parameters.AddWithValue("@TagName", (object?)product.TagName ?? DBNull.Value);
            command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
            command.Parameters.AddWithValue("@States", product.States);
            command.Parameters.AddWithValue("@ProductType", (object?)product.ProductType ?? DBNull.Value);
        }

    }
}
