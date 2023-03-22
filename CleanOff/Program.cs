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

// swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}"
);

app.Run();