using AppDoAPI.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Configuramos al base de datos de Postgresql
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"))); //intectamos el motor (dbcontext)

// configuramos la parte de Cors para permitir que en el futuro el apk se conecte sin bloqueos
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Hacemos la activacioin de Cors en la app
app.UseCors("PermitirTodo");

app.UseAuthorization();
app.MapControllers(); // reutilizamos los controllers y los analiza (crea las urls automaticamente sin mover codigo)

app.Run();