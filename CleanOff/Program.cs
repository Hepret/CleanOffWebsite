var builder = WebApplication.CreateBuilder(args);


// Service settings
builder.Services.AddControllersWithViews();


var app = builder.Build();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}"
);

app.Run();