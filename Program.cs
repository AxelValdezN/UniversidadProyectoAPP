using Microsoft.EntityFrameworkCore;
using AppDoAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// cnfigurar la base de datos SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=appdo.db"));

// configurar CORS (Permitir que el frontend se conecte)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();