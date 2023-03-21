using Microsoft.EntityFrameworkCore;
using CleanOff.Models;
var builder = WebApplication.CreateBuilder(args);


// Service settings
builder.Services.AddControllersWithViews();
builder.Configuration.AddJsonFile("connection_strings.json");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}"
);

app.Run();