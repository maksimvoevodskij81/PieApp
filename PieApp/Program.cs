using Microsoft.EntityFrameworkCore;
using PieApp;
using PieApp.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");

string connectionString;
if (!string.IsNullOrEmpty(dbHost))
{
    var dbName = Environment.GetEnvironmentVariable("DB_NAME"); 
    var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
    var dbPort = Environment.GetEnvironmentVariable("DB_PORT");

   connectionString = $"Server={dbHost},{dbPort};Database={dbName};User=sa;Password={dbPassword};TrustServerCertificate=True";
}
else
{
    connectionString = builder.Configuration.GetConnectionString("PieAppDbContextConnection") ?? 
                       throw new InvalidOperationException("Connection string 'PieAppDbContextConnection' not found.");
}
 
builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));

builder.Services.AddDbContext<PieAppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<PieAppDbContext>();

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("/app/keys"));

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/app/{*catchall}", "/App/Index");
DbInitializer.Seed(app);
app.Run();
