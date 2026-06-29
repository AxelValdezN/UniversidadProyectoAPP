using app_to_do.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<AuthService>();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern:
    "{controller=Account}/{action=Login}/{id?}");

app.Run();
