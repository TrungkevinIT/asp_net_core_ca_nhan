using BaiTapQuayVideo.Database;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
// lấy chuỗi kết nối từ file appsetting.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//đăng lý Dbcontext
builder.Services.AddScoped<BaiTapQuayVideo.Services.ProductServices>();//dang ky dich vu DI
builder.Services.AddScoped<BaiTapQuayVideo.Services.CategoryServices>();
builder.Services.AddSession(options =>
{
    // Expire in 15 minutes.
    options.IdleTimeout = TimeSpan.FromMinutes(15);
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ConnectDatabase>();//dang ky dich vu DI
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
//nếu nhập link không đúng thì nó sẽ hiện ra giao diện lỗi
app.MapFallbackToController("Error","Home");
app.Run();
